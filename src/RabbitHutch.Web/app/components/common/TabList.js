import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const TabList = (props) => {
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

TabList.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

TabList.defaultProps = {
  children: '',
  tag: 'ul',
  className: '',
};

export default TabList;
