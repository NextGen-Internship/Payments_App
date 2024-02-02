import React from "react";
import { useState } from "react";
import './ChangePage.css'

const ChangePage = ({id, photos,onChange}:any) =>{
    
    const [bio,setBio] = useState('');

    const onSubmit = (e:any) =>{
        e.preventDefault();
        if(!bio){
            alert("add bio");
            return;
        }
        console.log({id,bio,photos})
        onChange({
            id,
            bio,
            photos
        });

        setBio('');
    }

    return(
        // <div>
        //     <h1>PageAdd</h1>
            
        //     <button className="btn" style={{backgroundColor:"green"}} onClick={(e)=>onSubmit} >Save Page</button>
        // </div>a>
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

export default ChangePage;
