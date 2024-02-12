import React from "react";
import { useState } from "react";
import './PageAdd';

const PageAdd = ({userID}: any) =>{
    
    const [bio,setBio] = useState('');
    const [photos,setPhotos] = useState([]);


    const postPage = async () => {
        const qr = Math.floor(Math.random()*1000)+1; // to fix
        try {
            const response = await fetch('https://localhost:7191/api/Page/Post', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    id:0,
                    bio,
                    qrLink:qr.toString(),
                    galleryID:0,
                    userID: userID,
                }),
            });
            const data = await response.json();
            if (!response.ok) {
                console.error('Failed to add page:', data);
                throw new Error(`Failed to add page. Status: ${response.status}`);
            }

            console.log('Page added successfully:', data);
        } catch (error) {
            console.error('Error adding page:', error);
        }
    };


  
    const onSubmit = (e:any) =>{
        e.preventDefault();
        if(!bio){
            alert("add bio");
            return;
        }
        setBio('');
        setPhotos([]);
        postPage();
    }

    return(
        <form className="add-form" onSubmit={onSubmit}>
            <div className="form-control">
                <label>Bio
                <input className="write" name="bio" id="bio" type='text' placeholder="bio" value={bio} onChange={(e)=>setBio(e.target.value)}></input>
                </label>
            </div>
            <input type="submit" value='Save Page' className="btn" style={{backgroundColor:"green"}}></input>
        </form>
    )
}

export default PageAdd;
