import React,{Component, useState, forwardRef, useRef} from "react";
import './UserPage.css';
import SubPageLister from "../SubPageLister/SubPageLister";
import PageAdd from "../PageAdd/PageAdd";
import {useParams} from "react-router-dom"

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

const UserPage = ({user}) =>{

    const{id} = useParams();

    const[showAddPage,setAddPage] = useState(false);
    const [User,setUsers] = useState(user);
    const [Upages,setPages] = useState(User.page);
    const [UPhotos,setPhotos] = useState(Upages.photos)

    const PageRef = useRef();
    
    const Try = ()=>{
        setAddPage(!showAddPage);
        console.log(showAddPage);
    }

    const addPage = (page) =>{
        const id = Math.floor(Math.random()*1000)+1;
        const newPage = {id,...page}
        var go = true;

        for(var i=0; i<Upages.length;i++){
            if(Upages[i].id==newPage.id){
                go=false;   
            }
        }
        if(go)
        {
            Upages.push(newPage);
            PageRef.current.Awake(Upages[Upages.length-1].id);
        }
        else
        {
            console.log("you have this page");
        }
        setPages(Upages);
        console.log(Upages);
    }

   const deletePage = (id) =>{
        console.log("Deleting page: "+id)
        for(var i =0;i<Upages.length;i++){
            if(Upages[i].id==id){
                Upages.splice(i,1);
            }
        }
        
        setPages(Upages.filter((page)=>page.id!==id));
        PageRef.current.Awake(Upages[0].id);
        console.log(Upages);
    }

    const changePage = (page) =>{       

        setPages(Upages.map(spage=>{
            if(spage.id===page.id){
                return{...page};
            }
            else{return spage};
        }))

        // let awake=0;
        for(var i=0;i<Upages.length;i++){
            console.log(Upages[i].id);
            if(Upages[i].id==page.id){
                Upages[i]=page;
                //awake=i;
            }
        }
        // setPages(Upages);
        //PageRef.current.Awake(Upages[awake].id);
        console.log(Upages);
        

    }

    const donateFunds=()=>{
        console.log("Donating");
    }
    
    const addNewPhoto=(newPhoto)=>{
        console.log("adding a new photo " + newPhoto);
    }

    const deletePhoto=(deletedPhot)=>{
        console.log("deleting "+ deletedPhot);
    }

    return(
        <div>
            <button className="btn" style={{backgroundColor:"green"}} onClick={Try} >Add Page</button>
            {showAddPage && <PageAdd onAdd={addPage}/>}
            <div className="container">
                <div className="container">
                    <img src={User.profilePicture} alt="Profile" />
                    <h2>{User.name}</h2>
                </div>
                <SubPageLister ref={PageRef} pages={Upages} onDelete={deletePage} onChange={changePage} onAddPhoto={addNewPhoto} onDeletePhoto={deletePhoto} />
                
            </div>
            <button className="btn" style={{backgroundColor:"green"}} onClick={donateFunds}>Donate</button>
        </div>
    );
};
export default UserPage;