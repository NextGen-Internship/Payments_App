import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";
import { useState } from "react";
import ChangePage from "../ChangePage/ChangePage";
import { useNavigate, useParams } from "react-router-dom";

const SubPageContainer = ({page, onDelete, onChange, onAddPhoto, onDeletePhoto}:any) =>{

    const [ShowChangePage, setShowChangePage] = useState(false);
    const navigate=useNavigate();

    const{id} = useParams();

    return(
        <div> 
            
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> setShowChangePage(!ShowChangePage)}>Edit Page</button>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onDelete(page.id)}>Delete Page</button>    
            <UserBio bio = {page.bio}/>
            <UserGallery gallery = {page.galleryID} onAddPhoto={onAddPhoto} onDeletePhoto={onDeletePhoto}/>
            {ShowChangePage && <ChangePage id={page.id} photos={page.photos} onChange={onChange}/>}   
        </div>
    );
};

export default SubPageContainer;