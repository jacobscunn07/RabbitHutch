import React from 'react';
import { Route } from 'react-router-dom';

const App = () => (
  <div>
    <section className="hero is-primary">
      <div className="hero-body">
        <div className="container">
          <h1 className="title">
            Rabbit Hutch
          </h1>
          <h2 className="subtitle">
            Where the fluffsters can run free
          </h2>
        </div>
      </div>
    </section>
    <section style={{marginTop: '10px'}} />
    <section>
      <div className="container">
        <div className="columns">
          <div className="column is-3">
          <aside className="menu">
            <p className="menu-label">
              Applications
            </p>
            <ul className="menu-list">
              <li><a className="is-active">localhost</a></li>
              <li><a>localhost1</a></li>
            </ul>
            </aside>
          </div>
          <div className="column is-9">
          <div className="tabs is-boxed is-marginless">
            <ul>
              <li className="is-active">
                <a>
                  <span>Error</span>
                </a>
              </li>
              <li>
                <a>
                  <span>Audit</span>
                </a>
              </li>
              <li>
                <a>
                  <span>All</span>
                </a>
              </li>
            </ul>
            </div>
            <nav className="panel">
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-book"></i>
                </span>
                bulma
              </a>
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-book"></i>
                </span>
                marksheet
              </a>
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-book"></i>
                </span>
                minireset.css
              </a>
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-book"></i>
                </span>
                jgthms.github.io
              </a>
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-code-fork"></i>
                </span>
                daniellowtw/infboard
              </a>
              <a className="panel-block">
                <span className="panel-icon">
                  <i className="fa fa-code-fork"></i>
                </span>
                mojs
              </a>
            </nav>
          </div>
        </div>
      </div>
    </section>
  </div>
);

export default App;
