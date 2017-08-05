import 'babel-polyfill';
import React from 'react';
import { Provider } from 'react-redux';
import { render } from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import { syncHistoryWithStore } from 'react-router-redux';
// import '../node_modules/bootstrap/dist/css/bootstrap.css';
// import '../node_modules/bootstrap/dist/js/bootstrap';
import '../node_modules/bulma/css/bulma.css';
import configureStore from './store/configureStore';
import App from './components/App';
import HomePage from './components/HomePage';

const browserHistory = createBrowserHistory();
const store = configureStore({}, browserHistory);
const history = syncHistoryWithStore(browserHistory, store);

render(
  <Provider store={store}>
    <Router history={history}>
      <App>
        <Route exact path="/" component={HomePage} />
      </App>
    </Router>
  </Provider>,
  document.getElementById('app'),
);
