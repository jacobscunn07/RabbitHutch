import React, { PropTypes } from 'react';

const Message = props => (
  <div>
    <div className="field is-horizontal">
      <div className="field-label is-normal">
        <label htmlFor="a" className="label">Service Bus</label>
      </div>
      <div className="field-body">
        <div className="field">
          <div className="control">
            <input className="input" type="text" placeholder="Normal sized input" value={props.message.serviceBusTechnology} disabled />
          </div>
        </div>
      </div>
    </div>
  </div>
);

Message.propTypes = {
  message: PropTypes.shape({
    serviceBusTechnology: PropTypes.string,
  }).isRequired,
};

export default Message;
