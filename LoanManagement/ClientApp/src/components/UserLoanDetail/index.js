import React, { Component } from 'react';
import { connect } from 'react-redux';
import Money from '../Money'

class UserLoanDetail extends Component {
  render() {
    const { loan, topups } = this.props

    if (!topups.includes(loan)) {
      return null
    }

    return (
      <React.Fragment>
        <tr>
          <td>Balance includes Interest of</td>
          <td>
            <Money amount={loan.interestAmount} /></td>
          <td></td>
        </tr>
        <tr>
          <td>Early Repayment Fee</td>
          <td><Money amount={loan.earlyPaymentFee} /></td>
          <td></td>
        </tr>
        <tr>
          <td>Payout / Carry Over Amount</td>
          <td><b><Money amount={loan.balance + loan.interestAmount + loan.earlyPaymentFee} /></b></td>
          <td>This amount will be carried over</td>
        </tr>
      </React.Fragment>
    );
  }
}

export default connect(
  state => state.topups,
  null
)(UserLoanDetail);