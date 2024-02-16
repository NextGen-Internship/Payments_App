import React from "react";
import './UserBio.css'

const UserBio = ({bio}:any)=>{
    return(
        <div className="my-container">
            <h2>Bio</h2>
            <p>{bio}</p>
        </div>
    );
};

export default UserBio;