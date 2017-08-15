import React, { PropTypes } from 'react';
import {
  PanelBlock,
} from './../common';

const Replays = ({ replays }) => (
  <div>
    {
      replays && replays.map(replay => (
        <PanelBlock>
          <div className="content">
            {
              (!replay.isError &&
              <span className="tag is-success">Success</span>) ||
              <span className="tag is-danger">Error</span>
            }
            <strong>{replay.replayDateTime}</strong>
          </div>
        </PanelBlock>
      ))
    }
  </div>
);

Replays.propTypes = {
  replays: PropTypes.arrayOf(PropTypes.object).isRequired,
};

export default Replays;
