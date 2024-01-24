import React from 'react';
import { GoogleLogin } from '@react-oauth/google';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginSignUp from './Components/Access/LoginSignUp';
// import LoginSignUp from './Components/Access/LoginSignUp';

function App() {
    return (
        <GoogleOAuthProvider clientId="">
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

// function App() {
//     const responseMessage = (response) => {
//         console.log(response);
//     };
//     const errorMessage = (error) => {
//         console.log(error);
//     };
//     return (
//         <div>
//             <h2>React Google Login</h2>
//             <br />
//             <br />
//             <GoogleLogin onSuccess={responseMessage} onError={errorMessage} />
//         </div>
//     )
// }
// export default App;
