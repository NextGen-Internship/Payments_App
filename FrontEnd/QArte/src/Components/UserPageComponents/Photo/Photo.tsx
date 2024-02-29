import React from "react";
import './Photo.css'
import { Button } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import IconButton from '@mui/material/IconButton';

const Photo = ({photo, onDeletePhoto, onClickPhoto}:any)=>{
     
    return (
        <div className="alabala">
          <div className="photo-content">
          {photo.isImage&&<img
              src={photo.pictureURL}
              alt={`Photo ${photo.pictureURL}`}
              className="pics"
              onClick={() => onClickPhoto(photo.pictureURL)}
            />}
            {
              !photo.isImage&&<video className="vid" controls >
                <source className="pics" src={photo.pictureURL}/>
              </video>
            
            }
          </div>
        </div>
      );
      
      

};

export default Photo;