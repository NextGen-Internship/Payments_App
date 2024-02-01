import React from "react";
import './UserGallery.css';
import Photo from "../Photo/Photo";
import { useState } from "react";

const UserGallery = ({photos, onAddPhoto, onDeletePhoto}) =>{

    const[file, setFile] = useState();

    const handleOnChange = async(e)=>{
        let target = e.target.files;
        console.log('file', target);
        setFile(target[0]);
        
    }

    const AddPhoto = async()=>{
        if(file==undefined){
            alert("Choose an image")
        }
        else
        {
            console.log(file);
            onAddPhoto(file);
            setFile(undefined);
        }
        
    }

    return(
        <div className="container">
            <h3>Photo Gallery</h3>
            <div>
                <input type="file" name="image" onChange={handleOnChange}></input> 
                <button className="btn" style={{backgroundColor:"green"}} onClick={()=>AddPhoto()}>Add Photo</button>   
            </div>
            

            <div className="photo-grid">
                {photos.map((photo,index)=>(
                    <Photo key={index} photo={photo} onDeletePhoto={onDeletePhoto}/>
                ))}
            </div>
        </div>
    );
};
export default UserGallery;