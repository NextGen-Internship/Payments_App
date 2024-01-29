import React,{Component, useState, forwardRef, useRef} from "react";
import './UserPage.css';
import SubPageLister from "../SubPageLister/SubPageLister";
import PageAdd from "../PageAdd/PageAdd";


const user = {
    name: 'John Doe',
    profilePicture: 'path/to/profile.jpg',
    page:[
        {
            id: 1,
            bio: 'A brief bio about John Doe.',
            photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
        },
        {
            id: 2,
            bio: 'We are doing it!.',
            photos: ['path/to/photo1.jpg', 'path/to/photo2.jpg', 'path/to/photo3.jpg']
        },
    ]

  };

const UserPage = () =>{

    const[showAddPage,setAddPage] = useState(false);
    const [User,setUsers] = useState(user);
    const [Upages,setPages] = useState(user.page);

    const PageRef = useRef();
    
    const Try = ()=>{
        setAddPage(!showAddPage);
        console.log(showAddPage);
    }

    const addPage = (page) =>{
        var hold = Upages;
        var go = true;
        console.log(page.id+" "+page.bio+" "+page.photos+" Added");
        for(var i=0; i<user.page.length;i++){
            if(user.page[i].id==page.id){
                go=false;   
            }
        }
        if(go)
        {
            hold.push(page);
            setPages([...Upages],page);
            PageRef.current.Awake(Upages[Upages.length-1].id);
        }
        else
        {
            console.log("you have this page");
        }
        console.log(Upages);
    }

    const deletePage = (id) =>{
        console.log("Deleting page: "+id)
        
        setPages(Upages.filter((page)=>page.id!==id));
        console.log(Upages);
        PageRef.current.Awake(Upages[0].id);
    }

    const changePage = (id) =>{
        console.log("Change page "+id)
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
                <SubPageLister ref={PageRef} pages={Upages} onDelete={deletePage} onChange={changePage} />
            </div>
        </div>
    );
};
export default UserPage;