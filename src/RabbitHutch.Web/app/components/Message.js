import React, { PropTypes } from 'react';

const Message = ({ message, replayMessage }) => (
  <div>
    <div className="field">
      <label htmlFor="a" className="label">Service Bus</label>
      <div className="control">
        <input className="input" type="text" placeholder="Normal sized input" value={message.serviceBusTechnology} disabled />
      </div>
    </div>

    <div className="field">
      <label htmlFor="a" className="label">Body</label>
      <div className="control">
        <textarea className="textarea" type="text" placeholder="Disabled textarea" value={message.body} disabled />
      </div>
    </div>

    {
      message.headers &&
      message.headers.map(header => (
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
        <a href="#a" role="button" onClick={(e) => { e.preventDefault(); replayMessage(message.documentId); }} className="button is-primary">
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
    documentId: PropTypes.number,
    serviceBusTechnology: PropTypes.string,
    body: PropTypes.string,
    headers: PropTypes.arrayOf(PropTypes.object),
  }).isRequired,
  replayMessage: PropTypes.func.isRequired,
};

export default Message;
