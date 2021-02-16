import React, { useEffect, useState } from 'react';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';
import authService from './api-authorization/AuthorizeService'

const DashboardF = () => {
    const displayName = DashboardF.name;

    const [newsinfo, setNewsInfo] = useState();
    const [newsfeedsinfo, setNewsFeedInfo] = useState();
    const [loading, setLoading] = useState();


    useEffect(() => {
        populateNewsFeed()
    },[]) 


    return (
        <div>
            <h1 id="tabelLabel" >News</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {!newsfeedsinfo ? <p><em>Loading...</em></p> :
                <div>
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
                                                        <button onClick={hdlShowFeed(newsdetreg.idNews)}> Ver mas</button>
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
            }
        </div>
    );

    const populateNewsFeed = async () => {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/FeedNews', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        setNewsFeedInfo(data);
        setLoading(false);
    }

    const hdlShowFeed = (idNews) => {
        setNewsInfo(newsfeedsinfo.filter(r => r.idNews == idNews));
    }

}
