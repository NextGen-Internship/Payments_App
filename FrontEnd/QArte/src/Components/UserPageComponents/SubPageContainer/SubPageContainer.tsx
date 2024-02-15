import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../../UserGallery/UserGallery";
import { useState, useEffect } from "react";
import ChangePage from "../../ChangePage/ChangePage";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "@mui/material";
import './SubPageContainer.css'

const SubPageContainer = () =>{

    const [ShowChangePage, setShowChangePage] = useState(false);
    const [page,setPage] = useState({
        id:'',
        bio:'',
        galleryID:'',
        qrLink:'',
        userID:'',
    });

    const navigate=useNavigate();
    const{id} = useParams();

    useEffect(()=>{
        const getPage =async () => {
            try
            {
                const pageFromServer = await fetchPage();
                setPage(pageFromServer);
            }
            catch(error)
            {
                console.error('Error fetching user data!', error);
            }
        }
        console.log("THIS IS THE Page");
        getPage();
    },[id]);

    const fetchPage = async()=>{
        const res = await fetch(`https://localhost:7191/api/Page/GetByID/${id}`);
        const pageData = await res.json();
        //console.log("THIS IS THE GALLERY!")
        console.log(pageData)
        return pageData;
    }

    const callPageChange = async (page:any) =>{
        try {
            console.log("Updating page: ", page);
    
            const response = await fetch(`https://localhost:7191/api/Page/PatchByID/${page.id}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(
                    {
                        id : page.id,
                        bio : page.bio,
                        qrLink: 'string',
                    }
                ),
            });
    
            if (!response.ok) {
                const errorDetails = await response.json();
                console.error(`Failed to update page. Status: ${response.status}. Details:`, errorDetails);
                throw new Error(`Failed to update page. Status: ${response.status}`);
            }
            const res = await fetchPage();
            setPage(res);
            console.log('Page updated successfully.');
    
            // If you want to update the UI or perform other actions after the update, add them here.
        } catch (error) {
            console.error('Error updating page:', error);
            
        }
        
    }

    const callPageDelete = async (id:any) =>{
        console.log(id);
        try {
            console.log("Deleting page: " + id);
    
            const response = await fetch(`https://localhost:7191/api/Page/DeleteByID/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
    
            if (!response.ok) {
                throw new Error(`Failed to delete page. Status: ${response.status}`);
            }
            window.location.href = `http://localhost:5173/explore/${page.userID}`;
            console.log('Page deleted successfully.');
        } catch (error) {
            console.error('Error deleting page:', error);
        }
    }

    return (
        <div className="sub-page-container">
          <div className="top-bar">
            <h1>{page.id}</h1>
            <Button variant="contained" color="error" size="small" style={{height:'20%', width:'20%'}} onClick={() => callPageDelete(page.id)}>
              Delete Page
            </Button>
          </div>
          <div className="bio-editPageButton-container">
          <UserBio bio={page.bio} />
          <Button variant="contained" color="primary" size="small" style={{height: '20%', width:'20%'}} onClick={() => setShowChangePage(!ShowChangePage)}>
            Edit bio
          </Button>
          </div >
          {ShowChangePage && <ChangePage id={page.id} onChange={callPageChange} />}
          {page.galleryID !== "" && <UserGallery gallery={page.galleryID} />}
        </div>
      );
};

export default SubPageContainer;