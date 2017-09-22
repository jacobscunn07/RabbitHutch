import React from 'react';
import { connect } from 'react-redux';
import Search from './Search';

class SearchContainer extends React.Component {
  componentWillMount() {
  }

  render() {
    return (<Search onSearchClick={() => { alert('TODO'); }} />);
  }
}

function mapStateToProps() {
  return {
  };
}

function mapDispatchToProps() {
  return {
  };
}

SearchContainer.propTypes = {
};

export default connect(mapStateToProps, mapDispatchToProps)(SearchContainer);
