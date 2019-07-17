import React from 'react';

const PersonalLoanCounter = ({personalLoans})=>(
    `You have ${personalLoans.length} Personal Loan${personalLoans.length>1?'s':''}`
);

export default PersonalLoanCounter;