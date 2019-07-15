const requestUserLoansType = 'REQUEST_USER_LOANS';
const receiveUserLoansType = 'RECEIVE_USER_LOANS';
const initialState = { userLoans: [], isLoading: false };

export const actionCreators = {
  requestUserLoans: () => async (dispatch) => {


    //dispatch({ type: requestUserLoansType });

    const url = `api/UserLoans`;
    const response = await fetch(url);
    const userLoans = await response.json();

    dispatch({ type: receiveUserLoansType, userLoans });
  }
};

// export const mapStateToProps = (state) => {
//   return {
//     type: receiveUserLoansType, userLoans: this.state.userLoans
//   }
// };


export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestUserLoansType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveUserLoansType) {
    return {
      ...state,
      userLoans: action.userLoans,
      isLoading: false
    };
  }

  return state;
};
