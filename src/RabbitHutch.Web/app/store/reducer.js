import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import reducer from './../redux/application/reducer';

const rootReducer = combineReducers({
  applications: reducer,
  routing: routerReducer,
});

export default rootReducer;
