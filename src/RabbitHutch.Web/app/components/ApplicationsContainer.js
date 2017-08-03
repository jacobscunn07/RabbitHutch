import React from 'react';
import { connect } from 'react-redux';
import Applications from './Applications';
import requestSwitchApp from './../redux/application/actions';

class ApplicationsContainer extends React.Component {
  componentWillMount() {
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
    requestSwitchApp: () => dispatch(requestSwitchApp('localhost1')),
  };
}

ApplicationsContainer.propTypes = {
};

export default connect(mapStateToProps, mapDispatchToProps)(ApplicationsContainer);
