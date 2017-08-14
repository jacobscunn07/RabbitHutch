import React, { PropTypes } from 'react';
import {
  PanelBlock,
} from './../common';

const Body = ({ body }) => (
  <div>
    {
      <PanelBlock>
        <div className="content">
          <strong>{body}</strong>
        </div>
      </PanelBlock>
    }
  </div>
);

Body.propTypes = {
  body: PropTypes.string.isRequired,
};

export default Body;
