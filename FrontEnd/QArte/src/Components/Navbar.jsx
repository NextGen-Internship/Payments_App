import React, { Component } from "react";
import { MenuItems } from "./MenuItems";import { Link } from "react-router-dom";
import './Navbar.css';
import './Navbar.css'
import {NavLink } from 'react-router-dom';

class Navbar extends Component {
    state = {clicked:false};
    handleClick = () => {
        this.setState({clicked:!this.state.clicked});
    }
    render() {
        return (
            <nav className="NavbarItems">
                <h1 className="navbar-logo">QArté</h1>

                <ul className={this.state.clicked ? "nav-menu active" : "nav-menu"}>
                {MenuItems.map((item, index) => (
                        <li key={index}>
                            <NavLink className={item.cName} to={item.url}>
                                <i className={`nav-links ${item.icon}`}/>
                                {item.title}
                            </NavLink>
                        </li>
                        
                ))}
                <NavLink to="/login-signup"><button>SignIn/SignUp</button></NavLink>
                </ul>
            </nav>
        );
    }

  // render() {
  //   return (
  //     <nav className="NavbarItems">
  //       <h1 className="navbar-logo">QArte</h1>

  //       <div className="menu-icons" onClick={this.handleClick}>
  //         <i className={this.state.clicked ? "fas fa-times" : "fas fa-bars"}></i>
  //       </div>

  //       <ul className={this.state.clicked ? "nav-menu active" : "nav-menu"}>
  //         {MenuItems.map((item, index) => (
  //           <li key={index}>
  //             <Link className={item.cName} to={item.url}>
  //               <i className={`nav-links ${item.icon}`}></i>
  //               {item.title}
  //             </Link>
  //           </li>
  //         ))}
          
  //         <li>
  //           <Link to="/login">
  //             <button className="nav-links-mobile">Login</button>
  //           </Link>
  //         </li>
  //         <li>
  //           <Link to="/signup">
  //             <button className="nav-links-mobile">Sign Up</button>
  //           </Link>
  //         </li>
  //       </ul>
  //     </nav>
  //   );
  // }

}
export default Navbar;

