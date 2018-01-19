import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TableCellHeading = (props) => {
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

TableCellHeading.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

TableCellHeading.defaultProps = {
  children: '',
  tag: 'th',
  className: '',
};

export default TableCellHeading;
