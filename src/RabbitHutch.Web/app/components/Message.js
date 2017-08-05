import React, { PropTypes } from 'react';

const Message = ({ message }) => (
  <div>
    <div className="field is-horizontal">
      <div className="field-label is-normal">
        <label htmlFor="a" className="label">Message Id</label>
      </div>
      <div className="field-body">
        <div className="field">
          <div className="control">
            <input className="input" type="text" placeholder="Normal sized input" value={message.MessageId} disabled />
          </div>
        </div>
      </div>
    </div>
  </div>
);

Message.propTypes = {
  message: PropTypes.shape({}),
};

Message.defaultProps = {
  message: {},
};

export default Message;
