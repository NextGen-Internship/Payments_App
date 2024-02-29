import ProfileUserBio from "../ProfileUserBio/ProfileUserBio";
import ProfileUserGallery from "../ProfileUserGallery/ProfileUserGallery";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { Button } from "@mui/material";
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import './ProfileSubPageContainer.css';

const ProfileSubPageContainer = () =>{

    const [ShowChangePage, setShowChangePage] = useState(false);
    const baseUrl = import.meta.env.VITE_BASE_URL;
    const frontUrl = import.meta.env.VITE_FRONT_URL;

    const [page,setPage] = useState({
        id:'',
        pageName:'',
        bio:'',
        galleryID:'',
        qrLink:'',
        userID:'',
    });

    const{pageNumber} = useParams();

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
    },[pageNumber]);

    const fetchPage = async()=>{
        const res = await fetch(`${baseUrl}/api/Page/GetByID/${pageNumber}`,{
            method: 'GET',
            headers:{
              'ngrok-skip-browser-warning': '1'
            }
          });
        const pageData = await res.json();
   
        return pageData;
    }

    const callPageChange = async (pages:any) =>{
        try {

    
            const response = await fetch(`${baseUrl}/api/Page/PatchByID/${pages.page.id}`, {
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
            window.location.href = `${frontUrl}/profile`;

            const res = await fetchPage();
            setPage(res);
             
            setShowChangePage(false);
           
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
            window.location.href = `${frontUrl}/profile`;
        } catch (error) {
            console.error('Error deleting page:', error);
        }
    }

    const GetQRCode = async ()=>{
        try{
            const respose = await fetch(`${baseUrl}/api/Page/GetQRCode/${page.id}`,{
                method: 'GET',
                headers:{
                  'ngrok-skip-browser-warning': '1'
                }
              });

            alert("The QR code was sent to your email.")
        }catch(error){
            console.error("Error getting QRCODE");
        }
    }


    return (
        <div className="sub-page-container" style={{ width: '100%', position: 'relative',  display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
          <div className="top-bar" style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', width: '100%' }}>
            <div className="name-And-Edit" style={{display:'flex', width:'100%'}}>
            <h1 style={{ marginLeft: '10%' }}>{page.pageName}</h1>
        </div>
            <IconButton
              size="large"
              onClick={() => callPageDelete(page.id)}
              title="Delete page"
              style={{ color: 'red', marginLeft: 'auto', marginRight:'3%'}}
              sx={{ '& .MuiSvgIcon-root': { fontSize: '3rem', strokeWidth: 2 } }}
            >
              <DeleteIcon />
            </IconButton>
          </div>
          <div className="bio-editPageButton-container">
          <ProfileUserBio page={page} callPageChange={callPageChange}/>
          </div>
          {page.galleryID !== "" && <ProfileUserGallery gallery={page.galleryID} />}
          <div style={{ marginTop: '30px', position: 'relative'}}>
            <Button 
            variant="contained"
            onClick={GetQRCode}>Get Page QRCode
            </Button>
          </div>
            
        </div>
      );
};

export default ProfileSubPageContainer;


