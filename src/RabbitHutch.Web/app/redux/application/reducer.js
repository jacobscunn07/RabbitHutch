import { fromJS } from 'immutable';
import { REQUEST_SWITCH_APP, REQUEST_APP_MESSAGES_SUCCESS } from './constants';

const initialState = fromJS({
  applicationId: 'localhost',
  totalMessages: 0,
});

function applicationReducer(state = initialState, action) {
  switch (action.type) {
    case REQUEST_SWITCH_APP:
      return state.set('applicationId', action.applicationId);
    case REQUEST_APP_MESSAGES_SUCCESS:
      return state.set('messages', action.result.results);
    default:
      return state;
  }
}

export default applicationReducer;
