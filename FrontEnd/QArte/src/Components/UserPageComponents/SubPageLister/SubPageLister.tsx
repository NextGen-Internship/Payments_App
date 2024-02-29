import { useEffect, useImperativeHandle } from "react";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";
import { Outlet, useNavigate } from "react-router-dom";
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import Button from '@mui/material/Button';
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';

import './SubPageLister.css'

    export interface SubPageListerRef {
      Awake: (id: any) => void;
    }

const SubPageLister = forwardRef(({ pages, onSelectedPage, onAddPage, userID }:any,ref) =>{

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
           
          setAwakePage(i);
        }
      }
       
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

      const menuItemWidth = document.getElementById('show-pages-button')?.offsetWidth;
      return (
        <>
          <div id="PageNav">
            <Button
              id="show-pages-button"
              variant="contained"
              endIcon={<ArrowDropDownIcon />}
              onClick={handleMenuClick}>
              Show Pages
            </Button>
          </div>
      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleMenuClose}
      >
        {pages.map((page: any, index: number) => (
          <MenuItem key={index} style={{ width: menuItemWidth }} onClick={() => { handleMenuItemClick(page.id) }}>
            <div style={{ width: '100%' }}>
              <PageNavContainer pages={page} index={index} onShow={onShow} />
            </div>
          </MenuItem>
        ))}
      </Menu>
      <Outlet />
    </>
  );
      
})
export default SubPageLister;