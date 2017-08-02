import React, { PropTypes } from 'react';

const Column = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  return (
    <Tag className={className}>
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
