import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Message from './Message';
import ReplayModal from './ReplayModal';
import {
  Column,
  Columns,
  Container } from './../common';
import { requestSwitchMessageTab } from './../../redux/application/actions';

class MessagePage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      message: {
        stackTrace: '',
        serviceBusTechnology: '',
        body: '',
        headers: [],
        replays: [],
      },
      modalActive: false,
    };
  }

  componentWillMount() {
    fetch(`/api/message?id=${this.props.match.params.id}`, {
      method: 'GET',
    })
    .then(response => response.json())
    .then(json => this.setState({ message: json }));
  }

  replayMessage = (docId) => {
    fetch(`/api/replay?docId=${docId}`, {
      method: 'POST',
    })
    .then(response => response.json());
  }

  openModal = () => {
    this.setState({
      modalActive: true,
    });
  }

  submit = () => {
    this.replayMessage(this.state.message.documentId);
    this.setState({
      modalActive: false,
    });
  }

  cancel = () => {
    this.setState({
      modalActive: false,
    });
  }

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-12">
            <ReplayModal
              isActive={this.state.modalActive}
              submit={this.submit}
              cancel={this.cancel}
            />
            <Message
              message={this.state.message}
              replayButtonClick={this.openModal}
              currentTab={this.props.currentTab}
              tabOnClick={this.props.requestSwitchMessageTab}
            />
          </Column>
        </Columns>
      </Container>);
  }
}

function mapStateToProps(state) {
  return {
    currentTab: state.applications.get('messageTab'),
    message: state.applications.get('messages'),
  };
}

function mapDispatchToProps(dispatch) {
  return {
    requestSwitchMessageTab: tab => dispatch(requestSwitchMessageTab(tab)),
  };
}

MessagePage.propTypes = {
  match: PropTypes.shape({
    params: PropTypes.shape({
      id: PropTypes.string.isRequired,
    }).isRequired,
  }).isRequired,
  currentTab: PropTypes.string.isRequired,
  requestSwitchMessageTab: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(MessagePage);
