import { createSlice } from '@reduxjs/toolkit';

export const pageSlice = createSlice({
  name: 'pages',
  initialState: {
    pageArray:[]
  },
  reducers: {
    // Action to set the user information and login state
    setPages: (state, action) => {
      state.pageArray = action.payload;
    },
    clearPages:(state,action)=>{
      state.pageArray=[];
    }
  },
});

// Export the actions
export const { setPages,clearPages } = pageSlice.actions;
//export const { setLoggedIn } = loginSlice.actions;

// Export the reducer
export default pageSlice.reducer;