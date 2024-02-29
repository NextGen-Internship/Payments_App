import CloseIcon from '@mui/icons-material/Close';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';
import { Button } from "@mui/material";
import Input from '@mui/material/Input';
import { useEffect, useState } from "react";
import PhotoInProfile from "../PhotoInProfile/PhotoInProfile";
import './ProfileUserGallery.css';


const ProfileUserGallery = ({gallery}:any) =>{


    const[photos, setPhotos] = useState([]);
    const[activeGallery,setActiveGallery] = useState();
    const[model, setModel] = useState(false);
    const [tempImgSrc, setTempImgSrc] = useState('');
    const baseUrl = import.meta.env.VITE_BASE_URL;

    useEffect(()=>{
        const getPhotos =async () => {
            try
            {
                const photosFromServer = await fetchPhotos();
                setPhotos(photosFromServer);
                setActiveGallery(gallery);
            }
            catch(error)
            {
                console.error('Error fetching user data!', error);
            }
        }
        getPhotos();
    },[gallery]);


    const fetchPhotos = async()=>{

         
        const res = await fetch(`${baseUrl}/api/Picture/GetByGalleryID/${gallery}`,{
            method: 'GET',
            headers:{
              'ngrok-skip-browser-warning': '1'
            }
          });
        const photoData = await res.json();
         
        return photoData;
    }

    const DeletePhoto = async (id:any) =>
    {
        try {
    
            const response = await fetch(`${baseUrl}/api/Picture/DeleteByID/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'ngrok-skip-browser-warning': '1'
                },
            });
    
            if (!response.ok) {
                throw new Error(`Failed to delete page. Status: ${response.status}`);
            }
            const res = await fetchPhotos();
            setPhotos(res);
        } catch (error) {
            console.error('Error deleting picture:', error);
        }
    }

    const UploadPhoto =async (photo:any) => {
        try {

            const isImage=(photo.type=="image/png"||photo.type=="image/jpeg"||photo.type=="image/jpg");


            const formData = new FormData();
            formData.append("id",String(0));
            formData.append("pictureURL","0");
            formData.append("galleryID",gallery);
            formData.append("file",photo);
            formData.append("isImage",String(isImage));
            
            const response = await fetch(`${baseUrl}/api/Picture/Post`, {
                method: 'POST',
                headers: {

                    'ngrok-skip-browser-warning': '1'

                },
                body: formData
            });
            const data = await response.json();
            if (!response.ok) {
                console.error('Failed to add page:', data);
                throw new Error(`Failed to add page. Status: ${response.status}`);
            }
            const res = await fetchPhotos();
            setPhotos(res);
        } catch (error) {
            console.error('Error adding page:', error);
        }
    }

    const handleOnChange = async(e:any)=>{
        const target = e.target.files;
         
        AddPhoto(target[0]);
    }

    const AddPhoto = async(newFile:any)=>{
        if(newFile==undefined){
            alert("Choose an image")
        }
        else
        {
             
            UploadPhoto(newFile);
        }
    }

    const onClickPhoto= async(picURL:any) =>
    {
        setModel(true);
        setTempImgSrc(picURL);
    }

    return (
        <div className="gallery-container">
        <div className="buttonContainer" style={{ textAlign: "right", marginBottom: "30px" }}>
            <label htmlFor="image-upload">
            <Input
                id="image-upload"
                type="file"
                name="image"
                onChange={handleOnChange}

                inputProps={{ accept: 'image/png, image/jpeg, image/jpg, video/mp4, video/mp3' }}

            />
            <Button
                variant="contained"
                component="span"
                startIcon={<CloudUploadIcon />}
                style={{ marginRight: "2%" }}
            >
                Upload Media
            </Button>
            </label>
        </div>

        <div className={model ? "model open" : "model"}>
            <img src={tempImgSrc} />
            <CloseIcon onClick={() => setModel(false)} />
        </div>

        <div className="gallery">
            {photos.map((photo: any, index: any) => (
            <PhotoInProfile key={index} photo={photo} onDeletePhoto={DeletePhoto} onClickPhoto={onClickPhoto} />
            ))}
        </div>
        </div>

      );
      
};
export default ProfileUserGallery;