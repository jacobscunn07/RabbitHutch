import React, { PropTypes } from 'react';
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
      <MenuListItem><a className={classNames({ 'is-active': props.applicationId === 'localhost' })}>localhost <span className="tag is-danger is-rounded is-pulled-right">5,499</span></a></MenuListItem>
      <MenuListItem><a href="#a" role="button" onClick={props.requestSwitchApp} className={classNames({ 'is-active': props.applicationId === 'localhost1' })}>localhost1 <span className="tag is-danger is-rounded is-pulled-right">7</span></a></MenuListItem>
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
