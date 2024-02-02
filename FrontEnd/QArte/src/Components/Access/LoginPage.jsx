import React from 'react';
import { GoogleLogin } from '@react-oauth/google';
import './LoginSignUp.css';

const LoginPage = ({ responseMessage, errorMessage }) => {
  return (
    <div className="app">
        <div className="container">
              <input type="checkbox" id="flip"></input>
                  <div className="cover"></div>
                      <div className="front">
                          <div className="text">
                          </div>
                  </div>
          <form action="#">
            <div className="form-content"></div>

    <div className="login-form">
        <div className="title">Login</div>
        <div className="input-box">
            <i className="fas fa-envelope"></i>
            <input type="text" placeholder="Enter your email" required />
        </div>

        <div className="input-box">
            <i className="fas fa-lock"></i>
            <input type="password" placeholder="Enter your password" required />
        </div>

        <div className="text">
            <a href="#">Forgot password?</a>
        </div>

        <div className="input-box">
            <i className="fas fa-envelope"></i>
            <input type="submit" value="Submit" />
        </div>
        <div className="text">Don't have an account? <label htmlFor="flip">SignUp now</label></div>   
        <div className="line"></div>

        <div className="media-options">
        <GoogleLogin
            onSuccess={responseMessage}
            onError={errorMessage}
        />
            <a href="#" className="fieldGoogle">
                      <i className='bx bxl-google' ></i>
             </a>
        </div>
        </div>  
        </form>
        </div>
        </div>
  );
};

export default LoginPage;
