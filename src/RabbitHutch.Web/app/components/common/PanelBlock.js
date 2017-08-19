import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

const PanelBlock = (props) => {
  const {
      tag: Tag,
      className,
    } = props;
  const classes = classNames('panel-block', className);
  return (
    <Tag className={classes}>
      {props.children}
    </Tag>
  );
};

PanelBlock.propTypes = {
  children: PropTypes.node,
  tag: PropTypes.string,
  className: PropTypes.string,
};

PanelBlock.defaultProps = {
  children: '',
  tag: 'div',
  className: '',
};

export default PanelBlock;
