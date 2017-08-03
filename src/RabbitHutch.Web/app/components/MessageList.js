import React from 'react';
import {
  Tab,
  TabList,
  Tabs,
  Tag,
  Tags } from './common';
// import { Route } from 'react-router-dom';

const MessageList = () => (
  <div>
    <Tabs className="is-boxed is-marginless">
      <TabList>
        <Tab className="is-active">
          <a><span>Error</span></a>
        </Tab>
        <Tab>
          <a><span>Audit</span></a>
        </Tab>
        <Tab>
          <a><span>All</span></a>
        </Tab>
      </TabList>
    </Tabs>
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
  </div>
);

export default MessageList;
