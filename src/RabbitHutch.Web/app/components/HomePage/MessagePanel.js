import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import {
  Tag,
  Tags } from './../common';
// import { Route } from 'react-router-dom';

const MessagePanel = ({ message }) => (
  <Link className="panel-block" to={{ pathname: `/message/${message.docId}` }}>
    <div className="field is-grouped is-grouped-multiline">
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Message Id</Tag>
          <Tag className="is-warning">{message.messageId}</Tag>
        </Tags>
      </div>
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Endpoint</Tag>
          <Tag className="is-info">{message.processedEndpoint}</Tag>
        </Tags>
      </div>
      <div className="control">
        <Tags className="has-addons">
          <Tag className="is-dark">Class Type</Tag>
          <Tag className="is-success">{message.classType}</Tag>
        </Tags>
      </div>
      {
        message.isError &&
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
