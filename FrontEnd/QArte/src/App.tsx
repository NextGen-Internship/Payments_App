import { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ResponsiveAppBar } from "./Components/Navbar/Navbar.js";
import Home from "./Pages/Home/Home.tsx";
import SignIn from "./Pages/SignIn/SignIn.tsx";
import SignUp from "./Pages/SignUp/SignUp.tsx";
import About from "./Pages/About/About.tsx";
import Blog from "./Pages/Blog/Blog.tsx";
import Explore from "./Pages/Explore/Explore.tsx";
import UserPage from "./Components/UserPage/UserPage.tsx";
import UserList from "./Components/UserList/UserList.tsx";
import SuccessPage from "./Components/Stripe/SuccessPage.jsx";
import ErrorPage from "./Components/Stripe/ErrorPage.jsx";
import StripeCheckout from "./Components/Stripe/StripeCheckout.jsx";

const users = [
  {
    name: "John Doe",
    id: 25,
    profilePicture: "path/to/profile.jpg",
    page: [
      {
        id: 1,
        bio: "A brief bio about John Doe.",
        photos: [
          "/src/assets/QArte_B.png",
          "path/to/photo2.jpg",
          "path/to/photo3.jpg",
        ],
      },
      {
        id: 2,
        bio: "We are doing it!.",
        photos: ["/src/assets/QArte_B.png", "path/to/photo3.jpg"],
      },
    ],
  },

  {
    name: "Doe",
    id: 1,
    profilePicture: "path/to/profile.jpg",
    page: [
      {
        id: 1,
        bio: "A brief bio about John Doe.",
        photos: [
          "path/to/photo1.jpg",
          "path/to/photo2.jpg",
          "path/to/photo3.jpg",
        ],
      },
      {
        id: 2,
        bio: "We are doing it!.",
        photos: [
          "path/to/photo1.jpg",
          "path/to/photo2.jpg",
          "path/to/photo3.jpg",
        ],
      },
    ],
  },
];

function App() {
  const [UsersList, SetUserList] = useState<any>(users);
  let [OpenID, SetOpenID] = useState<number>(0);

  const onID = (id: number): void => {
    SetOpenID(id);
  };

  const FromIdToPos = (id: number): number | undefined => {
    for (var i = 0; i < UsersList.length; i++) {
      if (UsersList[i].id == id) {
        return i;
      }
    }
    return undefined;
  };

  const userIndex = FromIdToPos(OpenID);
  const userPageElement = <UserPage user={UsersList} />;

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
            <Route index element={<UserList users={UsersList} onID={onID} />} />
            <Route path=":id/*" element={<UserPage user={UsersList} />} />
          </Route>
          {/* <Route path="/" element={<Home />} /> */}
          <Route path="/home" element={<Home />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
