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
        body: '{}',
        headers: [],
        replays: [],
      },
      modalActive: false,
      replayBody: {}
    };
  }

  componentWillMount() {
    fetch(`/api/message?id=${this.props.match.params.id}`, {
      method: 'GET',
    })
    .then(response => response.json())
    .then(json => this.setState({ message: json, replayBody: JSON.parse(json.body) }));
  }

  openModal = () => {
    this.setState({
      modalActive: true,
    });
  }

  bodyAdd = (params) => {
    this.setState({replayBody: params.updated_src});
    return true;
  }

  bodyEdit = (params) => {
    this.setState({replayBody: params.updated_src});
    return true;
  }

  bodyDelete = (params) => {
    this.setState({replayBody: params.updated_src});
    return true;
  }

  submit = () => {
    fetch(`/api/replay?docId=${this.state.message.documentId}`, {
      method: 'POST',
    })
    .then(response => response.json())
    .then(() => this.setState({ modalActive: false }));
  }

  cancel = () => {
    this.setState({
      modalActive: false,
      replayBody: JSON.parse(this.state.message.body),
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
              json={this.state.replayBody}
              bodyAdd={this.bodyAdd}
              bodyEdit={this.bodyEdit}
              bodyDelete={this.bodyDelete}
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
