import React from 'react';
import {
  Container,
  Hero,
  HeroBody } from './common';
// import { Route } from 'react-router-dom';

const Header = () => (
  <Hero className="is-primary">
    <HeroBody>
      <Container>
        <h1 className="title">
          Rabbit Hutch
        </h1>
        <h2 className="subtitle">
          Where the fluffsters can run free
        </h2>
      </Container>
    </HeroBody>
  </Hero>
);

export default Header;
