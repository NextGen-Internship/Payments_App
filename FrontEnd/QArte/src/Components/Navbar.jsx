import React, { Component } from "react";
import { MenuItems } from "./MenuItems";
import './Navbar.css'


class Navbar extends Component {
    state = {clicked:false};
    handleClick = () => {
        this.setState({clicked:!this.state.clicked});
    }
    render() {
        return (
            <nav className="NavbarItems">
                <h1 className="navbar-logo">QArté</h1>

                <div className="menu-icons" onClick={this.handleClick}>
                     <i className={this.state.clicked ? "fas fa-times" : "fas fa-bars"}></i>
                </div>

                <ul className={this.state.clicked ? "nav-menu active" : "nav-menu"}>
                {MenuItems.map((item, index) => (
                        <li key={index}>
                            <a className={item.cName} href={item.url}>
                                <i className={`nav-links ${item.icon}`}> </i>
                                    {item.title}
                            </a>
                        </li>
                        
                ))}
                <a href="/login-signup"><button>SignIn/SignUp</button></a>
                </ul>
            </nav>
        );
    }
}

export default Navbar;