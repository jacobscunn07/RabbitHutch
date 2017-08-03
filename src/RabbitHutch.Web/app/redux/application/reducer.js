import { fromJS } from 'immutable';
import { REQUEST_SWITCH_APP } from './constants';

const initialState = fromJS({
  applicationId: 'localhost',
});

function applicationReducer(state = initialState, action) {
  switch (action.type) {
    case REQUEST_SWITCH_APP:
      return state.set('applicationId', action.applicationId);
    default:
      return state;
  }
}

export default applicationReducer;
