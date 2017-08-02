import React, { PropTypes } from 'react';

const Menu = (props) => {
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
