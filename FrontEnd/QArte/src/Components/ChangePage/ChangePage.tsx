import React, { useEffect, useState } from "react";
import { Button, TextareaAutosize } from "@mui/material";
import './ChangePage.css'

const ChangePage = ({ onChange, page }: any) => {
    
    const [bio, setBio] = useState('');

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
        });

        setBio('');
    }

    return (
        <div style={{alignContent: 'center'}}>
        <form className="add-form" onSubmit={onSubmit}>
            <div className="form-control" style={{ marginLeft: '50%'}}>
                <TextareaAutosize
                    className="write"
                    name="bio"
                    id="bio"
                    placeholder="Edit bio..."
                    value={bio}
                    onChange={(e) => setBio(e.target.value)}
                    style={{ width: "300px"}}
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
