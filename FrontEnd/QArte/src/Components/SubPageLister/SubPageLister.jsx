import React from "react";
import SubPageContainer from "../SubPageContainer/SubPageContainer";
import './SubPageLister.css';
import { useState } from "react";
import PageNavButtons from "../PageNavButtons/PageNavButtons";
import PageNavContainer from "../PageNavContainer/PageNavContainer";

const SubPageLister = ({pages, onDelete, onChange}) =>{

    const [awakePage, setAwakePage] = useState(0);

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
            <SubPageContainer page={pages[awakePage]} onDelete={onDelete} onChange={onChange}/>
        </>
    )
}

export default SubPageLister;