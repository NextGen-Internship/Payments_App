import React from "react";
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import './UserBio.css'


const UserBio = ({bio, onEditClick}:any)=>{
    return (
        <div className="my-container">
          <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
            <h2>Bio</h2>
            {/* Edit Bio Button */}
            <IconButton
              size="large"
              style={{ color: 'blue' }}
              onClick={onEditClick}
            >
              <EditIcon />
            </IconButton>
          </div>
          <p>{bio}</p>
        </div>
      );
};

export default UserBio;