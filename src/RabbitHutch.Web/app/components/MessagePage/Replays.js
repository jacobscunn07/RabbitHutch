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
            <strong>{replay.messageId}</strong>
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
