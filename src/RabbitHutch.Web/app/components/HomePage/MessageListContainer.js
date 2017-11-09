import React from 'react';
import { connect } from 'react-redux';
import MessageList from './MessageList';
import { Paginate } from './../common';

class MessageListContainer extends React.Component {
  render() {
    return (
      <div>
        <MessageList {...this.props} />
        <Paginate
          pageCount={this.props.messages.length/this.state.messagesPerPage}
          initialPage={this.state.currentPage}
          onPageChange={this.onPageChange}
        />
      </div>);
  }
}

MessageListContainer.propTypes = {
};

export default MessageListContainer;
