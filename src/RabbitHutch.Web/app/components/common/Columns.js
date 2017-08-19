import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Columns = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('columns', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Columns.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Columns.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default Columns;
