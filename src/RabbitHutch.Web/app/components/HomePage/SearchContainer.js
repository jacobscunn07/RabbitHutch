import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Search from './Search';
import { requestAppMessages } from './../../redux/application/actions';

class SearchContainer extends React.Component {
  constructor(props) {
    super(props);
    this.searchElement = '';
  }

  componentWillMount() {
  }

  searchAppMessages = () => {
    const val = this.searchElement.value;
    this.props.requestApplicationMessages(val);
  }

  render() {
    return (<Search
      onSearchClick={this.searchAppMessages}
      searchValueRef={(el) => { this.searchElement = el; }}
    />);
  }
}

function mapStateToProps() {
  return {
  };
}

function mapDispatchToProps(dispatch) {
  return {
    requestApplicationMessages: query => dispatch(requestAppMessages(query)),
  };
}

SearchContainer.propTypes = {
  requestApplicationMessages: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(SearchContainer);
