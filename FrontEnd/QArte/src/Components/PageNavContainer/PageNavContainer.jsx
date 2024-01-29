import React from "react";
import PageNavButtons from "../PageNavButtons/PageNavButtons";

const PageNavContainer = ({pages,onShow})=>{
    return(
        <div>
        {pages.map((page,index)=>(
            <PageNavButtons key={index} id={page.id} onShow={onShow}/>
        ))}
        </div>
    )
}
export default PageNavContainer;