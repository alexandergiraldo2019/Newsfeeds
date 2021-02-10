import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Counter extends Component {
    static displayName = Counter.name;

    constructor(props) {
        super(props);
        this.state = { newsinfo: [], loading: true };
    }

    componentDidMount() {
        this.populateNews();
        {/*this.populateNewsFeed();*/ }
    }

    static renderNewsTable(newsinfo) {
        return (
            <div>
                <div>
                    <div id="selectProvider">
                        <div className="container">
                            <div className="row">
                                <div className="col-md-3 m-1">
                                    {newsinfo.map(newsreg =>
                                        <div className="card">
                                            <div className="card-header" key={newsreg.IdNews}>{newsreg.Title}</div>
                                            <div className="card-body">
                                                {newsreg.Description}
                                            </div>
                                            <div className="card-footer">{newsreg.URLNews}</div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Counter.renderNewsTable(this.state.newsinfo);

        return (
            <div>
                {/*
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
                </div>*/}

                <h1 id="tabelLabel" >News</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateNews() {
        {/*
        const token = await authService.getAccessToken();
        const response = await fetch('api/news/?idProvider=1', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ newsinfo: data, loading: false });
        */}

        const token = await authService.getAccessToken();
        const response = await fetch('/api/GetNews', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ newsinfo: data, loading: false });
    }

    //async populateNewsFeed() {
    //    const token = await authService.getAccessToken();
    //    const response = await fetch('/api/FeedNews', {
    //        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    //    });
    //    const data = await response.json();
    //    this.setState({ newsfeedsinfo: data, loading: false });
    //}
}
