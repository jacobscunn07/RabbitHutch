import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Applications from './Applications';
import { requestSwitchApp, requestAppMessages } from './../redux/application/actions';

class ApplicationsContainer extends React.Component {
  componentWillMount() {
    this.props.requestApplicationMessages();
  }

  render() {
    return (<Applications {...this.props} />);
  }
}

function mapStateToProps(state) {
  return { applicationId: state.applications.get('applicationId') };
}

function mapDispatchToProps(dispatch) {
  return {
    requestApplicationMessages: () => dispatch(requestAppMessages()),
    requestSwitchApp: appId => dispatch(requestSwitchApp(appId)),
  };
}

ApplicationsContainer.propTypes = {
  requestApplicationMessages: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ApplicationsContainer);
