import React, { useEffect, useState } from "react";
import { Button, TextareaAutosize } from "@mui/material";
import './ChangePage.css'

const ChangePage = ({ onChange, page }: any) => {
    
    const [bio,setBio] = useState('');
    const [name,setName] = useState('');


    useEffect(() => {
        setBio(page?.bio || ''); 
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
            <Button variant="contained" color="primary" type="submit" style={{marginLeft: '50%'}}>
                Save bio
            </Button>
        </form>
        </div>
    );
}

export default ChangePage;
