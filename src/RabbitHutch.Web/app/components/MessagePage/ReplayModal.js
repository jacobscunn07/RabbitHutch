import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import ReactJson from 'react-json-view';

const ReplayModal = ({ isActive, submit, cancel, json, bodyAdd, bodyEdit, bodyDelete }) => (
  <div className={classNames('modal', { 'is-active': isActive })}>
    <div className="modal-background" />
    <div className="modal-card">
      <header className="modal-card-head">
        <p className="modal-card-title">Do you need to make changes before replaying?</p>
        <button className="delete" aria-label="close" onClick={cancel} />
      </header>
      <section className="modal-card-body">
        <ReactJson
          src={json}
          name={false}
          onEdit={bodyEdit}
          onAdd={bodyAdd}
          onDelete={bodyDelete}
        />
      </section>
      <footer className="modal-card-foot">
        <button className="button is-primary" onClick={submit}>Replay</button>
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
