import React, { PropTypes } from 'react';
import { Link } from 'react-router-dom';
import {
  Tag,
  Tags } from './common';
// import { Route } from 'react-router-dom';

const MessagePanel = ({ message }) => (
  <Link className="panel-block" to={{ pathname: `/message/${message.MessageId}` }}>
    <div className="field is-grouped is-grouped-multiline">
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Message Id</Tag>
          <Tag className="is-warning">{message.MessageId}</Tag>
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
          <Tag className="is-success">{message.ClassType}</Tag>
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
  </Link>
);

MessagePanel.propTypes = {
  message: PropTypes.shape({}).isRequired,
};

export default MessagePanel;
