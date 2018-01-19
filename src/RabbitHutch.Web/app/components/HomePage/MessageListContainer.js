import React from 'react';
import PropTypes from 'prop-types';
import MessageList from './MessageList';
import { Paginate } from './../common';

class MessageListContainer extends React.Component {
  render() {
    return (
      <div>
        <MessageList {...this.props} />
        <Paginate
          pageCount={this.props.messages.length / this.state.messagesPerPage}
          initialPage={this.state.currentPage}
          onPageChange={this.onPageChange}
        />
      </div>);
  }
}

MessageListContainer.propTypes = {
  messages: PropTypes.shape({
    length: PropTypes.number,
  }),
};

MessageListContainer.defaultProps = {
  messages: [],
};

export default MessageListContainer;
