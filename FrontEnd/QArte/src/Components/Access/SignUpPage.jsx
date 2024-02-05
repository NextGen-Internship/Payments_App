import React from 'react';
import './LoginSignUp.css';

const SignupPage = () => {
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
          <div className="signup-form">
            <div className="title">Sign up</div>
            <div className="input-boxes">
                  <div className="input-box"></div>
              <div className="input-box">
                <i className="fas fa-user"></i>
                <input type="text" placeholder="Enter your name" required />
              </div>
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
            <div className="text">Already have an account? <label htmlFor="flip">Login now</label></div>
                  
                  <div className="line"></div>
                
                  <div className="media-options">
                    </div>
          </div>
        </div>
        </form>
      </div>
    </div>
  );
};

export default SignupPage;