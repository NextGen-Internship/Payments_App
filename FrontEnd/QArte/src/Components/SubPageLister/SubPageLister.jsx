import React, { useImperativeHandle } from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";
import {NavLink } from 'react-router-dom';

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
            <PageNavContainer pages={pages} onShow={onShow}/>
            <SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>
            {/* <Routes path="/home-page/*">
                <Route path={`${Userid}'/'${pages[awakePage].id}`} element={<SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>}/>
            </Routes> */}
        </>
    )
})
export default SubPageLister;