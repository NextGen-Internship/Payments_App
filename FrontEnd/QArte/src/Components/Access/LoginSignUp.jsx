import React from 'react';
import './LoginSignUp.css';
  /* import MonaLisa from './photos/01.jpg'; */
import { GoogleLogin} from '@react-oauth/google'

    // const [email, setEmail] = useState("");
    // const [password, setPassword] = useState("");
    // const [showPassword, setShowPassword] = useState(false);
    // const [errorMessage, setErrorMessage] = useState("");

    // const handleTogglePassword = () => {
    //     setShowPassword(!showPassword);
    //  };
     
    //  const handleSubmit = async (e) => {
    //     e.preventDefault();
    //     // ... (Copy the content of handleSubmit from Login.jsx)
    //  };
     
    //  const handleGoogleLogin = async (response) => {
    //     // ... (Copy the content of handleGoogleLogin from Login.jsx)
    //  };


  const LoginSignUp = () => {
      return (
      <body>
        <div className="container">
              <input type="checkbox" id="flip"></input>
                  <div className="cover"></div>
                      <div className="front">
                      {/* <img src={MonaLisa} alt="01" /> */}
                          <div className="text">
                              {/* <span className="text-1">Every new friend is a new adventure</span> */}
                          </div>
                  </div>
          <form action="#">
            <div className="form-content">
              <div className="login-form">
                  {/* <div className="title">Login</div> */}
                      <div className="input-boxes">
                      <div className="title">Login</div>
                          <div className="input-box">
                              <i className="fas fa-envelope"></i>
                              <input type="text" placeholder="Enter your email" required />
                          </div>
                          
                          <div className="input-box">
                              <i className="fas fa-lock"></i>
                              <input type="password" placeholder="Enter your password" required />
                          </div>

                          <div className="text"><a href="#">Forgot password?</a></div>

                              <div className="input-box">
                                  <i className="fas fa-envelope"></i>
                                  <input type="submit" value="Submit" />
                              </div>
                              
                  <div className="text">Don't have an account? <label for="flip">Signup now</label></div>
                  
                  <div className="line"></div>
                  
                  <div className="media-options">
                  {/* <a href="#" className="fieldFacebook">
                      <i className='bx bxl-facebook facebook-icon' ></i>
                      <span>Login with Facebook</span>
                  </a> */}
                  {/* <GoogleLogin
                  onSuccess={(credentialResponse) => {
                    console.log('Login successful:', credentialResponse);
                  }}
                  onError={() => {
                    console.log('Login Failed');
                  }}
                  clientId="your-google-client-id"
                /> */}
                  <a href="#" className="fieldGoogle">
                      <i className='bx bxl-google' ></i>
                      <span>Login with Google</span>
                  </a>
                  </div>
                  
              </div>
            </div>
        
            <div className="signup-form">
              <div className="title">Sign up</div>
                  <div className="input-boxes">
                  <div className="input-box">
                      <i className="fas fa-user"></i>
                      <input type="text" placeholder="Enter your name" required />
                  </div>
                  <div className="input-box">
                      <i className="fas fa-envelope"></i>
                      <input type="text" placeholder="Enter your email" required />
                  </div>
                  <div className="input-box">
                      <i className="fas fa-lock"></i>
                      <input type="password" placeholder="Enter your password" required />
                  </div>
                  <div className="input-box">
                      <i className="fas fa-envelope"></i>
                      <input type="submit" value="Submit" />
                  </div>
                  </div>
                  <div className="text">Already have an account? <label for="flip">Login now</label></div>
                  
                  <div className="line"></div>
                
                  <div className="media-options">
                  {/* <a href="#" className="fieldFacebook">
                      <i className='bx bxl-facebook facebook-icon' ></i>
                      <span>Login with Facebook</span>
                  </a> */}
                  {/* <a href="#" className="fieldGoogle">
                      <i className='bx bxl-google' ></i>
                      <span>Login with Google</span>
                  </a> */}
              </div>
              </div>
            </div>
            </form>
        </div>
        </body>
      );
    };
    
    export default LoginSignUp