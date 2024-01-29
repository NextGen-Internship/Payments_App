import React from "react";
import { useState } from "react";
import './PageAdd';

const PageAdd = ({onAdd}) =>{
    
    const [bio,setBio] = useState('');
    const [photos,setPhotos] = useState([]);

    const onSubmit = (e) =>{
        e.preventDefault();
        if(!bio){
            alert("add bio");
            return;
        }
        onAdd({
            id:3,
            bio,
            photos
        });
        setBio('');
        setPhotos([]);
    }

    return(
        // <div>
        //     <h1>PageAdd</h1>
            
        //     <button className="btn" style={{backgroundColor:"green"}} onClick={(e)=>onSubmit} >Save Page</button>
        // </div>
        <form className="add-form" onSubmit={onSubmit}>
            <div className="form-control">
                <label>Bio</label>
                <input className="write" type='text' placeholder="bio" value={bio} onChange={(e)=>setBio(e.target.value)}></input>
            </div>
            <div className="form-control">
                <label>Photos</label>
                <input className="write" type='text' name="photo" placeholder="photos" value={photos} onChange={(e)=>setPhotos(e.target.value.split(","))}></input>
            </div>
            <input type="submit" value='Save Page' className="btn" style={{backgroundColor:"green"}}></input>
        </form>
    )
}

export default PageAdd;
