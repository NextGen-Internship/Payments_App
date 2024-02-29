import './UserGallery.css';
import Photo from "../Photo/Photo";
import { useState, useEffect } from "react";
import CloseIcon from '@mui/icons-material/Close';


const UserGallery = ({gallery}:any) =>{


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
        // 
         
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
             
            const formData = new FormData();
            formData.append("id",String(0));
            formData.append("pictureURL","0");
            formData.append("galleryID",gallery);
            formData.append("file",photo);
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

        <div className={model ? "model open" : "model"}>
            <img src={tempImgSrc} />
            <CloseIcon onClick={() => setModel(false)} />
        </div>

        <div className="gallery" style={{marginTop: '50px'}}>
            {photos.map((photo: any, index: any) => (
            <Photo key={index} photo={photo} onDeletePhoto={DeletePhoto} onClickPhoto={onClickPhoto} />
            ))}
        </div>
        </div>

      );
      
};
export default UserGallery;