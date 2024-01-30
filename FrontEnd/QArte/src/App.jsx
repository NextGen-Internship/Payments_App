import React from 'react';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginSignUp from './Components/Access/LoginSignUp';
import UserPage from './Components/UserPage/UserPage';
// import LoginSignUp from './Components/Access/LoginSignUp';




function App() {
    return (
        <GoogleOAuthProvider clientId="">
            <BrowserRouter>
                <Navbar />
                <Routes>
                    {/* <Route path="/home-page" element={<Home/>} />
                    <Route path="/about-page" element={<About/>} />
                    <Route path="/blog-page" element={<Blog/>} />
                    <Route path="/explore-page" element={<Explore/>} /> */}
                    <Route path="/login-signup" element={<LoginSignUp />} />
                    <Route path="/home-page/*" element={<UserPage/>}/>
                </Routes>
            </BrowserRouter>
        </GoogleOAuthProvider>

    );
}

export default App;

