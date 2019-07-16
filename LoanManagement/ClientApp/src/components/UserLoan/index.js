import React, { Component } from 'react';

class UserLoan extends Component {
  render() {
    const { loan } = this.props
    const { id } = loan
    return (
      <div>
        Loan Id: {id}
      </div>
    );
  }
}

export default UserLoan;