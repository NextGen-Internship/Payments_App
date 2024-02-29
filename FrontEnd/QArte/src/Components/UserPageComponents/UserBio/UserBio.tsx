import { useEffect, useState } from "react";
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


  
  return (
      <div className="my-container" style={{ display: 'flex', justifyContent: 'space-between', position: 'relative' }}>
        <p>{bio}</p>
      </div>
    );
};

export default UserBio;