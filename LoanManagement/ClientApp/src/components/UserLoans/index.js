import UserLoan from '../UserLoan'

import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import {actionCreators} from '../../store/actions/loanActions'

class UserLoans extends Component {
  componentWillMount() {
    const userId = this.props.match.params.userId;

    if (userId) {
      this.props.fetchUserLoans(userId);
    }
  }

  // componentWillReceiveProps(nextProps) {
  //   const userId = nextProps.match.params.userId;

  //   if (userId) {
  //     this.props.fetchUserLoans(userId);
  //   }
  // }

  renderUserLoans = loans => {
    return loans.map(l => <UserLoan loan={l} key={l.id} />)
  }

  render() {
    const { loans } = this.props
    return (
      <div>
        {this.renderUserLoans(loans)}
      </div>
    );
  }
}

export default connect(
  state => state.personalLoans,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(UserLoans);