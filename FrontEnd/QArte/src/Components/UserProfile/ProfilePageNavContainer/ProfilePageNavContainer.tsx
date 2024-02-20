import ProfilePageNavButtons from "../ProfilePageNavButtons/ProfilePageNavButtons";

const ProfilePageNavContainer = ({pages, index,onShow}:any)=>{
    return(
        <div>
            <ProfilePageNavButtons index={index} page={pages} onShow={onShow}/>
        </div>
    );
}
export default ProfilePageNavContainer;