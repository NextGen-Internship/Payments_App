import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";
import { useState, useEffect } from "react";
import ChangePage from "../../ChangePage/ChangePage";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "@mui/material";
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import './SubPageContainer.css'

const SubPageContainer = () =>{

    const [ShowChangePage, setShowChangePage] = useState(false);
    const [page,setPage] = useState({
        id:'',
        pageName:'',
        bio:'',
        galleryID:'',
        qrLink:'',
        userID:'',
    });

    const navigate=useNavigate();
    const{id} = useParams();
    const baseUrl = import.meta.env.VITE_BASE_URL;

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
         
        getPage();
    },[id]);

    const fetchPage = async()=>{
        const res = await fetch(`${baseUrl}/api/Page/GetByID/${id}`,{
            method: 'GET',
            headers:{
              'ngrok-skip-browser-warning': '1'
            }
          });
        const pageData = await res.json();
        // 
         
        return pageData;
    }

    const callPageChange = async (pages:any) =>{
        try {

             
    
            const response = await fetch(`${baseUrl}/Page/PatchByID/${pages.page.id}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                    'ngrok-skip-browser-warning': '1'
                },
                body: JSON.stringify(
                    {
                        id : pages.page.id,
                        bio : pages.bio,
                        pageName:pages.name,
                        qrLink: 'string',
                    }
                ),
            });
    
            if (!response.ok) {
                const errorDetails = await response.json();
                console.error(`Failed to update page. Status: ${response.status}. Details:`, errorDetails);
                throw new Error(`Failed to update page. Status: ${response.status}`);
            }
            window.location.href = `${baseUrl}/explore/${page.userID}`
            const res = await fetchPage();
            setPage(res);
             
             
            setShowChangePage(false);
           
            // If you want to update the UI or perform other actions after the update, add them here.
        } catch (error) {
            console.error('Error updating page:', error);
            
        }
        
    }

    const callPageDelete = async (id:any) =>{
        try {
             
    
            const response = await fetch(`${baseUrl}/api/Page/DeleteByID/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'ngrok-skip-browser-warning': '1'
                },
            });
    
            if (!response.ok) {
                throw new Error(`Failed to delete page. Status: ${response.status}`);
            }
            window.location.href = `${baseUrl}/explore/${page.userID}`;
             
        } catch (error) {
            console.error('Error deleting page:', error);
        }
    }


    return (
        <div className="sub-page-container" style={{ width: '100%', position: 'relative' }}>
          <div className="top-bar" style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', width: '100%' }}>
            <div className="name-And-Edit" style={{display:'flex', width:'100%'}}>
            <h1 style={{ marginLeft: '10%' }}>{page.pageName}</h1>
        </div>
          </div>
          <div className="bio-editPageButton-container">
          <UserBio page={page} callPageChange={callPageChange}/>
          </div>
          {page.galleryID !== "" && <UserGallery gallery={page.galleryID} />}
        </div>
      );
};

export default SubPageContainer;