import React, { PropTypes } from 'react';
import classNames from 'classnames';

const Tabs = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('tabs', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Tabs.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Tabs.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default Tabs;
