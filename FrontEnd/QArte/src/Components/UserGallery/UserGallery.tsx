import React from "react";
import './UserGallery.css';
import Photo from "../Photo/Photo";
import { useState, useEffect } from "react";

const UserGallery = ({gallery, onAddPhoto, onDeletePhoto}:any) =>{

    const[file, setFile] = useState();
    const[photos, setPhotos] = useState([]);

    useEffect(()=>{
        const getPhotos =async () => {
            try
            {
                const photosFromServer = await fetchPhotos();
                setPhotos(photosFromServer);
            }
            catch(error)
            {
                console.error('Error fetching user data!', error);
            }
        }
        getPhotos();
    },[]);

    const fetchPhotos = async()=>{
        const res = await fetch(`https://localhost:7191/api/Picture/GetByGalleryID/${gallery}`);
        const photoData = await res.json();
        console.log(photoData)
        return photoData;
    }

    const handleOnChange = async(e:any)=>{
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
                {photos.map((photo:any,index:any)=>(
                    <Photo key={index} photo={photo} onDeletePhoto={onDeletePhoto}/>
                ))}
            </div>
        </div>
    );
};
export default UserGallery;