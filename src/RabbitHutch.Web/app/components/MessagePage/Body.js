import React from 'react';
import PropTypes from 'prop-types';
import ReactJson from 'react-json-view';
import {
  PanelBlock,
} from './../common';

const Body = ({ body }) => (
  <div>
    <PanelBlock>
      <div className="content">
        <strong>Body</strong>
        <ReactJson src={JSON.parse(body)} name={false} />
      </div>
    </PanelBlock>
  </div>
);

Body.propTypes = {
  body: PropTypes.string.isRequired,
};

export default Body;
