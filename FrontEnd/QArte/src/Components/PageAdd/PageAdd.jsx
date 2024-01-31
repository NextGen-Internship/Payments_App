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
                <label>Bio
                <input className="write" name="bio" id="bio" type='text' placeholder="bio" value={bio} onChange={(e)=>setBio(e.target.value)}></input>
                </label>
            </div>
            <input type="submit" value='Save Page' className="btn" style={{backgroundColor:"green"}}></input>
        </form>
    )
}

export default PageAdd;
