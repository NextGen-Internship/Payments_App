import React, { useImperativeHandle } from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";

const SubPageLister = forwardRef(({ pages, onDelete, onChange},ref) =>{

    const [awakePage, setAwakePage] = useState(0);

    useImperativeHandle(ref,()=>({
        Awake:onShow,
    }));

    const onShow = (id) =>{
        for(var i=0; i<pages.length;i++){
            if(pages[i].id==id){
                setAwakePage(i);   
            }
        }
        console.log(id);
    }


    return(
        // <>
    
        // {pages.map((page,index)=>(
        //     <li key={index}>
        //         <NavLink to={`${page.id}`}>
        //             <h1>{page.id}</h1>
        //             {/* <SubPageContainer page={page} onDelete={onDelete} onChange={onChange}/>  */}
        //         </NavLink>
        //     </li>
            
        // ))}
        // </>
        <>
            <PageNavContainer pages={pages} onShow={onShow}/>
            <SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>
            {/* <Routes path="/home-page/*">
                <Route path={`${Userid}'/'${pages[awakePage].id}`} element={<SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>}/>
            </Routes> */}
        </>
    )
})
export default SubPageLister;