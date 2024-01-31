import React from 'react';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginSignUp from './Components/Access/LoginSignUp';
import SuccessPage from './Components/Stripe/SuccessPage.jsx';
import ErrorPage from './Components/Stripe/ErrorPage.jsx';
import  StripeCheckout from './Components/Stripe/StripeCheckout.jsx'


function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                {/* <Route path="/home-page" element={<Home/>} />
                <Route path="/about-page" element={<About/>} />
                <Route path="/blog-page" element={<Blog/>} />
                <Route path="/explore-page" element={<Explore/>} /> */}
                <Route path="/login-signup" element={<LoginSignUp />} />
                <Route path="/stripe-checkout" element={<StripeCheckout />} /> 
                <Route path="/stripe-success" element={<SuccessPage />} /> 
                <Route path="/stripe-error" element={<ErrorPage />} /> 
            </Routes>
        </Router>

    );
}

export default App;