import React from "react";
import './UserGallery.css';

const UserGallery = ({photos}) =>{
    
    return(
        <div className="container">
            <h3>Photo Gallery</h3>
            <div className="photo-grid">
                {photos.map((photo,index)=>(
                    <img key = {index} src={photo} alt={`'Photo'${index+1}`}/>
                ))}
            </div>
        </div>
    );
};
export default UserGallery;