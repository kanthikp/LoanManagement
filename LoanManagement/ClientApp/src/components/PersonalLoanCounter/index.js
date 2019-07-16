import React, { Component } from 'react';
import { connect } from 'react-redux';

class PersonalLoanCounter extends Component {
    handleApplyTopup() {
        console.log("Topup Applied")
        //call webpi to update the topped up loans
    }

    render() {
        const {personalLoans} = this.props

        return (
                
                `You have ${personalLoans.length} Personal Loans`
            
        );
    }
}

export default connect(
    state => state.personalLoans,
    null
)(PersonalLoanCounter);