import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import Headers from './Headers';
import Replays from './Replays';
import StackTrace from './StackTrace';
import Body from './Body';
import {
  PanelBlock,
} from './../common';

const Message = ({ message, replayMessage, currentTab, tabOnClick }) => (
  <nav className="panel">
    <p className="panel-heading">
      Message: {message.messageId}
    </p>
    <p className="panel-tabs">
      <a className={classNames({ 'is-active': currentTab === 'stacktrace' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('stacktrace'); }}>stacktrace</a>
      <a className={classNames({ 'is-active': currentTab === 'headers' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('headers'); }}>headers</a>
      <a className={classNames({ 'is-active': currentTab === 'body' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('body'); }}>body</a>
      <a className={classNames({ 'is-active': currentTab === 'replays' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('replays'); }}>replays</a>
    </p>
    <PanelBlock>
      <button onClick={() => { replayMessage(message.documentId); }} className="button is-primary is-outlined is-fullwidth">
        replay
      </button>
    </PanelBlock>
    {currentTab === 'stacktrace' && <StackTrace stackTrace={message.stackTrace} />}
    {currentTab === 'headers' && <Headers headers={message.headers} />}
    {currentTab === 'body' && <Body body={message.body} />}
    {currentTab === 'replays' && <Replays replays={message.replays} />}
    <PanelBlock>
      <button onClick={() => { replayMessage(message.documentId); }} className="button is-primary is-outlined is-fullwidth">
        replay
      </button>
    </PanelBlock>
  </nav>
);

Message.propTypes = {
  message: PropTypes.shape({
    documentId: PropTypes.number,
    serviceBusTechnology: PropTypes.string,
    body: PropTypes.string,
    headers: PropTypes.arrayOf(PropTypes.object),
  }).isRequired,
  replayMessage: PropTypes.func.isRequired,
  currentTab: PropTypes.string.isRequired,
  tabOnClick: PropTypes.func.isRequired,
};

export default Message;
