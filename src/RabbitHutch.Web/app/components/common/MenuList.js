import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const MenuList = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('menu-list', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

MenuList.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

MenuList.defaultProps = {
  children: '',
  tag: 'ul',
  className: '',
};

export default MenuList;
