import React from "react";
import './UserGallery.css';
import Photo from "../Photo/Photo";

const UserGallery = ({photos, onAddPhoto, onDeletePhoto}) =>{
    
    return(
        <div className="container">
            <h3>Photo Gallery</h3>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=>onAddPhoto("Photo.png")}>Add Photo</button>    
            <div className="photo-grid">
                {photos.map((photo,index)=>(
                    <Photo key={index} photo={photo} onDeletePhoto={onDeletePhoto}/>
                ))}
            </div>
        </div>
    );
};
export default UserGallery;