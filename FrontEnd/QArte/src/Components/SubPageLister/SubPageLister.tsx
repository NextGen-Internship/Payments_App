import { useEffect, useImperativeHandle } from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";

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
      console.log(id);
    };
  
    useImperativeHandle(ref, () => ({
      Awake: onShow,
    }));


    return(
        // <div>
        //     {pages.map((page,index)=>(
        //         <ul key={index}>
        //             <NavLink to={`${page.id}`}>
        //                 <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onID(page.id)}>
        //                     Page {page.id}
        //                 </button>
        //             </NavLink>
        //         </ul>
        //     ))}
        // </div>
        <>
            <PageNavContainer pages={Pages} onShow={onShow}/>
            {Pages.length > 0 && <SubPageContainer page={Pages[awakePage]} onDelete={onDelete} onChange={onChange} onAddPhoto={onAddPhoto} onDeletePhoto={onDeletePhoto}/>}
            {/* <Routes path="/home-page/*">
                <Route path={`${Userid}'/'${pages[awakePage].id}`} element={<SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>}/>
            </Routes> */}
        </>
    )
})
export default SubPageLister;