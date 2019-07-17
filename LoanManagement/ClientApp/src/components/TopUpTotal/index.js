import React, { Component } from 'react';
import { connect } from 'react-redux';
import Money from '../Money'
import './index.css'

class TopUpTotal extends Component {
    render() {
        const { topups } = this.props

        return (
            <span className="topUpTotal">
                Carryover / Payout Amount <b><Money amount={topups.length > 0
                    ? topups.map(l => l.balance + l.interestAmount + l.earlyPaymentFee)
                        .reduce((a, b) => a + b)
                    : 0}
                />
                </b>
                
            </span>
        );
    }
}

export default connect(
    state => state.topups,
    null
)(TopUpTotal);

// const TopUpTotal = ({ topups }) => (
//     <div>
//         <p> Carryover / Payout Amount <b>
//             {<Money amount={topups.length > 0
//                 ? topups.map(l => l.balance + l.interestAmount + l.earlyPaymentFee)
//                     .reduce((a, b) => a + b)
//                 : 0} />
//             }
//         </b>
//         </p>

//     </div>
// );
// export default TopUpTotal;