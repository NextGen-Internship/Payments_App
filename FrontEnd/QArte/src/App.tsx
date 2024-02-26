//import {useState} from "react";
import React, { useEffect } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { Box } from "@mui/material";
import { ResponsiveAppBar } from "./Components/Navbar/Navbar.js";
import Home from "./Pages/Home/Home.js";
import Login from "./Pages/SignIn/Login.js";
import SignUp from "./Pages/SignUp/SignUp.js";
import About from "./Pages/About/About.js";
//import UserList from './Components/ExplorePage/ExplorePage.js';
import SuccessPage from "./Components/Stripe/SuccessPage.jsx";
import ErrorPage from "./Components/Stripe/ErrorPage.jsx";
import ExplorePage from "./Components/ExplorePage/ExplorePage.js";
import SubPageContainer from "./Components/UserPageComponents/SubPageContainer/SubPageContainer.js";
import ProfilePage from "./Components/UserProfile/ProfilePage/ProfilePage.js";
import ProfileSubPageContainer from "./Components/UserProfile/ProfileSubPageContainer/ProfileSubPageContainer.js";
import AditionalInformation from "./Pages/AditionalInformation/AditionalInformation.tsx";
import UserPage from "./Components/UserPageComponents/UserPage/UserPage.js";
import StripeCheckout from "./Components/Stripe/StripeCheckout.jsx";
import Footer from "./Components/Footer/Footer.tsx";
import NotFound from "./Pages/404Page/NotFoundPage.tsx";

import { useDispatch, useSelector } from "react-redux";
import { setLoggedIn, setAvatar } from "./store/loginSlice";
import { RootState } from "@reduxjs/toolkit/query";
import { clearUser } from "../../store/loginSlice";
function App() {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector((state: RootState) => state.user.isLoggedIn);

  useEffect(() => {
    const token =
      sessionStorage.getItem("token") || sessionStorage.getItem("googleToken");
    console.log("Before dispatch", { isLoggedIn });
    if (token) {
      dispatch(setLoggedIn(true));
      console.log("After dispatch - inside if", { isLoggedIn });
    }
  }, [dispatch]);

  useEffect(() => {
    console.log("After dispatch - useEffect for isLoggedIn", { isLoggedIn }); // This will log the updated state after it has changed
  }, [isLoggedIn]);

  useEffect(() => {
    const userPictureUrl = sessionStorage.getItem("userPictureUrl");
    if (userPictureUrl) {
      dispatch(setAvatar(userPictureUrl));
    }
    // Add other rehydration logic here if necessary
  }, [dispatch]);

  return (
    <BrowserRouter>
      <Box display="flex" flexDirection="column" minHeight="100vh">
        <ResponsiveAppBar />

        <Routes>
          <Route path="*" element={<NotFound/>}/>
          <Route path="/stripe-checkout" element={<StripeCheckout />} />
          <Route path="/stripe-success" element={<SuccessPage />} />
          <Route path="/stripe-error" element={<ErrorPage />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/signup" element={<SignUp />} />
          {/* <Route path="/register" element={<Register />} /> */}
          <Route
            path="additionalInformation"
            element={<AditionalInformation />}
          />
          <Route path="/about" element={<About />} />

          {/* <Route path="/blog" element={<Blog />} /> */}
          <Route path="/explore">
            <Route index element={<ExplorePage />} />
            <Route path=":Uid/*" element={<UserPage />}>
              <Route path=":id" element={<SubPageContainer />} />
            </Route>
          </Route>
          <Route path="/profile/*" element={<ProfilePage />}>
            <Route path=":pageNumber" element={<ProfileSubPageContainer />} />
          </Route>

          <Route path="/home" element={<Home />} />
        </Routes>

        <Footer />
      </Box>
    </BrowserRouter>
  );
}

export default App;
