import React, { Component } from 'react';
import { connect } from 'react-redux';

class NewLoanEliglible extends Component {
    handleNewLoanEliglible() {
        console.log("NewLoan Applied")
        //call webpi to apply for a new loan
    }

    render() {
        const { topups } = this.props;
        return (
            
            <div className={(topups.length < 3) ? 'hidden' : ''} >
          With 3 or more current Personal Loans, a new Loan application is not possible  in this flow
          </div>

        );
    }
}

export default connect(
    state => state.topups,
    null
)(NewLoanEliglible);