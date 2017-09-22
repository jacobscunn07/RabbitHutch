import 'babel-polyfill';
import React from 'react';
import { Provider } from 'react-redux';
import { render } from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { createBrowserHistory } from 'history';
// import { syncHistoryWithStore } from 'react-router-redux';
// import '../node_modules/bootstrap/dist/css/bootstrap.css';
// import '../node_modules/bootstrap/dist/js/bootstrap';
import '../node_modules/bulma/css/bulma.css';
import configureStore from './store/configureStore';
import App from './components/App';
import HomePage from './components/HomePage';
import MessagePage from './components/MessagePage';

const browserHistory = createBrowserHistory();
const store = configureStore({}, browserHistory);
// const history = syncHistoryWithStore(browserHistory, store);

render(
  <Provider store={store}>
    <Router>
      <App>
        <Route exact name="home" path="/" component={HomePage} />
        <Route exact name="message" path="/message/:id" component={MessagePage} />
      </App>
    </Router>
  </Provider>,
  document.getElementById('app'),
);
