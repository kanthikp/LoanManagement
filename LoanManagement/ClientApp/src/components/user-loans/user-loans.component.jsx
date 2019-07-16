import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/UserLoans';

class UserLoans extends Component {
    componentWillMount() {
        // This method runs when the component is first added to the page]
        this.props.requestUserLoans();
    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        //this.props.requestUserLoans();
    }

    render() {
        return (
            <div>
                <h1>UserLoans</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                {this.renderUserLoansTable(this.props)}
            </div>
        );
    }
    renderUserLoansTable(props) {

        return (
            <div>
                <p>Personal Loan Topup or Apply</p>
                <table className='table table-bordered'>
                    <tbody>
                        <tr>
                            <td>To apply for a TopUp of an existing loan amount, please select the loan below, make note of the Carry-over amount before proceeding.</td>
                            <td>Carryover/Payout Amount</td>
                            <td>$0</td>
                            <td><button>Apply for Increased Loan amounts</button></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td><button>Apply for new Personal Loan</button></td>
                        </tr>
                        <tr>
                            {this.renderUserLoanDetails(props)}
                        </tr>
                    </tbody>
                </table>

            </div>
        );
    }

    renderUserLoanDetails(props) {
        return (

            <td>
                {
                    props.userLoans && props.userLoans.map(userLoan =>

                        <table key={userLoan.id} className='table table-bordered'>
                            <thead>
                                <tr>
                                    <th>
                                        {userLoan.id}. {userLoan.loanMaster.name} # {userLoan.loanMaster.userLoanId}
                                    </th>
                                </tr>
                                <tr>
                                    <td>Balance</td>
                                    <td>{userLoan.interest + userLoan.payout + userLoan.earlyPaymentFee}</td>
                                    <td><input type="checkbox" />Top Up</td>
                                </tr>
                            </thead>
                        </table>
                    )
                }
            </td>

        );
    }
}




export default connect(
    state => state.userLoans,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserLoans);
