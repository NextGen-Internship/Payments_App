import React, { useEffect, useState } from "react";
import { Button, TextareaAutosize } from "@mui/material";
import './ChangePage.css'

const ChangePage = ({ onChange, page }: any) => {
    
    const [bio,setBio] = useState('');
    const [name,setName] = useState('');


    useEffect(() => {
        // Set the initial value of bio when the component mounts
        setBio(page?.bio || ''); // Check if page exists before accessing properties
    }, [page]);

    const onSubmit = (e: any) => {
        e.preventDefault();
        if (!bio) {
            alert("Add bio");
            return;
        }

        onChange({
            page,
            bio,
            name
        });

        setBio('');
        setName('');
    }

    return (
        <div style={{alignContent: 'center'}}>
        <form className="add-form" onSubmit={onSubmit}>
            <div className="form-control" style={{ marginLeft: '50%', width: '100%'}}>
                <TextareaAutosize
                    className="write"
                    name="bio"
                    id="bio"
                    placeholder="Edit bio..."
                    value={bio}
                    onChange={(e) => setBio(e.target.value)}
                    style={{ width: '200px'}}
                />
            </div>
        {/* //     <button className="btn" style={{backgroundColor:"green"}} onClick={(e)=>onSubmit} >Save Page</button>
        // </div>a>
    //         <form className="add-form" onSubmit={onSubmit}>
    //             <div>
    //                 <label>Page Name
    //                     <input className="write" name="bio" id="bio" type='text' placeholder="Page Name" value={name} onChange={(e)=>setName(e.target.value)}></input>
    //                 </label>
    //             </div>
    //             <div className="form-control">
    //                 <label>Bio
    //                     <input className="write" name="bio" id="bio" type='text' placeholder="bio" value={bio} onChange={(e)=>setBio(e.target.value)}></input>
    //                 </label>
    //             </div>
    //             <input type="submit" value='Save Page' className="btn" style={{backgroundColor:"green"}}></input>
    //         </form>
    // ) */}
            <Button variant="contained" color="primary" type="submit" style={{marginLeft: '50%'}}>
                Save bio
            </Button>
        </form>
        </div>
    );
}

export default ChangePage;
