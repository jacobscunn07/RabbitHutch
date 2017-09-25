import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const ReplayModal = ({ isActive, submit, cancel }) => (
  <div className={classNames('modal', { 'is-active': isActive })}>
    <div className="modal-background" />
    <div className="modal-card">
      <header className="modal-card-head">
        <p className="modal-card-title">Do you need to make changes before replaying?</p>
        <button className="delete" aria-label="close" onClick={cancel} />
      </header>
      <section className="modal-card-body">
        <p>Editable message body goes here...</p>
      </section>
      <footer className="modal-card-foot">
        <button className="button is-success" onClick={submit}>Replay</button>
        <button className="button" onClick={cancel}>Cancel</button>
      </footer>
    </div>
  </div>
);

ReplayModal.propTypes = {
  isActive: PropTypes.bool.isRequired,
  submit: PropTypes.func.isRequired,
  cancel: PropTypes.func.isRequired,
};

export default ReplayModal;
