import {
  REQUEST_SWITCH_APP,
  REQUEST_APP_MESSAGES_SUCCESS,
  REQUEST_APP_MESSAGES_FAILURE,
  REQUEST_APP_MESSAGE_SUCCESS,
  REQUEST_APP_MESSAGE_FAILURE } from './constants';

function fetchMessages() {
  return fetch('/api/search', {
    method: 'GET',
  });
}

function fetchMessage(messageId) {
  return fetch(`/api/message?guid=${messageId}`, {
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

export function requestAppMessageSuccess(result) {
  return {
    type: REQUEST_APP_MESSAGE_SUCCESS,
    result,
  };
}

export function requestAppMessageFailure(message) {
  return {
    type: REQUEST_APP_MESSAGE_FAILURE,
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

export function requestAppMessage(messageId) {
  return (dispatch) => {
    fetchMessage(messageId)
    .then(response => response.json())
    .then(response => dispatch(requestAppMessageSuccess(response)))
    .catch(err => dispatch(requestAppMessageFailure(err.message)));
  };
}
