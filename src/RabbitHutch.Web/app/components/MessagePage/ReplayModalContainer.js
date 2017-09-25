import React from 'react';
import { connect } from 'react-redux';
import ReplayModal from './ReplayModal';

class MessageListContainer extends React.Component {
  componentWillMount() {
  }

  render() {
    return (<ReplayModal />);
  }
}

function mapStateToProps() {
  return {
  };
}

function mapDispatchToProps() {
  return {
  };
}

MessageListContainer.propTypes = {
};

export default connect(mapStateToProps, mapDispatchToProps)(MessageListContainer);
