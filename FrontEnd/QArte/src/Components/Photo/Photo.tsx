import React from "react";
import './Photo.css'
import { Button } from "@mui/material";

const Photo = ({photo, onDeletePhoto}:any)=>{
    console.log(photo);
    return (
        <div className="photo-container">
            <div className="photo-content">
                <img
                    src={photo.pictureURL}
                    alt={`Photo ${photo.pictureURL}`}
                    className="photo-image"
                />
            </div>
            <Button
                variant="contained"
                color="secondary"
                onClick={() => onDeletePhoto(photo.id)}
                className="delete-button"
            >
                Delete Photo
            </Button>
        </div>
    );

};

export default Photo;