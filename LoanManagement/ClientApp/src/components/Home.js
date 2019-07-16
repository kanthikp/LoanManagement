import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
    <h1>Hello</h1>
    <p>Welcome to Loan Management Application</p>
   
    <p>Please use the links on the left  to view the User specific personal loans:</p>
    
  </div>
);

export default connect()(Home);
