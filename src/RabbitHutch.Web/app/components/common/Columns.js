import React, { PropTypes } from 'react';

const Columns = (props) => {
  const {
      tag: Tag,
    } = props;
  const classes = 'columns';
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Columns.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
};

Columns.defaultProps = {
  children: '',
  tag: 'div',
};

export default Columns;
