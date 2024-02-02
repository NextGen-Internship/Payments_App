import React,{useState} from 'react';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';
import Navbar from './Components/Navbar';
import LoginSignUp from './Components/Access/LoginSignUp';
import UserPage from './Components/UserPage/UserPage';
import UserList from './Components/UserList/UserList';
import SubPageLister from './Components/SubPageLister/SubPageLister';
import SubPageContainer from './Components/SubPageContainer/SubPageContainer';
// import LoginSignUp from './Components/Access/LoginSignUp';
import SuccessPage from './Components/Stripe/SuccessPage.jsx';
import ErrorPage from './Components/Stripe/ErrorPage.jsx';
import  StripeCheckout from './Components/Stripe/StripeCheckout.jsx'
import LoginPage from './Components/Access/LoginPage';
import SignupPage from './Components/Access/SignUpPage';



const users = [
    {
        name: 'John Doe',
        id: 25,
        profilePicture: 'path/to/profile.jpg',
        page:[
            {
                id: 1,
                bio: 'A brief bio about John Doe.',
                photos: ['/src/assets/QArte_B.png', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
            },
            {
                id: 2,
                bio: 'We are doing it!.',
                photos: ['/src/assets/MonaLisa.jpg', 'path/to/photo3.jpg']
            },
        ]
    },

    {
        name: 'Doe',
        id: 26,
        profilePicture: 'path/to/profile.jpg',
        page:[
            {
                id: 1,
                bio: 'A brief bio about John Doe.',
                photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
            },
            {
                id: 2,
                bio: 'We are doing it!.',
                photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
            },
        ]
    }
];

function App() {

    const [UsersList,SetUserList] = useState(users);
    let [OpenID,SetOpenID] = useState(0); 

     const onID = (id) =>{
        SetOpenID(id);
    }

    const FromIdToPos = (id) =>{
        for(var i=0; i<UsersList.length;i++){
            if(UsersList[i].id==id){
                return i;
            }
        }
    }

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
                    <Route path="/stripe-checkout" element={<StripeCheckout />} /> 
                    <Route path="/stripe-success" element={<SuccessPage />} /> 
                    <Route path="/stripe-error" element={<ErrorPage />} /> 
                    <Route path="/home-page">
                        <Route index element={<UserList users={UsersList} onID={onID}/>}/>
                        <Route path=":id/*" element={<UserPage user={UsersList[FromIdToPos(OpenID)]}/>}/>
                    </Route>
                </Routes>
            </BrowserRouter>
        </GoogleOAuthProvider>

    );
}



// const App = () => {
//   const responseMessage = (response) => {
//     console.log(response);
//   };

//   const errorMessage = (error) => {
//     console.log(error);
//   };

//   return (
//     <GoogleOAuthProvider clientId="">
//       <Router>
//         <Navbar />
//         <Routes>
//           {/* Placeholder for other routes */}
//           {/* <Route path="/home" element={<div>Home Page</div>} />
//           <Route path="/about" element={<div>About Page</div>} />
//           <Route path="/contact" element={<div>Contact Page</div>} /> */}

//           {/* Route for the login page */}
//           <Route
//             path="/login-page"
//             element={<LoginPage responseMessage={responseMessage} errorMessage={errorMessage} />}
//           />

//           {/* Route for the signup page */}
//           <Route path="/signup-page" element={<SignupPage />} />
//         </Routes>
//       </Router>
//     </GoogleOAuthProvider>
//   );
// };



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


export default App;