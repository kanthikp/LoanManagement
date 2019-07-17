import {
  TOPUP_LOAN_ENABLE,
  TOPUP_LOAN_DISABLE
} from '../actions/actionTypes'
import { LOCATION_CHANGE } from 'react-router-redux'

const initialState = {
  topups: []
}

export default (state, action) => {
  state = state || initialState;

  if (action.type === TOPUP_LOAN_ENABLE) {
    return {
      ...state,
      topups: [...state.topups, action.loan]
    };
  }

  if (action.type === TOPUP_LOAN_DISABLE) {
    return {
      ...state,
      topups: state.topups.filter(t => t.id != action.loan.id)
    };
  }
  if (action.type === LOCATION_CHANGE) {
    let path = action.payload.pathname;
    if (path.indexOf("/users/") >= 0) {
      
      return {
        ...state,
        topups:[]
      };
    }
  }

  return state;
};
