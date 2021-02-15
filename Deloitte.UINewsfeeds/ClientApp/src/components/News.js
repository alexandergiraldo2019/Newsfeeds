import React from 'react'

function News(props) {
    return (
        <div>
            <Modal>
                <ModalHeader>
                    <h3>More information about this News</h3>
                </ModalHeader>
                <ModalBody>
                    <div className="container">
                        <div className="row">
                            <div className="col-md-3 m-1">
                                    <div className="card">
                                    <div className="card-header" key={props.news.idNews}>{props.news.title} - {props.news.author}</div>
                                        <div className="card-body">
                                        <image src={props.urlImage} alt="Image_news" > </image>
                                        <p> {props.news.description} </p>
                                        <p> {props.news.content} </p>
                                        </div>
                                        <div className="card-footer">
                                            <button className="btn btn-primary">
                                            <a href={props.news.urlNews}>More</a>
                                            </button>
                                        </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                </ModalBody>

            </Modal>
        </div>    
    )
}


export default News