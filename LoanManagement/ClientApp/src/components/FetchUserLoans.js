import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
// import { Link } from 'react-router-dom';
import { actionCreators } from '../store/UserLoans';

class FetchUserLoans extends Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
    console.log("In componentWillMount")
    console.log(this.props);
    this.props.requestUserLoans();
    
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    this.props.requestUserLoans();
  }

  render() {
    return (
      <div>
        <h1>User Loans</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
        {renderUserLoansTable(this.props)}
        
      </div>
    );
  }
}

function renderUserLoansTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>UserLoanId</th>
          <th>Interest</th>
          <th>EarlyPaymentFee</th>
          <th>Payout</th>
          <th>Loan Name</th>
        </tr>
      </thead>
      <tbody>
        {props.userLoans && props.userLoans.map(userLoan =>
          <tr key={userLoan.id}>
            <td>{userLoan.userLoanId}</td>  
            <td>{userLoan.interest}</td>
            <td>{userLoan.earlyPaymentFee}</td>
            <td>{userLoan.payout}</td>
            <td>{userLoan.loanMaster.name}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}


export default connect(
  state => state.userLoans,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchUserLoans);
