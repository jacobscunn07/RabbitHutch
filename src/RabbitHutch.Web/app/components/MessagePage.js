import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Message from './Message';
import {
  Column,
  Columns,
  Container } from './common';
import { requestSwitchApp, requestAppMessages } from './../redux/application/actions';

class MessagePage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      message: {
        serviceBusTechnology: '',
        body: '',
        headers: [],
      },
    };
  }

  componentWillMount() {
    fetch(`/api/message?guid=${this.props.match.params.id}`, {
      method: 'GET',
    })
    .then(response => response.json())
    .then(json => this.setState({ message: json }));
  }

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-12">
            <Message message={this.state.message} />
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

MessagePage.propTypes = {
  match: PropTypes.shape({
    params: PropTypes.shape({
      id: PropTypes.string.isRequired,
    }).isRequired,
  }).isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(MessagePage);