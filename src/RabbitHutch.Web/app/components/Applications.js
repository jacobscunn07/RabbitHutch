import React from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import {
  Menu,
  MenuLabel,
  MenuList,
  MenuListItem } from './common';
// import { Route } from 'react-router-dom';

const Applications = props => (
  <Menu>
    <MenuLabel>Applications</MenuLabel>
    <MenuList>
      <MenuListItem><a href="#a" role="button" onClick={(e) => { e.preventDefault(); props.requestSwitchApp('localhost'); }} className={classNames({ 'is-active': props.applicationId === 'localhost' })}>localhost <span className="tag is-danger is-rounded is-pulled-right">5,499</span></a></MenuListItem>
      <MenuListItem><a href="#a" role="button" onClick={(e) => { e.preventDefault(); props.requestSwitchApp('localhost1'); }} className={classNames({ 'is-active': props.applicationId === 'localhost1' })}>localhost1 <span className="tag is-danger is-rounded is-pulled-right">7</span></a></MenuListItem>
    </MenuList>
  </Menu>
);

Applications.propTypes = {
  applicationId: PropTypes.string,
  requestSwitchApp: PropTypes.func.isRequired,
};

Applications.defaultProps = {
  applicationId: 'add',
};

export default Applications;
