import React from 'react';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginPage from './Components/Access/LoginPage';
import SignupPage from './Components/Access/SignUpPage';

const App = () => {
  const responseMessage = (response) => {
    console.log(response);
  };

  const errorMessage = (error) => {
    console.log(error);
  };

  return (
    <GoogleOAuthProvider clientId="">
      <Router>
        <Navbar />
        <Routes>
          {/* Placeholder for other routes */}
          {/* <Route path="/home" element={<div>Home Page</div>} />
          <Route path="/about" element={<div>About Page</div>} />
          <Route path="/contact" element={<div>Contact Page</div>} /> */}

          {/* Route for the login page */}
          <Route
            path="/login-page"
            element={<LoginPage responseMessage={responseMessage} errorMessage={errorMessage} />}
          />

          {/* Route for the signup page */}
          <Route path="/signup-page" element={<SignupPage />} />
        </Routes>
      </Router>
    </GoogleOAuthProvider>
  );
};

export default App;

// import React from 'react';
// import { GoogleLogin } from '@react-oauth/google';
// import { GoogleOAuthProvider } from '@react-oauth/google';
// import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
// import Navbar from './Components/Navbar';
// import LoginSignUp from './Components/Access/LoginSignUp';
// // import LoginSignUp from './Components/Access/LoginSignUp';

// function App() {
//     return (
//         <GoogleOAuthProvider clientId="">
//             <Router>
//                 <Navbar />
//                 <Routes>
//                     {/* <Route path="/home-page" element={<Home/>} />
//                     <Route path="/about-page" element={<About/>} />
//                     <Route path="/blog-page" element={<Blog/>} />
//                     <Route path="/explore-page" element={<Explore/>} /> */}
//                     <Route path="/login-signup" element={<LoginSignUp />} />
//                 </Routes>
//             </Router>
//         </GoogleOAuthProvider>
//     );
// }

// export default App;
