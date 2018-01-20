import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import ReactPaginate from 'react-paginate';

const Paginate = (props) => {
  const {
      className,
      pageCount,
      initialPage,
      onPageChange,
    } = props;
  const classes = classNames(className);
  return (
    <nav className="pagination is-centered" aria-label="pagination">
      <ReactPaginate
        className={classes}
        previousLabel={'previous'}
        nextLabel={'next'}
        breakLabel={<span className="pagination-ellipsis">&hellip;</span>}
        pageCount={pageCount}
        marginPagesDisplay={2}
        pageRangeDisplay={5}
        containerClassName={'pagination-list'}
        activeClassName={'is-current'}
        nextLinkClassName={'pagination-next'}
        previousLinkClassName={'pagination-previous'}
        pageLinkClassName={'pagination-link'}
        initialPage={initialPage}
        onPageChange={onPageChange}
      />
    </nav>
  );
};

Paginate.propTypes = {
  className: PropTypes.string,
  pageCount: PropTypes.number.isRequired,
  initialPage: PropTypes.number.isRequired,
  onPageChange: PropTypes.func.isRequired,
};

Paginate.defaultProps = {
  className: '',
};

export default Paginate;
