import React, { PropTypes } from 'react';
import classNames from 'classnames';

const Tags = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('tags', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Tags.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Tags.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default Tags;
