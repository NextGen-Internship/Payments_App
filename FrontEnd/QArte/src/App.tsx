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
import UserList from './Components/UserList/UserList.js';
import SuccessPage from './Components/Stripe/SuccessPage.jsx';
import ErrorPage from './Components/Stripe/ErrorPage.jsx';
import  StripeCheckout from './Components/Stripe/StripeCheckout.jsx'

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
      name: 'Doe',
      id: 2,
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
let [OpenID,SetOpenID] = useState<number>(0); 

 const onID = (id:number):void =>{
    SetOpenID(id);
}

const FromIdToPos = (id:number):number|undefined =>{
    for(var i=0; i<UsersList.length;i++){
        if(UsersList[i].id==id){
            return i;
        }
    }
    return undefined;
}

const userIndex = FromIdToPos(OpenID);
const userPageElement = <UserPage user={UsersList}/>

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
            <Route index element={<UserList users={UsersList} onID={onID}/>}/>
            <Route path=":id/*" element={<UserPage user={UsersList}/>}/>
          </Route>
          {/* <Route path="/" element={<Home />} /> */}
          <Route path="/home" element={<Home/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;




