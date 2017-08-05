import React from 'react';
import { connect } from 'react-redux';
import MessageList from './MessageList';

class MessageListContainer extends React.Component {
  componentWillMount() {
  }

  render() {
    return (<MessageList {...this.props} />);
  }
}

function mapStateToProps(state) {
  return { messages: state.applications.get('messages', []) };
}

function mapDispatchToProps() {
  return {
  };
}

MessageListContainer.propTypes = {
};

export default connect(mapStateToProps, mapDispatchToProps)(MessageListContainer);
