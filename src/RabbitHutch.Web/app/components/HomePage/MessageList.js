import React from 'react';
import PropTypes from 'prop-types';
import {
  Table,
  TableBody,
  TableCell,
  TableCellHeading,
  TableHeading,
  TableRow,
  // Tab,
  // TabList,
  // Tabs,
  Tags,
  Tag } from './../common';

const MessageList = ({ messages, onRowClick }) => (
  <div>
    {
      // <Tabs className="is-boxed is-marginless">
      //   <TabList>
      //     <Tab className="is-active">
      //       <a><span>All</span></a>
      //     </Tab>
      //     <Tab>
      //       <a><span>Audit</span></a>
      //     </Tab>
      //     <Tab>
      //       <a><span>Error</span></a>
      //     </Tab>
      //   </TabList>
      // </Tabs>
    }
    <Table>
      <TableHeading>
        <TableRow>
          <TableCellHeading />
          <TableCellHeading>Message Id</TableCellHeading>
          <TableCellHeading>Originating Endpoint</TableCellHeading>
          <TableCellHeading>Processed Endpoint</TableCellHeading>
          <TableCellHeading>Message Type</TableCellHeading>
        </TableRow>
      </TableHeading>
      <TableBody>
        {
        messages.map(message =>
          (<TableRow className="pointer" onClick={() => { onRowClick(message.docId); }} key={message.messageId}>
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
            <TableCell>{message.originatingEndpoint}</TableCell>
            <TableCell>{message.processedEndpoint}</TableCell>
            <TableCell>{message.classType}</TableCell>
          </TableRow>),
        )
      }
      </TableBody>
    </Table>
  </div>
);

MessageList.propTypes = {
  messages: PropTypes.arrayOf(PropTypes.shape({})),
  onRowClick: PropTypes.func.isRequired,
};

MessageList.defaultProps = {
  messages: [],
};

export default MessageList;
