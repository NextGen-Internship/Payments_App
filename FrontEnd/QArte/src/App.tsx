//import {useState} from "react";
//import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Box } from "@mui/material";
import { ResponsiveAppBar } from "./Components/Navbar/Navbar.js";
import Home from "./Pages/Home/Home.js";
import SignIn from "./Pages/SignIn/SignIn.js";
import SignUp from "./Pages/SignUp/SignUp.js";
import About from "./Pages/About/About.js";
//import UserList from './Components/ExplorePage/ExplorePage.js';
import SuccessPage from "./Components/Stripe/SuccessPage.jsx";
import ErrorPage from "./Components/Stripe/ErrorPage.jsx";
import ExplorePage from "./Components/ExplorePage/ExplorePage.js";
import SubPageContainer from "./Components/UserPageComponents/SubPageContainer/SubPageContainer.js";
import ProfilePage from "./Components/UserProfile/ProfilePage/ProfilePage.js";
import ProfileSubPageContainer from "./Components/UserProfile/ProfileSubPageContainer/ProfileSubPageContainer.js";
//import Blog from "./Pages/Blog/Blog.js";
//import ExplorePage from "./Pages/Explore/Explore.tsx";
//import AditionalInformation from "./Pages/AditionalInformation/AditionalInformation.tsx";
import AditionalInformation from "./Pages/AditionalInformation/AditionalInformation.tsx";
import UserPage from "./Components/UserPageComponents/UserPage/UserPage.js";
import StripeCheckout from "./Components/Stripe/StripeCheckout.jsx";
import Footer from "./Components/Footer/Footer.tsx";

function App() {
  return (
    <BrowserRouter>
      <Box display="flex" flexDirection="column" minHeight="100vh">
        <ResponsiveAppBar />
        <Box component="main" flexGrow={1}>
          <Routes>
            <Route path="/stripe-checkout" element={<StripeCheckout />} />
            <Route path="/stripe-success" element={<SuccessPage />} />
            <Route path="/stripe-error" element={<ErrorPage />} />
            <Route path="/signin" element={<SignIn />} />
            <Route path="/signup" element={<SignUp />} />
            {/* Additional routes */}
            <Route path="/about" element={<About />} />
            <Route path="/explore" element={<ExplorePage />} />
            <Route
              path="/additionalInformation"
              element={<AditionalInformation />}
            />
            {/* Nested routes for /explore */}
            <Route path="/profile/*" element={<ProfilePage />} />
            {/* Nested routes for /profile */}
            <Route path="/home" element={<Home />} />
            {/* Add more routes as needed */}
          </Routes>
        </Box>
        <Footer />
      </Box>
    </BrowserRouter>
  );
}

export default App;
