import {
  FETCH_LOANS_REQUEST,
  FETCH_LOANS_SUCCESS,
} from './actionTypes'

export const actionCreators = {
  fetchUserLoans: userId => async(dispatch) => {
    dispatch({ type: FETCH_LOANS_REQUEST })
  
    const url = `api/users/${userId}/loans`;
    const response = await fetch(url);
    const userLoans = await response.json();
  
    dispatch({ type: FETCH_LOANS_SUCCESS, userLoans })
  },

  topUpLoan: loanId => (dispatch, getState) => {
    // Do some action
  }
}