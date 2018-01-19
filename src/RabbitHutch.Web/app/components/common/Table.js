import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const Table = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames(className, 'table', 'is-striped', 'is-hoverable', 'is-fullwidth');
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

Table.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

Table.defaultProps = {
  children: '',
  tag: 'table',
  className: '',
};

export default Table;
