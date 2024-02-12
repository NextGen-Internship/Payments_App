import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";
import { useState } from "react";
import ChangePage from "../ChangePage/ChangePage";

const SubPageContainer = ({page, onDelete, onChange, onAddPhoto, onDeletePhoto}:any) =>{

    const [ShowChangePage, setShowChangePage] = useState(false);

    return(
        <div> 
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> setShowChangePage(!ShowChangePage)}>Edit Page</button>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onDelete(page.id)}>Delete Page</button>    
            <UserBio bio = {page.bio}/>
            {/* <UserGallery photos = {page.photos} onAddPhoto={onAddPhoto} onDeletePhoto={onDeletePhoto}/> */}
            {ShowChangePage && <ChangePage id={page.id} photos={page.photos} onChange={onChange}/>}   
        </div>
    );
};

export default SubPageContainer;