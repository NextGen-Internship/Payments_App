import React from "react";
import './UserGallery.css';
import Photo from "../Photo/Photo";
import { useState, useEffect } from "react";
import { Button, Grid } from "@mui/material";

const UserGallery = ({gallery}:any) =>{

    const[file, setFile] = useState();
    const[photos, setPhotos] = useState([]);
    const[activeGallery,setActiveGallery] = useState();

    useEffect(()=>{
        const getPhotos =async () => {
            try
            {
                const photosFromServer = await fetchPhotos();
                setPhotos(photosFromServer);
                setActiveGallery(gallery);
            }
            catch(error)
            {
                console.error('Error fetching user data!', error);
            }
        }
        console.log("THIS IS THE GALLERY");
        getPhotos();
    },[gallery]);


    const fetchPhotos = async()=>{
        console.log("gallery")
        console.log(gallery)
        const res = await fetch(`https://localhost:7191/api/Picture/GetByGalleryID/${gallery}`);
        const photoData = await res.json();
        //console.log("THIS IS THE GALLERY!")
        console.log(photoData)
        return photoData;
    }

    const DeletePhoto = async (id:any) =>
    {
        try {
            console.log("Deleting picture: " + id);
    
            const response = await fetch(`https://localhost:7191/api/Picture/DeleteByID/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
    
            if (!response.ok) {
                throw new Error(`Failed to delete page. Status: ${response.status}`);
            }
            const res = await fetchPhotos();
            setPhotos(res);
            console.log('Picture deleted successfully.');
        } catch (error) {
            console.error('Error deleting picture:', error);
        }
    }

    const UploadPhoto =async (photo:any) => {
        try {
            console.log(photo)
            const formData = new FormData();
            formData.append("id",String(0));
            formData.append("pictureURL","0");
            formData.append("galleryID",gallery);
            formData.append("file",photo);
            const response = await fetch('https://localhost:7191/api/Picture/Post', {
                method: 'POST',
                headers: {

                },
                body: formData
            });
            const data = await response.json();
            if (!response.ok) {
                console.error('Failed to add page:', data);
                throw new Error(`Failed to add page. Status: ${response.status}`);
            }
            const res = await fetchPhotos();
            setPhotos(res);
            console.log('Page added successfully:', data);
            console.log("THe full data", res);
        } catch (error) {
            console.error('Error adding page:', error);
        }
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
            UploadPhoto(file);
            setFile(undefined);
        }
    }

    return (
        <div className="gallery-container">
            <Grid container justifyContent="flex-end" alignItems="flex-start" spacing={2}>
                <Grid item>
                    <input type="file" name="image" accept=".jng, .png" onChange={handleOnChange}></input>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary" onClick={AddPhoto}>
                        Add Photo
                    </Button>
                </Grid>
            </Grid>

            <div className="photo-grid">
                {photos.map((photo:any, index:any) => (
                    <Photo key={index} photo={photo} onDeletePhoto={DeletePhoto}/>
                ))}
            </div>
        </div>
    );
};
export default UserGallery;