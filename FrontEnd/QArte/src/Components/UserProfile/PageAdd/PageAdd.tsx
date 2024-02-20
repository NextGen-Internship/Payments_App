import React from "react";
import { useState } from "react";
import { Grid, TextField, Button } from '@mui/material';
import './PageAdd.css'; // Assuming you have a CSS file for styling

const PageAdd = ({ onAdd }: any) => {
    const [bio, setBio] = useState('');
    const [name, setName] = useState('');

    const onSubmit = (e: any) => {
        e.preventDefault();
        if (!bio) {
            alert("add bio");
            return;
        }
        onAdd({ bio, name });
    }

     return (
        <div className="center-container" style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
            <form className="add-form" onSubmit={onSubmit}>
                <Grid container spacing={2} direction="column" alignItems="center">
                    {/* Page Name Input */}
                    <Grid item style={{ width: '100%' }}>
                        <TextField
                            fullWidth
                            label="Page Name"
                            variant="outlined"
                            name="name"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            style={{ marginBottom: '8px' }}
                        />
                    </Grid>

                    {/* Bio Input */}
                    <Grid item style={{ width: '100%' }}>
                        <TextField
                            fullWidth
                            label="Bio"
                            variant="outlined"
                            name="bio"
                            value={bio}
                            onChange={(e) => setBio(e.target.value)}
                            style={{ marginBottom: '16px' }}
                        />
                    </Grid>

                    {/* Submit Button */}
                    <Grid item> 
                        <Button
                            type="submit"
                            variant="contained"
                            style={{ backgroundColor: 'green' }}
                        >
                            Save Page
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </div>
    )
}

export default PageAdd;
