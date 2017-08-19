import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Tag = (props) => {
  const {
      tag: T,
      className,
    } = props;
  const classes = classNames('tag', className);
  return (
    <T className={classes}>
      {props.children}
    </T>
  );
};

Tag.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Tag.defaultProps = {
  children: '',
  tag: 'span',
  className: '',
};

export default Tag;
