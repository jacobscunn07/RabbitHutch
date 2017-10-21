import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import moment from 'moment';
import ReactJson from 'react-json-view';
import {
  PanelBlock,
} from './../common';

const Message = ({ message, replayButtonClick, currentTab, tabOnClick }) => (
  <nav className="panel">
    <p className="panel-heading">
      Message: {message.messageId}
    </p>
    <p className="panel-tabs">
      {message.stackTrace && <a className={classNames({ 'is-active': currentTab === 'stacktrace' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('stacktrace'); }}>stacktrace</a>}
      <a className={classNames({ 'is-active': currentTab === 'headers' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('headers'); }}>headers</a>
      <a className={classNames({ 'is-active': currentTab === 'body' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('body'); }}>body</a>
      {message.replays.length > 0 && <a className={classNames({ 'is-active': currentTab === 'replays' })} href="#a" role="button" onClick={(e) => { e.preventDefault(); tabOnClick('replays'); }}>replays</a>}
    </p>
    <PanelBlock>
      <button onClick={() => { replayButtonClick(message.documentId); }} className="button is-primary is-outlined is-fullwidth">
        replay
      </button>
    </PanelBlock>
    {
      currentTab === 'stacktrace' &&
      <PanelBlock>
        <div className="content">
          <strong>Stacktrace</strong>
          <p>{message.stackTrace}</p>
        </div>
      </PanelBlock>
    }
    {
      currentTab === 'headers' &&
      message.headers.map(header => (
        <PanelBlock key={header.key}>
          <div className="content">
            <strong>{header.key}</strong>
            <p>{header.value}</p>
          </div>
        </PanelBlock>))
    }
    {
      currentTab === 'body' &&
      <PanelBlock>
        <div className="content">
          <ReactJson
            src={JSON.parse(message.body)}
            name={false}
          />
        </div>
      </PanelBlock>
    }
    {
      currentTab === 'replays' &&
      message.replays.map(replay => (
        <PanelBlock key={replay.replayDateTime}>
          <div className="content">
            {
              (!replay.isError &&
              <span className="tag is-success">Success</span>) ||
              <span className="tag is-danger">Error</span>
            }
            <strong>{moment(replay.replayDateTime).format('dddd, MMMM Do YYYY, h:mm:ss a')}</strong>
          </div>
        </PanelBlock>
      ))
    }
    <PanelBlock>
      <button onClick={() => { replayButtonClick(message.documentId); }} className="button is-primary is-outlined is-fullwidth">
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
  replayButtonClick: PropTypes.func.isRequired,
  currentTab: PropTypes.string.isRequired,
  tabOnClick: PropTypes.func.isRequired,
};

export default Message;
