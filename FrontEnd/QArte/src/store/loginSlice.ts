import { createSlice } from '@reduxjs/toolkit';

export const loginSlice = createSlice({
  name: 'user',
  initialState: {
    userInfo: null, // Holds the user information when logged in
    isLoggedIn: false, // Represents the login state
    avatar: null,
  },
  reducers: {
    // Action to set the user information and login state
    setUser: (state, action) => {
      state.userInfo = action.payload;
      state.isLoggedIn = !!action.payload;

    },
    setAvatar:(state,action)=>{
      state.avatar = action.payload;

    },
    // Action to clear the user information upon logout
    clearUser: (state) => {
      state.userInfo = null;
      state.isLoggedIn = false;
      state.avatar = null; 
    },

    setLoggedIn: (state, action) => {
        state.isLoggedIn = action.payload;
      },
  },
});

// Export the actions
export const { setUser, clearUser, setLoggedIn, setAvatar } = loginSlice.actions;
//export const { setLoggedIn } = loginSlice.actions;

// Export the reducer
export default loginSlice.reducer;
