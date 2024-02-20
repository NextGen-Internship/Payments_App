import React from "react";
import './Photo.css'
import { Button } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import IconButton from '@mui/material/IconButton';

const Photo = ({photo, onDeletePhoto, onClickPhoto}:any)=>{
    console.log(photo);
    return (
        <div className="alabala">
          <div className="photo-content">
            <img
              src={photo.pictureURL}
              alt={`Photo ${photo.pictureURL}`}
              className="pics"
              onClick={() => onClickPhoto(photo.pictureURL)}
            />
          </div>
        </div>
      );
      
      

};

export default Photo;