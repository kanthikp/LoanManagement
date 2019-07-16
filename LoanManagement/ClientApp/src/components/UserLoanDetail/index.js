import React, { Component } from 'react';
import { connect } from 'react-redux';

class UserLoanDetail extends Component {
  render() {
    const { loan, topups } = this.props

    if (!topups.includes(loan)) {
      return null
    }

    return (
      <div>
        <table className="table table-bordered">
          <tbody>
            <tr>
              <td>Balance includes Interest of</td>
              <td>{loan.interestAmount}</td>
              <td></td>
            </tr>
            <tr>
              <td>Early Repayment Fee</td>
              <td>{loan.earlyPaymentFee}</td>
              <td></td>
            </tr>
            <tr>
              <td>Payout / Carry Over Amount</td>
              <td><b>{loan.balance + loan.interestAmount + loan.earlyPaymentFee }</b></td>
              <td>This amount will be carried over</td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}

export default connect(
  state => state.topups,
  null
)(UserLoanDetail);