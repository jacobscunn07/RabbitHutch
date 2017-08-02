import React from 'react';
import {
  Column,
  Columns,
  Container,
  Menu,
  MenuLabel,
  MenuList,
  MenuListItem,
  Section,
  Tag,
  Tags } from './common';
// import { Route } from 'react-router-dom';

const App = () => (
  <div>
    <Section className="hero is-primary">
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
    </Section>
    <section style={{ marginTop: '10px' }} />
    <Section>
      <Container>
        <Columns>
          <Column className="column is-3">
            <Menu>
              <MenuLabel>Applications</MenuLabel>
              <MenuList>
                <MenuListItem><a className="is-active">localhost <span className="tag is-danger is-rounded is-pulled-right">5,499</span></a></MenuListItem>
                <MenuListItem><a>localhost1 <span className="tag is-danger is-rounded is-pulled-right">7</span></a></MenuListItem>
              </MenuList>
            </Menu>
          </Column>
          <Column className="column is-9">
            <div className="tabs is-boxed is-marginless">
              <ul>
                <li className="is-active">
                  <a><span>Error</span></a>
                </li>
                <li>
                  <a><span>Audit</span></a>
                </li>
                <li>
                  <a><span>All</span></a>
                </li>
              </ul>
            </div>
            <nav className="panel">
              <a className="panel-block">
                <div className="field is-grouped">
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Document Id</Tag>
                      <Tag className="is-primary">3123</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Endpoint</Tag>
                      <Tag className="is-info">RabbitHutch.Host</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Class Type</Tag>
                      <Tag className="is-success">RecordMessage</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags>
                      <Tag className="is-danger">ERROR</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Replays</Tag>
                      <Tag className="is-warning">0</Tag>
                    </Tags>
                  </div>
                </div>
              </a>
              <a className="panel-block">
                <div className="field is-grouped">
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Document Id</Tag>
                      <Tag className="is-primary">3123</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Endpoint</Tag>
                      <Tag className="is-info">ThisEndpointIsLongerThanExpected</Tag>
                    </Tags>
                  </div>
                  <div className="control">
                    <Tags className="has-addons">
                      <Tag className="is-dark">Class Type</Tag>
                      <Tag className="is-success">RecordMessage</Tag>
                    </Tags>
                  </div>
                </div>
              </a>
              <a className="panel-block">minireset.css</a>
              <a className="panel-block">jgthms.github.io</a>
              <a className="panel-block">daniellowtw/infboard</a>
              <a className="panel-block">mojs</a>
            </nav>
          </Column>
        </Columns>
      </Container>
    </Section>
  </div>
);

export default App;
