import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const HeroBody = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('hero-body', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

HeroBody.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

HeroBody.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default HeroBody;
