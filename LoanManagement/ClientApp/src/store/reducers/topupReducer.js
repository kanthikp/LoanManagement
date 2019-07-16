import {
  TOPUP_LOAN_ENABLE,
  TOPUP_LOAN_DISABLE
} from '../actions/actionTypes'

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

  return state;
};
