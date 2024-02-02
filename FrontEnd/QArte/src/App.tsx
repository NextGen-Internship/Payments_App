import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ResponsiveAppBar } from "../src/Components/Navbar/Navbar";
import Home from "./Pages/Home/Home";
import SignIn from "./Pages/SignIn/SignIn";
import SignUp from "./Pages/SignUp/SignUp";
import About from "./Pages/About/About";
import Blog from "./Pages/Blog/Blog";
import Explore from "./Pages/Explore/Explore";

function App() {
  return (
    <BrowserRouter>
      <div>
        <ResponsiveAppBar />
        <Routes>
          <Route path="/home" element={<Home />} />
          <Route path="/signin" element={<SignIn />} />
          <Route path="/signup" element={<SignUp />} />
          {/* <Route path="/register" element={<Register />} /> */}
          <Route path="/about" element={<About />} />
          <Route path="/blog" element={<Blog />} />
          <Route path="/explore" element={<Explore />} />
          <Route path="/" element={<Home />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
