import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import ApplicationsContainer from './ApplicationsContainer';
import MessageListContainer from './MessageListContainer';
import {
  Column,
  Columns,
  Container } from './common';
import { requestSwitchApp, requestAppMessages } from './../redux/application/actions';

class HomePage extends React.Component {
  componentWillMount() {
    this.props.requestApplicationMessages();
  }

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-3">
            <ApplicationsContainer />
          </Column>
          <Column className="is-9">
            <MessageListContainer />
          </Column>
        </Columns>
      </Container>);
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

HomePage.propTypes = {
  requestApplicationMessages: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);
