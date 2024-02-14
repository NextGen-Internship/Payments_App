import {useState} from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ResponsiveAppBar } from "./Components/Navbar/Navbar.js";
import Home from "./Pages/Home/Home.js";
import SignIn from "./Pages/SignIn/SignIn.js";
import SignUp from "./Pages/SignUp/SignUp.js";
import About from "./Pages/About/About.js";
import Blog from "./Pages/Blog/Blog.js";
import Explore from "./Pages/Explore/Explore.js";
import UserPage from './Components/UserPage/UserPage.js';
import UserList from './Components/ExplorePage/ExplorePage.js';
import SuccessPage from './Components/Stripe/SuccessPage.jsx';
import ErrorPage from './Components/Stripe/ErrorPage.jsx';
import  StripeCheckout from './Components/Stripe/StripeCheckout.jsx'
import ExplorePage from "./Components/ExplorePage/ExplorePage.js";
import SubPageContainer from "./Components/SubPageContainer/SubPageContainer.js";
import UserGallery from "./Components/UserGallery/UserGallery.js";
import Register from "./Pages/Register/Register.js";

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
              photos: ['/src/assets/QArte_B.png', 'path/to/photo3.jpg']
          },
      ]
  },
  {
    name: 'Jane Smith',
    id: 26,
    profilePicture: 'path/to/jane_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Hello, I am Jane Smith.',
        photos: ['/src/assets/QArte_B.png', 'path/to/jane_photo1.jpg', 'path/to/jane_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Having a great time!',
        photos: ['/src/assets/QArte_B.png', 'path/to/jane_photo3.jpg']
      },
    ]
  },
  // User 3
  {
    name: 'Alice Johnson',
    id: 27,
    profilePicture: 'path/to/alice_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'I love traveling!',
        photos: ['/src/assets/QArte_B.png', 'path/to/alice_photo1.jpg', 'path/to/alice_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Exploring new places.',
        photos: ['/src/assets/QArte_B.png', 'path/to/alice_photo3.jpg']
      },
    ]
  },
  // User 4
  {
    name: 'Bob Anderson',
    id: 28,
    profilePicture: 'path/to/bob_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Bob here!',
        photos: ['/src/assets/QArte_B.png', 'path/to/bob_photo1.jpg', 'path/to/bob_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Enjoying life!',
        photos: ['/src/assets/QArte_B.png', 'path/to/bob_photo3.jpg']
      },
    ]
  },
  // User 5
  {
    name: 'Emily Davis',
    id: 29,
    profilePicture: 'path/to/emily_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Photography lover.',
        photos: ['/src/assets/QArte_B.png', 'path/to/emily_photo1.jpg', 'path/to/emily_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Capturing moments.',
        photos: ['/src/assets/QArte_B.png', 'path/to/emily_photo3.jpg']
      },
    ]
  },
  // User 6
  {
    name: 'Michael Brown',
    id: 30,
    profilePicture: 'path/to/michael_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Tech enthusiast.',
        photos: ['/src/assets/QArte_B.png', 'path/to/michael_photo1.jpg', 'path/to/michael_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Coding all day!',
        photos: ['/src/assets/QArte_B.png', 'path/to/michael_photo3.jpg']
      },
    ]
  },
  // User 7
  {
    name: 'Sophie White',
    id: 31,
    profilePicture: 'path/to/sophie_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Nature lover.',
        photos: ['/src/assets/QArte_B.png', 'path/to/sophie_photo1.jpg', 'path/to/sophie_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Hiking adventures.',
        photos: ['/src/assets/QArte_B.png', 'path/to/sophie_photo3.jpg']
      },
    ]
  },
  // User 8
  {
    name: 'Daniel Miller',
    id: 32,
    profilePicture: 'path/to/daniel_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Fitness freak.',
        photos: ['/src/assets/QArte_B.png', 'path/to/daniel_photo1.jpg', 'path/to/daniel_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Gym time!',
        photos: ['/src/assets/QArte_B.png', 'path/to/daniel_photo3.jpg']
      },
    ]
  },
  // User 9
  {
    name: 'Olivia Taylor',
    id: 33,
    profilePicture: 'path/to/olivia_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Bookworm.',
        photos: ['/src/assets/QArte_B.png', 'path/to/olivia_photo1.jpg', 'path/to/olivia_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Reading is life.',
        photos: ['/src/assets/QArte_B.png', 'path/to/olivia_photo3.jpg']
      },
    ]
  },
  {
    name: 'William Turner',
    id: 34,
    profilePicture: 'path/to/william_profile.jpg',
    page: [
      {
        id: 1,
        bio: 'Artist at heart.',
        photos: ['/src/assets/QArte_B.png', 'path/to/william_photo1.jpg', 'path/to/william_photo2.jpg']
      },
      {
        id: 2,
        bio: 'Painting my world.',
        photos: ['/src/assets/QArte_B.png', 'path/to/william_photo3.jpg']
      },
    ]
  },
  {
      name: 'Doe',
      id: 1002,
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

const [UsersList,SetUserList] =  useState<any>(users);

  return (
    <BrowserRouter>
      <div>
        <ResponsiveAppBar />
        <Routes>
          <Route path="/stripe-checkout" element={<StripeCheckout />} /> 
          <Route path="/stripe-success" element={<SuccessPage />} /> 
          <Route path="/stripe-error" element={<ErrorPage />} /> 
          <Route path="/signin" element={<SignIn />} />
          <Route path="/signup" element={<SignUp />} />
          {/* <Route path="/register" element={<Register />} /> */}
          <Route path="/about" element={<About />} />
          <Route path="/blog" element={<Blog />} />
          <Route path="/explore">
            <Route index element={<ExplorePage/>}/>
            <Route path=":id/*" element={<UserPage/>}>
              <Route path=":id" element={<SubPageContainer/>}/>
            </Route>
          </Route>
          {/* <Route path="/" element={<Home />} /> */}
          <Route path="/home" element={<Home/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;




