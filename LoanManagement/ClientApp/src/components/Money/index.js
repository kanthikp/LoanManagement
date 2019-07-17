import React from 'react';

const Money = ({ amount }) => (
    <p>
        {
            Intl.NumberFormat('en-AU', {
                style: 'currency',
                currency: 'AUD',
                maximumSignificantDigits: 3
            }).format(amount)
        }
    </p>
);

  export default Money;
