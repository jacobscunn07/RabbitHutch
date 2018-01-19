import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TableHeading = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames(className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

TableHeading.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

TableHeading.defaultProps = {
  children: '',
  tag: 'thead',
  className: '',
};

export default TableHeading;
