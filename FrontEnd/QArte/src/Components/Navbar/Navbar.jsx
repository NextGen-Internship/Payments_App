import React from 'react'
import './Navbar.css'
import { FaBars,FaTimes } from "react-icons/fa";
import { useRef } from 'react';

const Navbar = () =>{
    const navRef = useRef();

    const showNavBar = () =>{
        navRef.current.classList.toggle("responsive_nav");
    }

    // const checkNavBar = () => {
    //     setIsNavOpen(!isNavOpen);
    // }

    return (
    <div>
        <div className='container'>
            <div >
                <img src="./Photos/000.jpg" className='logo'></img>
            </div>
            <div className='navbar'>
                    <nav ref={navRef}>
                        <ul>
                            <li><a href="/#">Home</a></li>
                            <li><a href="/#">About</a></li>
                            <li><a href="/#">Blog</a></li>
                            <li><a href="/#">Explore</a></li>
                            <li><a href="/#">Login/SignUp</a></li>
                        </ul>
                        
                        {/* <button className={`nav-btn ${isNavOpen ? 'close' : 'open'} btn`} onClick={toggleNavBar}>
                            {isNavOpen ? <FaTimes /> : <FaBars />}
                        </button> */}

                        <button className="nav-btn nav-close btn" onClick = {showNavBar}>
                            <FaTimes/>
                        </button>
                    </nav>
                    <button className="nav-btn" onClick = {showNavBar}>
                        <FaBars/>
                    </button>
            </div>    
        </div>

    </div>
    );
    
};

export default Navbar