import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/actions/loanActions'
import UserLoanDetail from '../UserLoanDetail'
import Money from '../Money'
import './index.css';

class UserLoan extends Component {
  constructor() {
    super();
    this.toggle = false;
  }

  changeTopUp = (e) => {
    const { target } = e
    const { loan } = this.props
    // const { id: loanId } = loan
    this.props.topUpLoan(loan, target.checked)
    this.toggle = !this.toggle;
  }

  render() {
    const { loan } = this.props
    //const { id } = loan
    return (

      <div className="userLoan">
        <table className="table table-bordered">
          <thead className="userLoanHead">
            <tr>
              <td colSpan="3">{loan.id} . {loan.loanMaster.name} # {loan.userLoanNum}</td>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td style={{width: "40%"}}>Balance</td>
              <td style={{width: "30%"}}><Money amount={loan.balance + loan.interestAmount} /></td>
              <td style={{width: "30%"}}><input type="checkbox" onChange={this.changeTopUp} /> Topup</td>

            </tr>
            <UserLoanDetail loan={loan} />
            {/* {this.toggle &&
              <tr>
                <td>Balance includes Interest of</td>
                <td>
                  <Money amount={loan.interestAmount} /></td>
                <td></td>
              </tr>
            }
            <tr>
              <td>Early Repayment Fee</td>
              <td><Money amount={loan.earlyPaymentFee} /></td>
              <td></td>
            </tr>
            <tr>
              <td>Payout / Carry Over Amount</td>
              <td><b><Money amount={loan.balance + loan.interestAmount + loan.earlyPaymentFee} /></b></td>
              <td>This amount will be carried over</td>
            </tr> */}
          </tbody>
        </table>
        {/* <UserLoanDetail loan={loan} /> */}
      </div>
    );
  }
}

export default connect(
  null,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(UserLoan);