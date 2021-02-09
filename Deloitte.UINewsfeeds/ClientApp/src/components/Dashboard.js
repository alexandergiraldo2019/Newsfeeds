import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Dashboard extends Component {
    static displayName = Dashboard.name;

    constructor(props) {
        super(props);
        this.state = { newsinfo: [], loading: true };
    }

    componentDidMount() {
        this.populateNews();
    }

    static renderNewsTable(newsinfo) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name.</th>
                        <th>Url.</th>
                    </tr>
                </thead>
                <tbody>
                    {newsinfo.map(newsreg =>
                        <tr key={newsreg.feedId}>
                            <td>{newsreg.feedId}</td>
                            <td>{newsreg.feedName}</td>
                            <td>{newsreg.apiUrl}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Dashboard.renderNewsTable(this.state.newsinfo);

        return (
            <div>
                <div id="selectProvider">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-4 m-2">
                                <div className="card">
                                    <div className="card-header">Header</div>
                                    <div className="card-body">Content</div>
                                    <div className="card-footer">Footer</div>
                                </div>
                            </div>
                            <div className="col-md-4 m-2">
                                <div className="card">
                                    <div className="card-header">Header</div>
                                    <div className="card-body">Content</div>
                                    <div className="card-footer">Footer</div>
                                </div>
                            </div>
                            <div className="col-md-4 m-2">
                                <div class="card">
                                    <div className="card-header">Header</div>
                                    <div className="card-body">Content</div>
                                    <div className="card-footer">Footer</div>
                                </div>
                            </div>
                            <div className="col-md-4 m-2">
                                <div className="card">
                                    <div className="card-header">Header</div>
                                    <div className="card-body">Content</div>
                                    <div className="card-footer">Footer</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h1 id="tabelLabel" >News</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateNews() {
        const token = await authService.getAccessToken();
        const response = await fetch('api/news/?idProvider=1', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ newsinfo: data, loading: false });
    }
}
