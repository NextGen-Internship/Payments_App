import React from "react";
import { useState } from "react";
import './ChangePage.css'

const ChangePage = ({id,onChange}:any) =>{
    
    const [bio,setBio] = useState('');
    const [name,setName] = useState('');

    const onSubmit = (e:any) =>{
        e.preventDefault();
        if(!bio){
            alert("add bio");
            return;
        }

        onChange({
            id,
            bio,
            name
        });

        setBio('');
        setName('');
    }

    return(
        // <div>
        //     <h1>PageAdd</h1>
            
        //     <button className="btn" style={{backgroundColor:"green"}} onClick={(e)=>onSubmit} >Save Page</button>
        // </div>a>
            <form className="add-form" onSubmit={onSubmit}>
                <div>
                    <label>Page Name
                        <input className="write" name="bio" id="bio" type='text' placeholder="Page Name" value={name} onChange={(e)=>setName(e.target.value)}></input>
                    </label>
                </div>
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
