import React, { PropTypes } from 'react';
import moment from 'moment';
import {
  PanelBlock,
} from './../common';

const Replays = ({ replays }) => (
  <div>
    {
      replays && replays.map(replay => (
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
  </div>
);

Replays.propTypes = {
  replays: PropTypes.arrayOf(PropTypes.object).isRequired,
};

export default Replays;
