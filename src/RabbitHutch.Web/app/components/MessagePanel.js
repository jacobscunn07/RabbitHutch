import React, { PropTypes } from 'react';
import {
  Tag,
  Tags } from './common';
// import { Route } from 'react-router-dom';

const MessagePanel = ({ message }) => (
  <a className="panel-block">
    <div className="field is-grouped">
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Message Id</Tag>
          <Tag className="is-primary">{message.MessageId}</Tag>
        </Tags>
      </div>
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Endpoint</Tag>
          <Tag className="is-info">{message.ProcessedEndpoint}</Tag>
        </Tags>
      </div>
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Class Type</Tag>
          <Tag className="is-success">RecordMessage</Tag>
        </Tags>
      </div>
      {
        message.IsError &&
        <div className="control">
          <Tags>
            <Tag className="is-danger">ERROR</Tag>
          </Tags>
        </div>
      }
    </div>
  </a>
);

MessagePanel.propTypes = {
  message: PropTypes.shape({}).isRequired,
};

export default MessagePanel;
