import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import { Button } from '@mui/material';
import{ useEffect, useState } from "react";
import Box from "@mui/material/Box";
import './ProfileUserBio.css';


const ProfileUserBio = ({page, callPageChange}:any)=>{
    
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

    let isValid = true;

      if(isValid){
        callPageChange({
          page,
          bio,
          name
      });
      setEditMode(false);
      setBio('');
      setName('');
      }

  }

  const changeEditMode = () => 
  {
    setEditMode(!editMode);
  }
  
  return (
    editMode ? (
      <Box className="input-container" component="form" onSubmit={onSubmit}>
        
        <textarea
          id="nameTextarea"
          defaultValue={page.pageName}
          maxLength={30}
          style={{ height: textareaNameHeight, resize: 'vertical' }}
          onChange={(e) => {setName(e.target.value)}}
          required={true}
        />

        <textarea
          id="bioTextarea"
          defaultValue={bio}
          style={{ height: textareaBioHeight, resize: 'vertical' }}
          onChange={(e) => {setBio(e.target.value)}}
          required={true}

        />
        <div style={{ marginTop: '10px' }}>
          <Button variant="outlined" onClick={changeEditMode}>Cancel</Button>
          {' '}
          <Button variant="contained" type="submit" color="primary">OK</Button>
        </div>
      </Box>
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

export default ProfileUserBio;