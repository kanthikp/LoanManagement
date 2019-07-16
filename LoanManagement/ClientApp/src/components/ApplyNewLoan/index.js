import React, { Component } from 'react';
import { connect } from 'react-redux';

class ApplyNewLoan extends Component {
    handleApplyNewLoan() {
        console.log("NewLoan Applied")
        //call webpi to apply for a new loan
    }

    render() {
        const { topups } = this.props;
        return (
            <button disabled={!(topups.length < 3)}
                onClick={this.handleApplyNewLoan}>
                Apply for Increased Loan amounts
            </button>
        );
    }
}

export default connect(
    state => state.topups,
    null
)(ApplyNewLoan);