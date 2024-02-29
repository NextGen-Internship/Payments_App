import { createSlice } from '@reduxjs/toolkit';

export const loginSlice = createSlice({
  name: 'user',
  initialState: {
    userInfo: null, 
    isLoggedIn: false,
    avatar: null,
    isLoading:false,
  },
  reducers: {

    setUser: (state, action) => {
      state.userInfo = action.payload;
      state.isLoggedIn = !!action.payload;

    },
    setAvatar:(state,action)=>{
      state.avatar = action.payload;

    },
    clearUser: (state) => {
      state.userInfo = null;
      state.isLoggedIn = false;
      state.avatar = null; 
    },

    setLoggedIn: (state, action) => {
        state.isLoggedIn = action.payload;
      },

    setLoading: (state, action) => {
      state.isLoading = action.payload;
    },
  },
});

export const { setUser, clearUser, setLoggedIn, setAvatar,setLoading } = loginSlice.actions;

export default loginSlice.reducer;
