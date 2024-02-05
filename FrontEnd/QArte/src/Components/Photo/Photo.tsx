import React from "react";
import './Photo.css'

const Photo = ({photo, onDeletePhoto}:any)=>{
    return(
        <div>
            <img src={photo} alt={`'Photo ${photo}`}/>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=>onDeletePhoto(photo)}>Delete Photo</button> 
        </div>
    );
};

export default Photo;