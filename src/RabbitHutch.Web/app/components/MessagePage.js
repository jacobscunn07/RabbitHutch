import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Message from './Message';
import {
  Column,
  Columns,
  Container } from './common';
import { requestSwitchApp, requestAppMessages } from './../redux/application/actions';

class HomePage extends React.Component {
  componentWillMount() {
  }

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-12">
            <Message />
          </Column>
        </Columns>
      </Container>);
  }
}

function mapStateToProps(state) {
  return { message: state.applications.get('messages') };
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
