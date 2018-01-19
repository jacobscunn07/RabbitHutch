import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TableRow = (props) => {
  const {
      tag: Tag,
      className,
      onClick,
    } = props;
  const classes = classNames(className);
  return (
    <Tag className={classes} onClick={onClick}>
      {props.children}
    </Tag>
  );
};

TableRow.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
  onClick: PropTypes.func,
};

TableRow.defaultProps = {
  children: '',
  tag: 'tr',
  className: '',
  onClick: () => {},
};

export default TableRow;
