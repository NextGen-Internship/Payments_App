import React,{Component} from "react";
import './UserPage.css';
import SubPageContainer from "../SubPageContainer/SubPageContainer";

const user = {
    name: 'John Doe',
    profilePicture: 'path/to/profile.jpg',
    bio: 'A brief bio about John Doe.',
    photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg'],
  };

const UserPage = () =>{

        return(
            <div className="container">
                <div className="container">
                    <img src={user.profilePicture} alt="Profile" />
                    <h2>{user.name}</h2>
                </div><SubPageContainer user={user} />
            </div>
        );
};
export default UserPage;