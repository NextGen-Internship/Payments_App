import React from "react";
import './PageNavButtons.css';


const PageNavButtons = ({id,onShow}) =>{

    return(
        <>
            <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onShow(id)}>Page</button>
        </>
    )


}
export default PageNavButtons;