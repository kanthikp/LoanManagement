import React, { Component } from 'react';
import { connect } from 'react-redux';

class TopUpTotal extends Component {
    render() {
        const { topups } = this.props

        return (
            <div>
                <label> Carryover / Payout Amount</label>

                <p>${topups.length > 0
                    ? topups.map(l => l.balance + l.interestAmount + l.earlyPaymentFee)
                        .reduce((a, b) => a + b)
                    : 0}
                </p>
            </div>
        );
    }
}

export default connect(
    state => state.topups,
    null
)(TopUpTotal);