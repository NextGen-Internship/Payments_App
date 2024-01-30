import React, { useImperativeHandle } from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState , forwardRef} from "react";
import PageNavContainer from "../PageNavContainer/PageNavContainer";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

const SubPageLister = forwardRef(({Userid, pages, onDelete, onChange},ref) =>{

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
        //        <SubPageContainer key={index} page={page} onDelete={onDelete} onChange={onChange}/> 
            
        // ))}
        // </>
        <>
            <PageNavContainer pages={pages} onShow={onShow}/>
            <Routes>
                <Route path={`'/'${Userid}'/'${pages[awakePage].id}`} element={<SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>}/>
            </Routes>
        </>
    )
})
export default SubPageLister;