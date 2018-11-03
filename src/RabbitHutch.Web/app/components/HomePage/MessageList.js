import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import {
  Table,
  TableBody,
  TableCell,
  TableCellHeading,
  TableHeading,
  TableRow,
  Tags,
  Tag } from './../common';

const MessageList = ({ messages, onRowClick }) => (
  <Table>
    <TableHeading>
      <TableRow>
        <TableCellHeading />
        <TableCellHeading>Message Id</TableCellHeading>
        <TableCellHeading>Processed Endpoint</TableCellHeading>
        <TableCellHeading>Message Type</TableCellHeading>
        <TableCellHeading>Processed Date Time</TableCellHeading>
      </TableRow>
    </TableHeading>
    <TableBody>
      {
      messages.map(message =>
        (<TableRow className="pointer" onClick={() => { onRowClick(message.messageId); }} key={message.messageId}>
          <TableCell>
            {
              message.isError &&
              <div className="control">
                <Tags>
                  <Tag className="is-danger">ERROR</Tag>
                </Tags>
              </div>
            }
            {
              !message.isError &&
              <div className="control">
                <Tags>
                  <Tag className="is-success">SUCCESS</Tag>
                </Tags>
              </div>
            }
          </TableCell>
          <TableCell>{message.messageId}</TableCell>
          <TableCell>{message.processedEndpoint}</TableCell>
          <TableCell>{message.classType}</TableCell>
          <TableCell>{moment(message.processedDateTime).format('MM/DD/YY h:mm:ss a')}</TableCell>
        </TableRow>),
      )
    }
    </TableBody>
  </Table>
);

MessageList.propTypes = {
  messages: PropTypes.arrayOf(PropTypes.shape({})),
  onRowClick: PropTypes.func.isRequired,
};

MessageList.defaultProps = {
  messages: [],
};

export default MessageList;
