import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TableCell = (props) => {
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

TableCell.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

TableCell.defaultProps = {
  children: '',
  tag: 'td',
  className: '',
};

export default TableCell;
