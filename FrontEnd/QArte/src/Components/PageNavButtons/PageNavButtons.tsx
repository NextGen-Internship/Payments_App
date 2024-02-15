import React from "react";
import './PageNavButtons.css';


const PageNavButtons = ({page,onShow, index}:any) =>{

    return(
        <>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onShow(page.id)}>{page.pageName}</button>
        </>
    )


}
export default PageNavButtons;