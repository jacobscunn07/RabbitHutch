import React, { PropTypes } from 'react';
import Headers from './Headers';
import Replays from './Replays';
import StackTrace from './StackTrace';
import {
  PanelBlock,
} from './../common';

const Message = ({ message, replayMessage }) => (
  <nav className="panel">
    <p className="panel-heading">
      Message: {message.messageId}
    </p>
    <p className="panel-tabs">
      <a>stacktrace</a>
      <a className="is-active">headers</a>
      <a>body</a>
      <a>replays</a>
    </p>
    <PanelBlock>
      <button onClick={() => { replayMessage(message.documentId); }} className="button is-primary is-outlined is-fullwidth">
        replay
      </button>
    </PanelBlock>
    <StackTrace stackTrace={message.stackTrace} />
    <Replays replays={message.replays} />
    <Headers headers={message.headers} />
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
};

export default Message;
