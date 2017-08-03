import REQUEST_SWITCH_APP from './actions';

export default function requestActivitySummary(applicationId) {
  return {
    type: REQUEST_SWITCH_APP,
    applicationId,
  };
}
