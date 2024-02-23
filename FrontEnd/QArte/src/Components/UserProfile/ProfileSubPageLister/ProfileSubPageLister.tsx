import { useEffect, useImperativeHandle } from "react";
import { useState , forwardRef} from "react";
import ProfilePageNavContainer from "../ProfilePageNavContainer/ProfilePageNavContainer";
import { NavLink, Route, Routes, Outlet, useNavigate } from "react-router-dom";
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import Button from '@mui/material/Button';
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';
import MenuList from '@mui/material/MenuList';
import AddIcon from '@mui/icons-material/Add';
import './ProfileSubPageLister.css';

    export interface SubPageListerRef {
      Awake: (id: any) => void;
    }

const ProfileSubPageLister = forwardRef(({ pages, onSelectedPage, onAddPage, userID }:any,ref) =>{

    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const [awakePage, setAwakePage] =useState<number>(0);
    const [Pages,setPages] = useState<any>([]);
    const navigate = useNavigate();

    useEffect(()=>{
      const getPages = async() =>{
          try{
              await fetchPage();
          }
          catch(error){
              console.error('Error fetching user data!',error);
          }
      }
      getPages()
  },[pages]);

  const fetchPage =async () => {
      try {
          const foundPage = pages;
          if (foundPage) {
              setPages(foundPage);
              setAwakePage(0);
              console.log("here");
              console.log(foundPage);
              console.log(awakePage);
          } else {
              console.error(`User with id ${awakePage} not found.`);
          }
      } catch (error) {
          console.error('Error fetching user data!', error);
      }
  }

    const onShow = (id:any) => {
      for(var i=0; i<Pages.length; i++){
        if(pages[i].id === id){
          console.log(pages[i]);
          setAwakePage(i);
        }
      }
      console.log("We change apge")
    };
  
    useImperativeHandle(ref, () => ({
      Awake: onShow,
    }));


    const handleMenuClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
      };
    
      const handleMenuClose = () => {
        setAnchorEl(null);
      };

      const handleMenuItemClick = (pageId: number) => {
        handleMenuClose();
        onAddPage(false);
        onSelectedPage(pageId);
      };

      const handleAddPageClick = () => {
        handleMenuClose();
        navigate(`/profile`);
        onSelectedPage(null);
        onAddPage(true);
      };

      const menuItemWidth = document.getElementById('show-pages-button')?.offsetWidth;
      return (
        <>
          {/* Container to center the button */}
          <div id="PageNav">
            {/* Dropdown menu trigger button */}
            <Button
              id="show-pages-button"
              variant="contained"
              endIcon={<ArrowDropDownIcon />}
              onClick={handleMenuClick}>
              Show Pages
            </Button>
          </div>
      
      {/* Dropdown menu */}
      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleMenuClose}
      >
        {pages.map((page: any, index: number) => (
          <MenuItem key={index} style={{ width: menuItemWidth }} onClick={() => { handleMenuItemClick(page.id) }}>
            <div style={{ width: '100%' }}>
              <ProfilePageNavContainer pages={page} index={index} onShow={onShow} />
            </div>
          </MenuItem>
        ))}
        {/* "Add page" button */}
        <MenuItem style={{ width: menuItemWidth }} onClick={handleAddPageClick}>
          <div style={{ width: '100%', backgroundColor: 'transparent'}}>
            <Button variant="text" color="primary" fullWidth> 
              Add Page
              <AddIcon style={{ marginLeft: 'auto' }} />
            </Button>
          </div>
        </MenuItem>
      </Menu>
      <Outlet />
    </>
  );
      
})
export default ProfileSubPageLister;