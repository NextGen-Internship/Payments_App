import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";
import { useState } from "react";
import {useParams} from "react-router-dom"

const SubPageContainer = ({page, onDelete, onChange}) =>{
    const{id} = useParams()

    return(
        <div> 
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onChange(page.id)}>Edit Page</button>
            <UserBio bio = {page.bio}/>
            <UserGallery photos = {page.photos}/>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onDelete(page.id)}>Delete Page</button>       
        </div>
    );
};

export default SubPageContainer;