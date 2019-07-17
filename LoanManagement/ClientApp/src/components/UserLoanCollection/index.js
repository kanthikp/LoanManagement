import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/actions/loanActions'

import UserLoan from '../UserLoan'
import TopUpTotal from '../TopUpTotal'
import ApplyTopUp from '../ApplyTopUp'
import ApplyNewLoan from '../ApplyNewLoan'
import PersonalLoanCounter from '../PersonalLoanCounter'
import NewLoanEligible from '../NewLoanEligible'

import './index.css';


class UserLoanCollection extends Component {
  componentWillMount() {
    const userId = this.props.match.params.userId;

    if (userId) {
      this.props.fetchUserLoans(userId);
    }
  }

  // componentWillReceiveProps(nextProps) {
  //   const userId = nextProps.match.params.userId;
    
  //   if (userId!=this.props.userId) {
  //     this.props.fetchUserLoans(userId);
  //   }
  // }

  renderUserLoans = loans => {
    return loans.map(l => <UserLoan loan={l} key={l.id} />)
  }



  render() {
    const { loans , topups} = this.props
    return (
      <div className="userLoanApply">
        <h4>Personal Loan TopUp or Apply</h4>
        {/* <div className="userLoanCollection">
          <div>
          To apply for a TopUp of an existing loan amount, please select the loan below, make note of the Carry-over amount before processing.
          </div>
        </div> */}
        <table className="table table-bordered">
          <tbody>
            <tr>
              <td>To apply for a TopUp of an existing loan amount, please select the loan below, make note of the Carry-over amount before processing.</td>

              <td> <TopUpTotal topups={topups} ></TopUpTotal></td>
              <td><ApplyTopUp topups={topups}></ApplyTopUp>  </td>

            </tr>
            <tr>
              <td></td>
              <td></td>
              <td><ApplyNewLoan userId={this.props.match.params.userId} topups={topups}></ApplyNewLoan></td>
            </tr>
            
            <tr>
              <td><PersonalLoanCounter personalLoans={loans}></PersonalLoanCounter></td>
              <td></td>
              <td><NewLoanEligible personalLoans={loans}></NewLoanEligible></td>
            </tr>
          </tbody>
        </table>
        <div></div>
        {this.renderUserLoans(loans)}
      </div>
    );
  }
}

export default connect(
  state => state.personalLoans,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(UserLoanCollection);