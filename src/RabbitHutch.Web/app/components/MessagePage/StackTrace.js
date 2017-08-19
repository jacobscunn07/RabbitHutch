import React, { PropTypes } from 'react';
import {
  PanelBlock,
} from './../common';

const StackTrace = ({ stackTrace }) => (
  <div>
    <PanelBlock>
      <div className="content">
        <strong>Stacktrace</strong>
        <p>{stackTrace}</p>
      </div>
    </PanelBlock>
  </div>
);

StackTrace.propTypes = {
  stackTrace: PropTypes.string.isRequired,
};

export default StackTrace;
