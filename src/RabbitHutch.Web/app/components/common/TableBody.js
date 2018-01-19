import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TableBody = (props) => {
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

TableBody.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

TableBody.defaultProps = {
  children: '',
  tag: 'tbody',
  className: '',
};

export default TableBody;
