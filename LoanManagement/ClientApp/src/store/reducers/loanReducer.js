import {
  FETCH_LOANS_REQUEST,
  FETCH_LOANS_SUCCESS,
} from '../actions/actionTypes'

const initialState = {
  user: null,
  loans: [],
  error: null
}

export default (state, action) => {
  state = state || initialState;

  if (action.type === FETCH_LOANS_REQUEST) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === FETCH_LOANS_SUCCESS) {
  
    //const { user, loans } = action.userLoans
    return {
      ...state,
      user:null,
      loans: action.userLoans,
      isLoading: false
    };
  }

  return state;
};
