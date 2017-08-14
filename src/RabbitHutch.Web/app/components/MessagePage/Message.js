import React, { PropTypes } from 'react';
import {
  PanelBlock,
} from './../common';

const Message = ({ message, replayMessage }) => (
  <nav className="panel">
    <p className="panel-heading">
      Message: {message.documentId}
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
    {
      message.headers &&
      message.headers.map(header => (
        <PanelBlock key={header.key}>
          <div className="content">
            <strong>{header.key}</strong>
            <p>{header.value}</p>
          </div>
        </PanelBlock>
      ))
    }
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
