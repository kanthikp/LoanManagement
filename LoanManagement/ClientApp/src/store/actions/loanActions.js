import {
  FETCH_LOANS_REQUEST,
  FETCH_LOANS_SUCCESS,
  FETCH_LOANS_ERROR,
  TOPUP_LOAN_ENABLE,
  TOPUP_LOAN_DISABLE
} from './actionTypes'

export const actionCreators = {
  fetchUserLoans: userId => async (dispatch) => {
    dispatch({ type: FETCH_LOANS_REQUEST })

    const url = `api/users/${userId}/loans`;
    const response = await fetch(url);

    if (response.status >= 400 && response.status < 600) {
      response.json()
        .then(
          (result) => {

            dispatch({ type: FETCH_LOANS_ERROR, error: result, });
          });
    }
    else {
      response.json()
        .then(
          (result) => {

            dispatch({ type: FETCH_LOANS_SUCCESS, userLoans: result })
          },
          (error) => {
            dispatch({ type: FETCH_LOANS_ERROR, error: error, });
          }
        )
    }
  },


  topUpLoan: (loan, isEnabled) => (dispatch, getState) => {
    if (isEnabled) {
      dispatch({ type: TOPUP_LOAN_ENABLE, loan })
    } else {
      dispatch({ type: TOPUP_LOAN_DISABLE, loan })
    }
  }
} 