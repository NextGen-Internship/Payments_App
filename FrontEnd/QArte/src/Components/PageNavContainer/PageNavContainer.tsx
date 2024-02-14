import React from "react";
import PageNavButtons from "../PageNavButtons/PageNavButtons";

const PageNavContainer = ({pages, index,onShow}:any)=>{
    return(
        <div>
            <PageNavButtons index={index} id={pages.id} onShow={onShow}/>
        </div>
    )
}
export default PageNavContainer;