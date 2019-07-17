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
import DisplayError from '../DisplayError'

import './index.css';


class UserLoanCollection extends Component {
  componentWillMount() {
    const userId = this.props.match.params.userId;

    if (userId) {
      this.props.fetchUserLoans(userId);
    }
  }

  componentWillReceiveProps(nextProps) {


    if (this.props.userId !== nextProps.userId) {
      //set
      this.props.fetchUserLoans(nextProps.userId);
    }
  }

  renderUserLoans = loans => {
    return loans.map(l => <UserLoan loan={l} key={l.id} />)
  }

  handleApplyTopup = () => (
    console.log("Topup Applied")
    //call webpi to update the topped up loans
  );

  render() {
    const { loans, topups, error } = this.props

    return (
      <div className="userLoanApply">

        {error &&
          
              <DisplayError error={error} />
  
        }
        <table >
          <tbody>
            <tr>
              <td colSpan="3">
                <b>Personal Loan TopUp or Apply</b>
              </td>
            </tr>
            <tr>
              <td style={{width: "40%"}}>To apply for a TopUp of an existing loan amount, please select the loan below,
                make note of the Carry-over amount before processing.</td>
              <td style={{width: "30%"}}><TopUpTotal topups={topups} ></TopUpTotal></td>
              <td style={{width: "30%"}}><ApplyTopUp topups={topups} handleApplyTopup={this.handleApplyTopup}></ApplyTopUp> </td>
            </tr>
            <tr>
              <td></td>
              <td></td>
              <td><ApplyNewLoan userId={this.props.match.params.userId} personalLoans={loans}></ApplyNewLoan> </td>
            </tr>
            <tr>
              <td> <PersonalLoanCounter personalLoans={loans}></PersonalLoanCounter></td>
              <td></td>
              <td>{(loans && loans.length >= 3) && <NewLoanEligible></NewLoanEligible>}</td>
            </tr>
          </tbody>
        </table>
       <br></br>
        <div className="userLoanDetailsContainer">
          {this.renderUserLoans(loans)}
        </div>


      </div>  
    );
  }
}

export default
  connect(
    state => state.personalLoans,
    dispatch => bindActionCreators(actionCreators, dispatch)
  )
    (UserLoanCollection);