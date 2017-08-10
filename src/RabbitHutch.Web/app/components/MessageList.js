import React, { PropTypes } from 'react';
import {
  Tab,
  TabList,
  Tabs } from './common';
import MessagePanel from './MessagePanel';
// import { Route } from 'react-router-dom';

const MessageList = ({ messages }) => (
  <div>
    <div className="field has-addons">
      <div className="control is-expanded">
        <input
          className="input"
          type="text"
          placeholder="Search..."
        />
      </div>
      <div className="control">
        <a className="button is-primary">
          Search
        </a>
      </div>
    </div>
    <Tabs className="is-boxed is-marginless">
      <TabList>
        <Tab className="is-active">
          <a><span>All</span></a>
        </Tab>
        <Tab>
          <a><span>Audit</span></a>
        </Tab>
        <Tab>
          <a><span>Error</span></a>
        </Tab>
      </TabList>
    </Tabs>
    <nav className="panel">
      {
        messages.map(message => <MessagePanel key={message.docId} message={message} />)
      }
    </nav>
  </div>
);

MessageList.propTypes = {
  messages: PropTypes.arrayOf(PropTypes.shape({})),
};

MessageList.defaultProps = {
  messages: [],
};

export default MessageList;
