import { createStore, applyMiddleware, compose } from 'redux';
import { routerMiddleware } from 'react-router-redux';
import thunk from 'redux-thunk';
import rootReducer from './reducer';
/* eslint-disable no-underscore-dangle */
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
/* eslint-enable */

export default function configureStore(initialState, history) {
  const store = createStore(
      rootReducer,
      initialState,
      composeEnhancers(applyMiddleware(thunk, routerMiddleware(history))),
  );

  return store;
}
