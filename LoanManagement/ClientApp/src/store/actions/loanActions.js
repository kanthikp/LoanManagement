import {
  FETCH_LOANS_REQUEST,
  FETCH_LOANS_SUCCESS,
  TOPUP_LOAN_ENABLE,
  TOPUP_LOAN_DISABLE
} from './actionTypes'

export const actionCreators = {
  fetchUserLoans: userId => async(dispatch) => {
    dispatch({ type: FETCH_LOANS_REQUEST })
  
    const url = `api/users/${userId}/loans`;
    const response = await fetch(url);
    const userLoans = await response.json();
  
    dispatch({ type: FETCH_LOANS_SUCCESS, userLoans })
  },

  topUpLoan: (loan, isEnabled) => (dispatch, getState) => {
    if (isEnabled) {
      dispatch({ type: TOPUP_LOAN_ENABLE, loan })
    } else {
      dispatch({ type: TOPUP_LOAN_DISABLE, loan})
    }
  }
} 