import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Hero = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('hero', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Hero.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Hero.defaultProps = {
  children: '',
  tag: 'section',
  className: '',
};

export default Hero;
