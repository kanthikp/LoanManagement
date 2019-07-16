import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/actions/loanActions'
import UserLoanDetail from '../UserLoanDetail'

class UserLoan extends Component {
  changeTopUp = (e) => {
    const { target } = e
    const { loan } = this.props
    // const { id: loanId } = loan
    this.props.topUpLoan(loan, target.checked)
  }

  render() {
    const { loan } = this.props
    //const { id } = loan
    return (
      <div>
        <table className="table table-bordered">
          <thead>
            <tr><td>{loan.id} . {loan.loanMaster.name} # {loan.userLoanNum}</td></tr>
          </thead>
          <tbody>
            <tr>
              <td>Balance</td>
              <td>{loan.balance + loan.interestAmount}</td>
              <td><input type="checkbox" onChange={this.changeTopUp} /> Topup</td>

            </tr>
          </tbody>
        </table>
        <UserLoanDetail loan={loan} />
      </div>
    );
  }
}

export default connect(
  null,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(UserLoan);