import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";

const SubPageContainer = ({user}) =>{
    return(
        <div>
            <UserBio bio = {user.bio}/>
            <UserGallery photos = {user.photos}/>
        </div>
    );
};

export default SubPageContainer;