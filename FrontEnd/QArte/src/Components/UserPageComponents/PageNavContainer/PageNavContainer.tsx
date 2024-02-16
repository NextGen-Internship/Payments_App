import PageNavButtons from "../PageNavButtons/PageNavButtons";

const PageNavContainer = ({pages, index,onShow}:any)=>{
    return(
        <div>
            <PageNavButtons index={index} page={pages} onShow={onShow}/>
        </div>
    );
}
export default PageNavContainer;