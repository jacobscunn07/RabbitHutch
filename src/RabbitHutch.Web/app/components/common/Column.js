import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Column = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('column', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Column.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Column.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default Column;
