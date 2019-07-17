import React, { Component } from 'react';
import { connect } from 'react-redux';

import './index.css';

class ApplyNewLoan extends Component {
    handleApplyNewLoan() {
        console.log("NewLoan Applied")
        //call webpi to apply for a new loan
    }

    render() {
        const { personalLoans } = this.props;
        return (
            <button className='btn btn-NewLoan' disabled={!(personalLoans.length < 3)}
                onClick={this.handleApplyNewLoan}>
                Apply for new Personal Loan
            </button>
        );
    }
}

export default connect(
    state => state.personalLoans,
    null
)(ApplyNewLoan);