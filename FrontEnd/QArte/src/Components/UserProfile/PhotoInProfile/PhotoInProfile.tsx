import React from "react";
import './PhotoInProfile.css'
import { Button } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import IconButton from '@mui/material/IconButton';

const PhotoInProfile = ({photo, onDeletePhoto, onClickPhoto}:any)=>{
     
    return (
        <div className="alabala">
            <div className="delete-container">
              <IconButton
                className="delete-button"
                color="secondary"
                style={{ color: 'red', marginLeft: 'auto'}}
                sx={{ '& .MuiSvgIcon-root': { fontSize: '3rem', strokeWidth: 2 } }}
                onClick={() => onDeletePhoto(photo.id)}
              >
                <CloseIcon />
              </IconButton>
            </div>
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

export default PhotoInProfile;