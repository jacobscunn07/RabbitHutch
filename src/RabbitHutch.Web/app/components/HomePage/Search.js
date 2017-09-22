import React from 'react';
import PropTypes from 'prop-types';

const Search = ({ onSearchClick }) => (
  <div className="field has-addons">
    <div className="control is-expanded">
      <input
        className="input"
        type="text"
        placeholder="Search..."
      />
    </div>
    <div className="control">
      <button className="button is-primary" type="submit" onClick={onSearchClick}>
        Search
      </button>
    </div>
  </div>
);

Search.propTypes = {
  onSearchClick: PropTypes.func.isRequired,
};

Search.defaultProps = {
};

export default Search;
