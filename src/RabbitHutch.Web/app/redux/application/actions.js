import {
  REQUEST_SWITCH_APP,
  REQUEST_APP_MESSAGES_SUCCESS,
  REQUEST_APP_MESSAGES_FAILURE } from './constants';

function fetchMessages() {
  return fetch('/api/search', {
    method: 'GET',
  });
}

export function requestSwitchApp(applicationId) {
  return {
    type: REQUEST_SWITCH_APP,
    applicationId,
  };
}

export function requestAppMessagesSuccess(result) {
  return {
    type: REQUEST_APP_MESSAGES_SUCCESS,
    result,
  };
}

export function requestAppMessagesFailure(message) {
  return {
    type: REQUEST_APP_MESSAGES_FAILURE,
    message,
  };
}

export function requestAppMessages() {
  return (dispatch) => {
    fetchMessages()
    .then(response => response.json())
    .then(response => dispatch(requestAppMessagesSuccess(response)))
    .catch(err => dispatch(requestAppMessagesFailure(err.message)));
  };
}
