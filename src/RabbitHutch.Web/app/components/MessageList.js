import React, { PropTypes } from 'react';
import {
  Tab,
  TabList,
  Tabs } from './common';
import MessagePanel from './MessagePanel';
// import { Route } from 'react-router-dom';

const MessageList = ({ messages }) => (
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
      {
        messages.map(message => <MessagePanel key={message.DocId} message={message} />)
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
