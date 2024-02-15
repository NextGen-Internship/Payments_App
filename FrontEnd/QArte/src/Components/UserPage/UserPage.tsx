import React,{Component, useState, forwardRef, useRef, useEffect} from "react";
import './UserPage.css';
import SubPageLister, {SubPageListerRef} from "../SubPageLister/SubPageLister";
import PageAdd from "../PageAdd/PageAdd";
import {useParams, useNavigate, useLocation} from "react-router-dom"
import StripeCheckout from "../Stripe/StripeCheckout";
import ChangePage from "../ChangePage/ChangePage";

// const user = {
//     name: 'John Doe',
//     id: 1,
//     profilePicture: 'path/to/profile.jpg',
//     page:[
//         {
//             id: 1,
//             bio: 'A brief bio about John Doe.',
//             photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
//         },
//         {
//             id: 2,
//             bio: 'We are doing it!.',
//             photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
//         },
//     ]
//   };

const UserPage = () =>{

    const navigate=useNavigate();

    const{id} = useParams();
    const val = parseInt(id!);

    const[showAddPage,setAddPage] = useState(false);
    const [User,setUser] = useState<any>({});
    const [Upages,setPages] = useState<any>([]);
    const [file,setFile] = useState();


    useEffect(()=>{
        const getUser =async () => {
            try
            {
                console.log("val "+val)
                const userFromServer = await fetchUser();
                const pagesFromServer = await fetchPages(userFromServer.id);
                setUser(userFromServer);
                setPages(pagesFromServer);
            }
            catch(error)
            {
                console.error('Error fetching user data!', error);
            }
        }
        getUser();
    },[]);

    const fetchUser = async()=>{
        const res = await fetch(`https://localhost:7191/api/User/GetUserByID/${val}`);
        const userData = await res.json();
        console.log(userData);
        return userData;
    }
    const fetchUserID = async()=>{
        const res = await fetch(`https://localhost:7191/api/User/GetUserByID/${User.id}`);
        const userData = await res.json();
        console.log(userData);
        return userData;
    }

    const fetchPages = async(id:number)=>{
        const res = await fetch(`https://localhost:7191/api/Page/GetByUserID/${id}`);
        const pageData = await res.json();
        console.log(pageData);
        return pageData;
    }

    // useEffect(()=>{
    //     const getUser = async() =>{
    //         try{
    //             await fetchUser();
    //         }
    //         catch(error){
    //             console.error('Error fetching user data!',error);
    //         }
    //     }
    //     getUser()
    // },[user]);

    // const fetchUser =async () => {
    //     try {
    //         const foundUser = user.find((u: any) => u.id === val);
    //         if (foundUser) {
    //             setUser(foundUser);
    //             setPages(foundUser.page);
    //         } else {
    //             console.error(`User with id ${val} not found.`);
    //         }
    //     } catch (error) {
    //         console.error('Error fetching user data!', error);
    //     }
    // }


    const PageRef = useRef<SubPageListerRef>(null);
    
    const Try = ()=>{
        setAddPage(!showAddPage);
        console.log(showAddPage);
    }

    const addPage = async (changes:any) =>{
        // const id = Math.floor(Math.random()*1000)+1;
        // const newPage = {id,...page}
        // var go = true;

        // for(var i=0; i<Upages.length;i++){
        //     if(Upages[i].id==newPage.id){
        //         go=false;   
        //     }
        // }
        // if(go)
        // {
        //     Upages.push(newPage);
        //     if(PageRef.current){
        //         PageRef.current.Awake(Upages[Upages.length-1].id);}
        // }
        // else
        // {
        //     console.log("you have this page");
        // }
        // setPages(Upages);
        // console.log(Upages);
        const qr = Math.floor(Math.random()*1000)+1; // to fix
        //const qr = window.location.href;
        try {
            const response = await fetch('https://localhost:7191/api/Page/Post', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    id:0,
                    bio:changes.bio,
                    PageName:changes.name,
                    qrLink:qr.toString(),
                    galleryID:0,
                    userID: User.id,
                }),
            });
            const data = await response.json();
            if (!response.ok) {
                console.error('Failed to add page:', data);
                throw new Error(`Failed to add page. Status: ${response.status}`);
            }
            const res = await fetchPages(User.id);
            setPages(res);
            console.log('Page added successfully:', data);
            console.log("THe full data", res);
        } catch (error) {
            console.error('Error adding page:', error);
        }
        
    }

    const deletePageFetch = async (id: any) => {
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
            const res = await fetchPages(User.id);
            setPages(res);
            console.log('Page deleted successfully.');

        } catch (error) {
            console.error('Error deleting page:', error);
        }
    };

   const deletePage = async (id:any) =>{

        deletePageFetch(id);

        console.log(Upages);
    }

    const changePageFetch = async (page: any) => {
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
            const res = await fetchPages(User.id);
            setPages(res);
            console.log('Page updated successfully.');
    
            // If you want to update the UI or perform other actions after the update, add them here.
        } catch (error) {
            console.error('Error updating page:', error);
            
        }
    };
    

    const changePage = (page:any) =>{       
        changePageFetch(page);
        // setPages(Upages);
        //PageRef.current.Awake(Upages[awake].id);
        console.log(Upages);
    }

    const UploadPhoto = async (file:any)=>{
        try {
            const formData = new FormData();
            formData.append("formFile",file);
            formData.append("id",String(User.id));
            const response = await fetch(`https://localhost:7191/api/User/ProfilePicture/${User.id}`, {
                method: 'PATCH',
                headers: {

                },
                body: formData
            });
            const data = await response.json();
            if (!response.ok) {
                console.error('Failed to add page:', data);
                throw new Error(`Failed to add page. Status: ${response.status}`);
            }
            const res = await fetchUserID();
            setUser(res);
            console.log('Page added successfully:', data);
            console.log("THe full data", res);
        } catch (error) {
            console.error('Error adding page:', error);
        }
    }

    const handleOnChange = async(e:any)=>{
        let target = e.target.files;
        console.log('file', target);
        let v = window.location.href;
        console.log(v);
        setFile(target[0]);
    }

    const AddPhoto = async()=>{
        if(file==undefined){
            alert("Choose an image")
        }
        else
        {
            console.log(file);
            UploadPhoto(file);
        }
    }

    const DeleteUser = async ()=>
    {
        try {
            console.log("Deleting user: " + User.id);
    
            const response = await fetch(`https://localhost:7191/api/User/DeleteByID/${User.id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
    
            if (!response.ok) {
                throw new Error(`Failed to delete user. Status: ${response.status}`);
            }
            window.location.href = `http://localhost:5174/explore`;
            console.log('User deleted successfully.');
        } catch (error) {
            console.error('Error deleting user:', error);
        }
    }
    

    return(
        <div>
            <button className="btn" style={{backgroundColor:"green"}} onClick={DeleteUser} >Delete User</button>
            <div className="container">
                <button className="btn" style={{backgroundColor:"green"}} onClick={Try} >Add Page</button>
                {showAddPage && <PageAdd onAdd={addPage}/>}
                <div className="container">    
                    <img src={User.pictureURL} alt="Profile" />
                    <h2>{User.firstName+" "+User.lastName}</h2>
                    <input type="file" name="image" accept=".jpeg, .png" onChange={handleOnChange}></input> 
                    <button className="btn" style={{backgroundColor:"green"}} onClick={AddPhoto} >Change Profile Picture</button>
                </div>
                <SubPageLister ref={PageRef} pages={Upages} />
            </div>
            <StripeCheckout userID = {User.id}></StripeCheckout>
        </div>
    );
};
export default UserPage;