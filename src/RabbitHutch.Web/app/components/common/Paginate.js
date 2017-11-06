import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import ReactPaginate from 'react-paginate';

const Paginate = (props) => {
  const {
      className,
    } = props;
  const classes = classNames(className);
  return (
    <nav className="pagination is-centered" role="navigation" aria-label="pagination">
      <ReactPaginate className={classes}
        previousLabel={"previous"}
        nextLabel={"next"}
        breakLabel={<span className="pagination-ellipsis">&hellip;</span>}
        pageCount={100}
        marginPagesDisplay={2}
        pageRangeDisplay={5}
        containerClassName={"pagination-list"}
        activeLinkClassName={"is-current"}
        nextLinkClassName={"pagination-next"}
        previousLinkClassName={"pagination-previous"}
        pageLinkClassName={"pagination-link"}
        initialPage={1}
      />
    </nav>
  );
};

Paginate.propTypes = {
  className: PropTypes.string,
};

Paginate.defaultProps = {
  className: '',
};

export default Paginate;
