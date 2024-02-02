import React from "react";
import './PageNavButtons.css';


const PageNavButtons = ({id,onShow, index}:any) =>{

    return(
        <>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onShow(id)}>Page {index+1}</button>
        </>
    )


}
export default PageNavButtons;