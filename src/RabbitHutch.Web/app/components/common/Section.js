import React, { PropTypes } from 'react';
import classNames from 'classnames';

const Section = (props) => {
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

Section.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Section.defaultProps = {
  children: '',
  tag: 'section',
  className: '',
};

export default Section;
