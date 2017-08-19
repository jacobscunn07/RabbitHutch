import React from 'react';
import PropTypes from 'prop-types';
import Header from './Header';
import { Section } from './common';
// import { Route } from 'react-router-dom';

const App = props => (
  <div>
    <Header />
    <section style={{ marginTop: '10px' }} />
    <Section>
      {props.children}
    </Section>
  </div>
);

App.propTypes = {
  children: PropTypes.node,
};

App.defaultProps = {
  children: '',
};

export default App;
