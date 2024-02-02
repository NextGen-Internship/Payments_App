import React from "react";
import PageNavButtons from "../PageNavButtons/PageNavButtons";

const PageNavContainer = ({pages,onShow}:any)=>{
    return(
        <div>
        {pages.map((page:any,index:any)=>(
            <PageNavButtons key={index} index={index} id={page.id} onShow={onShow}/>
        ))}
        </div>
    )
}
export default PageNavContainer;