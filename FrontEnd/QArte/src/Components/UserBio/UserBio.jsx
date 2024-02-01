import React from "react";
import './UserBio.css'

const UserBio = ({bio})=>{
    return(
        <div className="container">
            <h3>Bio</h3>
            <p>{bio}</p>
        </div>
    );
};

export default UserBio;