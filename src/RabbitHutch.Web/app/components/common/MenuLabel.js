import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const MenuLabel = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('menu-label', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

MenuLabel.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

MenuLabel.defaultProps = {
  children: '',
  tag: 'p',
  className: '',
};

export default MenuLabel;
