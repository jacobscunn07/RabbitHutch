import React, { PropTypes } from 'react';

const Message = props => (
  <div>
    <div className="field">
      <label htmlFor="a" className="label">Service Bus</label>
      <div className="control">
        <input className="input" type="text" placeholder="Normal sized input" value={props.message.serviceBusTechnology} disabled />
      </div>
    </div>

    <div className="field">
      <label htmlFor="a" className="label">Body</label>
      <div className="control">
        <textarea className="textarea" type="text" placeholder="Disabled textarea" value={props.message.body} disabled />
      </div>
    </div>

    {
      props.message.headers &&
      props.message.headers.map(header => (
        <div className="field" key={header.key}>
          <label htmlFor="a" className="label">{header.key}</label>
          <div className="control">
            <input className="input" type="text" placeholder="Normal sized input" value={header.value} disabled />
          </div>
        </div>
      ))
    }

    <div className="field is-grouped">
      <p className="control">
        <a className="button is-primary">
          Replay
        </a>
      </p>
      <p className="control">
        <a className="button">
          Back
        </a>
      </p>
    </div>
  </div>
);

Message.propTypes = {
  message: PropTypes.shape({
    serviceBusTechnology: PropTypes.string,
    body: PropTypes.string,
    headers: PropTypes.arrayOf(PropTypes.object),
  }).isRequired,
};

export default Message;
