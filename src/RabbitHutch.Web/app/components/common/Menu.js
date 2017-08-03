import React, { PropTypes } from 'react';
import classNames from 'classnames';

const Menu = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('menu', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Menu.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Menu.defaultProps = {
  children: '',
  tag: 'aside',
  className: '',
};

export default Menu;
