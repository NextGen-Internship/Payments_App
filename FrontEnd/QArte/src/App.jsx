import React from 'react';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginSignUp from './Components/Access/LoginSignUp';
// import LoginSignUp from './Components/Access/LoginSignUp';

function App() {
    return (
        <GoogleOAuthProvider clientId="333025418614-sklgnbdkqfsiicgd003dbja9n5qi4m80.apps.googleusercontent.com">
            <Router>
                <Navbar />
                <Routes>
                    {/* <Route path="/home-page" element={<Home/>} />
                    <Route path="/about-page" element={<About/>} />
                    <Route path="/blog-page" element={<Blog/>} />
                    <Route path="/explore-page" element={<Explore/>} /> */}
                    <Route path="/login-signup" element={<LoginSignUp />} />
                </Routes>
            </Router>
        </GoogleOAuthProvider>
    );
}

export default App;

