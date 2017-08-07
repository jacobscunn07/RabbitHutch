import React from 'react';
import { Link } from 'react-router-dom';
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
    <div className="hero-foot">
      <nav className="tabs">
        <div className="container">
          <ul>
            <li className="is-active"><Link to={{ pathname: '/' }}>Home</Link></li>
          </ul>
        </div>
      </nav>
    </div>
  </Hero>
);

export default Header;
