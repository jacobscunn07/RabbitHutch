import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import '../node_modules/bulma/css/bulma.css';
import './app.css';
import App from './components/App';
import HomePage from './components/HomePage';
import MessagePage from './components/MessagePage';

render(
    <Router>
      <App>
        <Route exact name="home" path="/" component={HomePage} />
        <Route exact name="message" path="/message/:id" component={MessagePage} />
      </App>
    </Router>,
  document.getElementById('app'),
);
