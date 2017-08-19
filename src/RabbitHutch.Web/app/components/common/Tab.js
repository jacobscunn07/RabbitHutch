import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Tab = (props) => {
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

Tab.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Tab.defaultProps = {
  children: '',
  tag: 'li',
  className: '',
};

export default Tab;
