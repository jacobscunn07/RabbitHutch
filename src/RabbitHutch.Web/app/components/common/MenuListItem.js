import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const MenuListItem = (props) => {
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

MenuListItem.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

MenuListItem.defaultProps = {
  children: '',
  tag: 'li',
  className: '',
};

export default MenuListItem;
