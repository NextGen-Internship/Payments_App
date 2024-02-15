import React,{Component, useState, forwardRef, useRef, useEffect} from "react";
import './UserPage.css';
import SubPageLister, {SubPageListerRef} from "../SubPageLister/SubPageLister";
import PageAdd from "../../PageAdd/PageAdd";
import {useParams, useNavigate} from "react-router-dom"
import StripeCheckout from "../../Stripe/StripeCheckout";
import ChangePage from "../../ChangePage/ChangePage";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography'
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import PageNavigator from '../PageNavigator'


const UserPage = () =>{
    
    
    const{id} = useParams();
    const val = parseInt(id!);
    
    const[showAddPage,setAddPage] = useState(false);
    const [User,setUser] = useState<any>({});
    const [Upages,setPages] = useState<any>([]);
    const [selectedPage, setSelectedPage] = useState<number | null>(null);
    
    const navigate = useNavigate();

    useEffect(()=>{
        const getUser =async () => {
            try
            {
                const userFromServer = await fetchUser();
                const pagesFromServer = await fetchPages();
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

    const fetchPages = async()=>{
        const res = await fetch(`https://localhost:7191/api/Page/GetByUserID/${val}`);
        const pageData = await res.json();
        console.log(pageData);
        return pageData;
    }

    const PageRef = useRef<SubPageListerRef>(null);
    
    const Try = ()=>{
        setAddPage(!showAddPage);
        console.log(showAddPage);
    }


    const addPage = async (bio:any) =>{
        const qr = Math.floor(Math.random()*1000)+1; // to fix
        try {
            const response = await fetch('https://localhost:7191/api/Page/Post', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    id:0,
                    bio,
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
            const res = await fetchPages();
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
            const res = await fetchPages();
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
            const res = await fetchPages();
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

    const onSelectedPage = (pageId: number) => {
        setSelectedPage(pageId);
        //navigate(`${window.location.pathname}/${pageId}`);
      };

    // useEffect(() => {
    // if (selectedPage !== null) {
    //     navigate(`/explore/${User.id}/${selectedPage}`);
    //     setSelectedPage(null);
    // }
    // }, [selectedPage, navigate]);

    return (
        <div>
          {showAddPage && <PageAdd onAdd={addPage} />}
          
          {/* User Info and SubPageLister Container */}
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            {/* User Info Container */}
            <div className="user-info-container" style={{ display: 'flex', alignItems: 'flex-end', flex: 1 }}>
              {/* User Image Container */}
              <div className="user-image-container" style={{ margin: '30px'}}>
                <img
                  style={{ height: '225px', width: '225px', borderRadius: '50%'}}
                  src={User.pictureURL}
                  alt="userPicture"
                />
              </div>
          
              {/* User Details */}
              <div className="user-details" style={{ textAlign: 'left', marginLeft: '5px'}}>
                <Typography variant="h4" component="div" style={{ marginBottom: '10px' }}>
                  {User.username}
                </Typography>
                <Typography component="div" style={{ fontSize: 14, textDecoration: '' }} color="text.secondary" gutterBottom>
                  {`${User.firstName} ${User.lastName}`}
                </Typography>
              </div>
            </div>
          
            {/* SubPageLister Container */}
            <div className="show-pages-button" style={{ flex: 1, textAlign: 'right', width: '35%', marginRight: '%' }}>
              <SubPageLister ref={PageRef} pages={Upages} onSelectedPage={onSelectedPage}/>
            </div>
          </div>
      
          {/* New Container Div for PageNavigator */}
          <div style={{ marginTop: '40%' }}>
            {selectedPage != null && (
              <div>
                <PageNavigator pageId={selectedPage} userId={User.id} />
              </div>
            )}
          </div>
      
          {/* Stripe Checkout Component */}
          <StripeCheckout userID={User.id} />
        </div>
      );
      
      
      
};
export default UserPage;