import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import MessageListContainer from './MessageListContainer';
import SearchContainer from './SearchContainer';
import {
  Column,
  Columns,
  Container } from './../common';
import { requestSwitchApp, requestAppMessages } from './../../redux/application/actions';

class HomePage extends React.Component {
  componentDidMount() {
    this.props.requestApplicationMessages();
  }

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-12">
            <SearchContainer />
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
