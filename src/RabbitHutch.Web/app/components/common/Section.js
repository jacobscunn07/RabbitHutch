import React, { PropTypes } from 'react';

const Section = (props) => {
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
