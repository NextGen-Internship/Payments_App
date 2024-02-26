import { createSlice } from '@reduxjs/toolkit';

export const pageSlice = createSlice({
  name: 'pages',
  initialState: {
    pageArray: null
  },
  reducers: {
    settingPages: (state, action) => {
      state.pageArray = action.payload;
    },
    clearPages: (state, action) => {
      state.pageArray = null;
    }
  },
});

export const { settingPages, clearPages } = pageSlice.actions;

export default pageSlice.reducer;
