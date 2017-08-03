import { REQUEST_SWITCH_APP } from './constants';

export default function requestSwitchApp(applicationId) {
  return {
    type: REQUEST_SWITCH_APP,
    applicationId,
  };
}
