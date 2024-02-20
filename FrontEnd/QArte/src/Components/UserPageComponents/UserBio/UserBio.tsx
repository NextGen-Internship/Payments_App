import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import { Button } from '@mui/material';
import React, { useEffect, useState } from "react";
import './UserBio.css'


const UserBio = ({page, callPageChange}:any)=>{
    
  const [bio,setBio] = useState('');
  const [name,setName] = useState('');
  const [editMode, setEditMode] = useState(false);
  const [textareaBioHeight, setTextareaBioHeight] = useState('auto');
  const [textareaNameHeight, setTextareaNameHeight] = useState('auto');

  useEffect(() => {
      setBio(page?.bio || ''); 
      setName(page?.pageName);
  }, [page]);


  useEffect(() => {
    const textarea = document.getElementById('bioTextarea');
    if (textarea) {
      setTextareaBioHeight(`${textarea.scrollHeight}px`);
    }
  }, [editMode, bio]);


  useEffect(() => {
    const textarea = document.getElementById('nameTextarea');
    if (textarea) {
      setTextareaNameHeight(`${textarea.scrollHeight}px`);
    }
  }, [editMode, name]);


  const onSubmit = (e: any) => {
    setEditMode(false);
      e.preventDefault();
      if (!bio) {
          alert("Add bio");
          return;
      }

      if(!name)
      {
        alert("Add name");
        return;
      }
      callPageChange({
          page,
          bio,
          name
      });

      setBio('');
      setName('');
  }

  const changeEditMode = () => 
  {
    setEditMode(!editMode);
  }
  
  return (
    editMode ? (
      <div className="input-container">
        
        <textarea
          id="nameTextarea"
          defaultValue={page.pageName}
          style={{ height: textareaNameHeight, resize: 'vertical' }}
          onChange={(e) => {setName(e.target.value)}}
        />

        <textarea
          id="bioTextarea"
          defaultValue={bio}
          style={{ height: textareaBioHeight, resize: 'vertical' }}
          onChange={(e) => {setBio(e.target.value)}}
        />
        <div style={{ marginTop: '10px' }}> {/* Add some margin */}
          <Button variant="outlined" onClick={changeEditMode}>Cancel</Button>
          {' '}
          <Button variant="contained" color="primary" onClick={onSubmit}>OK</Button>
        </div>
      </div>
    ) : (
      <div className="my-container" style={{ display: 'flex', justifyContent: 'space-between', position: 'relative' }}>
        <p>{bio}</p>
        <IconButton
          size="large"
          style={{ color: 'blue', position: 'absolute', top: 0, right: 0 }}
          onClick={changeEditMode}
        >
          <EditIcon />
        </IconButton>
      </div>
    )
  );
};

export default UserBio;