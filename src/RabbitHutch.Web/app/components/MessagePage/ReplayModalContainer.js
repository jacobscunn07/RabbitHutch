import React from 'react';
import { connect } from 'react-redux';
import ReplayModal from './ReplayModal';

class MessageListContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      modalActive: false,
    };
  }

  submit = () => {
    alert('Implement Me!');
  }

  cancel = () => {
    this.setState({
      modalActive: false,
    });
  }

  render() {
    return (<ReplayModal
      isActive={this.state.modalActive}
      submit={this.submit}
      cancel={this.cancel}
    />);
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
