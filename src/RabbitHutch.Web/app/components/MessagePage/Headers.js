import React, { PropTypes } from 'react';
import {
  PanelBlock,
} from './../common';

const Headers = ({ headers }) => (
  <div>
    {
      headers && headers.map(header => (
        <PanelBlock key={header.key}>
          <div className="content">
            <strong>{header.key}</strong>
            <p>{header.value}</p>
          </div>
        </PanelBlock>
      ))
    }
  </div>
);

Headers.propTypes = {
  headers: PropTypes.arrayOf(PropTypes.object).isRequired,
};

export default Headers;
