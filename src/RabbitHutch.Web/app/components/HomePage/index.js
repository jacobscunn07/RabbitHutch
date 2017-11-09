import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import MessageList from './MessageList';
import {
  Column,
  Columns,
  Container,
  Paginate } from './../common';

class HomePage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      query: '',
      totalMessagesMatchingQuery: 0,
      messages: [],
      messagesPerPage: 10,
      currentPage: 0,
    };
  }

  componentDidMount() {
    fetch(`/api/search?query=${this.state.query}`, {
      method: 'GET',
    })
    .then(response => response.json())
    .then(response => this.setState({messages: response.results, totalMessagesMatchingQuery: response.totalResults}))
    .catch(err => console.log(err));
  }

  onPageChange = (p) => {
    this.setState({currentPage: p.selected});
  };

  render() {
    return (
      <Container>
        <Columns>
          <Column className="is-12">
            <MessageList messages={this.state.messages} />
            <Paginate
              pageCount={this.state.messages.length/this.state.messagesPerPage}
              initialPage={this.state.currentPage}
              onPageChange={this.onPageChange}
            />
          </Column>
        </Columns>
      </Container>);
  }
}

HomePage.propTypes = {
};

export default HomePage;
