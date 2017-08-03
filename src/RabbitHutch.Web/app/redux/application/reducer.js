import { fromJS } from 'immutable';
import { REQUEST_SWITCH_APP_SUCCESS } from './constants';

const initialState = fromJS({
  applicationId: '',
});

function applicationReducer(state = initialState, action) {
  switch (action.type) {
    case REQUEST_SWITCH_APP_SUCCESS:
      return state.set('applicationId', action.applicationId);
    default:
      return state;
  }
}

export default applicationReducer;
