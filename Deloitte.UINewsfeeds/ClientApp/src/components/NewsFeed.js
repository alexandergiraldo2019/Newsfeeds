import React from 'react'
import News from './News'

function NewsFeed(props) {
    return (
        <div>
            <div className="card">
                <div className="card-header" key={props.feedData.feedId}>{props.feedData.feedName}</div>
                <div className="card-body">
                    {props.feedData.newsTop.map(newsdetreg =>
                        <ul>
                            <li>
                                <a href={newsdetreg.urlNews}>{newsdetreg.title}</a>
                                <button className="btn btn-success" onClick={this.handleShowFeed(newsdetreg)}> Ver mas</button>

                            </li>

                        </ul>
                    )}
                </div>
                <div className="card-footer">{newsreg.feedData.apiUrl}</div>
            </div>
        </div>
    )
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


export default NewsFeed