import React,{Component, useState, forwardRef, useRef, useEffect} from "react";
import './UserPage.css';
import SubPageLister, {SubPageListerRef} from "../SubPageLister/SubPageLister";
import PageAdd from "../PageAdd/PageAdd";
import {useParams, useNavigate} from "react-router-dom"
import StripeCheckout from "../Stripe/StripeCheckout";

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

const UserPage = ({user}:any) =>{

    const navigate=useNavigate();

    const{id} = useParams();
    const val = parseInt(id!);

    const[showAddPage,setAddPage] = useState(false);
    const [User,setUsers] = useState<any>({});
    const [Upages,setPages] = useState<any>([]);


    useEffect(()=>{
        const getUser = async() =>{
            try{
                await fetchUser();
            }
            catch(error){
                console.error('Error fetching user data!',error);
            }
        }
        getUser()
    },[user]);

    const fetchUser =async () => {
        try {
            const foundUser = user.find((u: any) => u.id === val);
            if (foundUser) {
                setUsers(foundUser);
                setPages(foundUser.page);
            } else {
                console.error(`User with id ${val} not found.`);
            }
        } catch (error) {
            console.error('Error fetching user data!', error);
        }
    }


    const PageRef = useRef<SubPageListerRef>(null);
    
    const Try = ()=>{
        setAddPage(!showAddPage);
        console.log(showAddPage);
    }

    const addPage = (page:any):void =>{
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
            if(PageRef.current){
                PageRef.current.Awake(Upages[Upages.length-1].id);}
        }
        else
        {
            console.log("you have this page");
        }
        setPages(Upages);
        console.log(Upages);
    }

   const deletePage = (id:any) =>{
        console.log("Deleting page: "+id)
        for(var i =0;i<Upages.length;i++){
            if(Upages[i].id==id){
                Upages.splice(i,1);
            }
        }
        
        setPages(Upages.filter((page:any)=>page.id!==id));
        if(PageRef.current)
            PageRef.current.Awake(Upages[0].id);
        console.log(Upages);
    }

    const changePage = (page:any) =>{       

        setPages(Upages.map((spage:any)=>{
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
        // navigate('/home');
       console.log(user); 
       console.log(User);
       console.log("pages ");
       console.log(Upages);       
       console.log(Upages[0].bio);
    }
    
    const addNewPhoto=(newPhoto:any)=>{
        console.log("adding a new photo " + newPhoto);
    }

    const deletePhoto=(deletedPhot:any)=>{
        console.log("deleting "+ deletedPhot);
    }

    return(
        <div>
            <button className="btn" style={{backgroundColor:"green"}} onClick={donateFunds}>Donate</button>
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
            <StripeCheckout></StripeCheckout>
        </div>
    );
};
export default UserPage;