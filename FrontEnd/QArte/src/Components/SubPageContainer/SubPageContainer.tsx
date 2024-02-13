import React from "react";
import UserBio from "../UserBio/UserBio";
import UserGallery from "../UserGallery/UserGallery";
import { useState, useEffect } from "react";
import ChangePage from "../ChangePage/ChangePage";
import { useNavigate, useParams } from "react-router-dom";

const SubPageContainer = ({ onDelete, onChange, onAddPhoto, onDeletePhoto}:any) =>{

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


    return(
        <div> 
            <h1>{id}</h1>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> setShowChangePage(!ShowChangePage)}>Edit Page</button>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onDelete(page.id)}>Delete Page</button>    
            <UserBio bio = {page.bio}/>
            {page.galleryID != '' &&<UserGallery gallery = {page.galleryID} onAddPhoto={onAddPhoto} onDeletePhoto={onDeletePhoto}/>}
            {ShowChangePage && <ChangePage id={page.id} onChange={onChange}/>}   
        </div>
    );
};

export default SubPageContainer;