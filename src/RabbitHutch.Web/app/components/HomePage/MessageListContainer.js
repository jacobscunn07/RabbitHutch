import React from 'react';
import { connect } from 'react-redux';
import MessageList from './MessageList';
import { Paginate } from './../common';

class MessageListContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      messagesPerPage: 10,
      currentPage: 0,
    };
  }

  componentDidMount() {
  }

  onPageChange = (p) => {
    this.setState({currentPage: p.selected});
  };

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
