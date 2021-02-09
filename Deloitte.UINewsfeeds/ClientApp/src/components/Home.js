import React, { Component } from 'react';
import { BrowserRouter, Link, NavLink, Route, Switch, Redirect } from 'react-router-dom';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      const loginPath = `${ApplicationPaths.Login}`
    return (
        <div>
            <div>
                <img src="/images/Newsfeeds.png" classname="" height="500" width="1000" />
            </div>
            <div className="link-container">
                <Link to={loginPath} className="link">Login</Link>
            </div>

            {/* comentario */}

            {/*
                <Redirect
                from="/"
                to="/dashboard" />
            */}
        </div>
    );
  }
}
