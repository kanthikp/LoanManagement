import {
  FETCH_LOANS_REQUEST,
  FETCH_LOANS_SUCCESS,
  FETCH_LOANS_ERROR,
} from '../actions/actionTypes'

import { LOCATION_CHANGE } from 'react-router-redux'

const initialState = {
  userId: 1,
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

      loans: action.userLoans,
      isLoading: false
    };
  }

  if (action.type === FETCH_LOANS_ERROR) {

    return {
      ...state,

      error: action.error,
      isLoading: false
    };
  }

  if (action.type === LOCATION_CHANGE) {
    let path = action.payload.pathname;
    if (path.indexOf("/users/") >= 0) {
      const userId = path.split('/')[2];
      return {
        ...state,
        userId: userId
      };
    }
  }

  return state;
};
