import React from "react";
import './Photo.css'

const Photo = ({photo, onDeletePhoto}:any)=>{
    console.log("adsasd");
    console.log(photo);
    return(
        <div>
            <img src={photo.pictureURL} alt={`'Photo ${photo.pictureURL}`}/>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=>onDeletePhoto(photo)}>Delete Photo</button> 
        </div>
    );
};

export default Photo;