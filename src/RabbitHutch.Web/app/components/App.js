import React from 'react';
import Header from './Header';
// import Applications from './Applications';
import ApplicationsContainer from './ApplicationsContainer';
import MessageList from './MessageList';
import {
  Column,
  Columns,
  Container,
  Section } from './common';
// import { Route } from 'react-router-dom';

const App = () => (
  <div>
    <Header />
    <section style={{ marginTop: '10px' }} />
    <Section>
      <Container>
        <Columns>
          <Column className="is-3">
            <ApplicationsContainer />
          </Column>
          <Column className="is-9">
            <MessageList />
          </Column>
        </Columns>
      </Container>
    </Section>
  </div>
);

export default App;
