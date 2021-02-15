import React, { Component, useState } from 'react';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';
import PropTypes from 'prop-types'
import authService from './api-authorization/AuthorizeService'

const Dashboard = () => {
    const displayName = Dashboard.name;

    constructor(props) {
        super(props);
        this.state = { newsinfo: [], newsfeedsinfo: [], loading: true };
    }

    const (newsinfo, setNewsInfo ) = useState();
    const (newsfeedsinfo, setNewsInfo) = useState();
    const (loading, setloading) = useState();


    componentDidMount() {
        this.populateNews();
        {/*this.populateNewsFeed();*/ }

    }

    static renderNewsTable(newsinfo, newsfeedsinfo) {
        return (
            <div>
                <div>
                    <div id="selectProvider">
                        <div className="container">
                            <div className="row">
                                <div className="col-md-3 m-1">
                                    {newsfeedsinfo.map(newsreg =>
                                        <div className="card">
                                            <div className="card-header" key={newsreg.feedData.feedId}>{newsreg.feedData.feedName}</div>
                                            <div className="card-body">
                                                {newsreg.newsTop.map(newsdetreg =>
                                                    <ul>
                                                        <li>
                                                            <a href={newsdetreg.urlNews}>{newsdetreg.title}</a>
                                                            {/* Adicionar evento para controlar el modal*/}
                                                            {/*<button onClick={(id)=>this.handleShowFeed(newsdetreg.idNews)}> Ver mas</button>*/}
                                                            {/*<button onClick={() => this.setState({ showModal: true })}> Ver mas</button>*/}
                                                            {/*<button onClick={this.handleShowFeed(newsdetreg.idNews)}> Ver mas</button>*/}

                                                        </li>

                                                    </ul>
                                                )}
                                            </div>
                                            <div className="card-footer">{newsreg.feedData.apiUrl}</div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                {/*
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
                */}
                <Modal>
                    <ModalHeader>
                        <h3>More information about this News</h3>
                    </ModalHeader>
                    <ModalBody>
                        <div className="container">
                            <div className="row">
                                <div className="col-md-3 m-1">
                                    {newsinfo.map(newsreg =>
                                        <div className="card">
                                            <div className="card-header" key={newsreg.idNews}>{newsreg.title} - {newsreg.author}</div>
                                            <div className="card-body">
                                                <image src={newsinfo.urlImage} alt="Image_news" > </image>
                                                <p> {newsreg.description} </p>
                                                <p> {newsreg.content} </p>
                                            </div>
                                            <div className="card-footer">
                                                <button className="btn btn-primary">
                                                    <a href={newsinfo.urlNews}>More</a>
                                                </button>
                                            </div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>

                    </ModalBody>

                </Modal>

            </div>
        );
    }

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
        const response = await fetch('/api/FeedNews', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ newsfeedsinfo: data, loading: false });
    }

    async populateNewsFeed() {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/FeedNews', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ newsfeedsinfo: data, loading: false });
    }

    handleShowFeed(idNews) {
        //ubicar idnews en coleccion a asignarla a  y mostrar el modal
        { /*
        this.setState({
            newsinfo: this.state.newsfeedsinfo.filter(r => r.idNews == idNews)
        });
        */}

        console.log(idNews);
    }

    hdlShowFeed = (idNews) => {
        this.setState({ newsinfo: this.state.newsfeedsinfo.filter(r => r.idNews == idNews) })
        this.state.newsfeedsinfo.map(feed => {
            feed.map(n => {
                if (n.idNews === idNews) {
                    this.setState({ newsinfo: n });
                }
            })
        });
    }

    //Dashboard.propTypes = {
    //    feeds: PropTypes.array.isRequired
    //}

}
