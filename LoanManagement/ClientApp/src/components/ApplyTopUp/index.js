import React, { Component } from 'react';
import { connect } from 'react-redux';

import './index.css';

class ApplyTopUp extends Component {
    handleApplyTopup() {
        console.log("Topup Applied")
        //call webpi to update the topped up loans
    }

    render() {
        
        const { topups } = this.props;
        return (
            
            <button className='btn-TopUp'  disabled={(topups.length < 1)}
                onClick={this.handleApplyTopup}>
                Apply for Increased Loan amounts
            </button>
        );
    }
}

export default connect(
    state => state.topups,
    null
)(ApplyTopUp);