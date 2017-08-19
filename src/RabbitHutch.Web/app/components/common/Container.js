import React from 'react';
import PropTypes from 'prop-types';

const Container = (props) => {
  const {
      tag: Tag,
    } = props;
  const classes = 'container';
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Container.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
};

Container.defaultProps = {
  children: '',
  tag: 'div',
};

export default Container;
