import { useEffect, useImperativeHandle } from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";
import { NavLink, Route, Routes, Outlet } from "react-router-dom";

    export interface SubPageListerRef {
      Awake: (id: any) => void;
    }

const SubPageLister = forwardRef(({ pages, onDelete, onChange, onAddPhoto, onDeletePhoto}:any,ref) =>{

    const [awakePage, setAwakePage] =useState<number>(0);
    const [Pages,setPages] = useState<any>([]);

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


    return(
        // //do a nav type page browsing
        <div>
            {/* <PageNavContainer pages={Pages} onShow={onShow}/> */}
            {/* {Pages.length > 0 && <SubPageContainer page={Pages[awakePage]} onDelete={onDelete} onChange={onChange} onAddPhoto={onAddPhoto} onDeletePhoto={onDeletePhoto}/>}  */}
            {pages.map((page:any,index:number)=>(
                <ul key={index}>
                    <NavLink to={`${page.id}`}>
                        <PageNavContainer pages={page} index={index} onShow={onShow}/>
                    </NavLink>
                </ul>
            ))}     
            <Outlet/>       
            {/* <Routes>
                <Route path={`${pages.userID}'/'${awakePage}`} element={<SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>}/>
            </Routes> */}
        </div>
        // <>
        //     


        // </>
    )
})
export default SubPageLister;