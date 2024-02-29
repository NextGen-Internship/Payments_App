import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import {
  useEffect,
  useRef,
  useState
} from "react";
import { useNavigate, useParams } from "react-router-dom";
import StripeCheckout from "../../Stripe/StripeCheckout";
import PageNavigator from "../PageNavigator";
import SubPageLister, {
  SubPageListerRef,
} from "../SubPageLister/SubPageLister";
import "./UserPage.css";

const UserPage = () => {
  const { Uid } = useParams();
  const val = parseInt(Uid!);


  const [showAddPage, setAddPage] = useState(false);
  const [User, setUser] = useState<any>({});
  const [Upages, setPages] = useState<any>([]);
  const [selectedPage, setSelectedPage] = useState<number | null>();

  const navigate = useNavigate();
  const baseUrl = import.meta.env.VITE_BASE_URL;
  useEffect(() => {
    const getUser = async () => {
      try {
         
        const userFromServer = await fetchUser();
        const pagesFromServer = await fetchPages(userFromServer.id);
        setUser(userFromServer);
        setPages(pagesFromServer);

      } catch (error) {
        console.error("Error fetching user data!", error);
      }
    };
    getUser();
  }, []);

  const fetchUser = async () => {
    const res = await fetch(
      `${baseUrl}/api/User/GetUserByID/${val}`,{
      method: 'GET',
      headers:{
        'ngrok-skip-browser-warning': '1'
      }
    }
    );
    const userData = await res.json();
     
    return userData;
  };
  const fetchUserID = async () => {
    const res = await fetch(
      `${baseUrl}/api/User/GetUserByID/${User.id}`,{
        method: 'GET',
        headers:{
          'ngrok-skip-browser-warning': '1'
        }
      }
    );
    const userData = await res.json();
     
    return userData;
  };

  const fetchPages = async (id: number) => {
    const res = await fetch(
      `${baseUrl}/api/Page/GetByUserID/${id}`,{
        method: 'GET',
        headers:{
          'ngrok-skip-browser-warning': '1'
        }
      }
    );
    const pageData = await res.json();
     
    return pageData;
  };

  const PageRef = useRef<SubPageListerRef>(null);

  const Try = () => {
    setAddPage(!showAddPage);
     
  };

  const addPage = async (bio: any) => {
    const qr = Math.floor(Math.random() * 1000) + 1; // to fix
    //const qr = window.location.href;
    try {
      const response = await fetch(`${baseUrl}/api/Page/Post`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          'ngrok-skip-browser-warning': '1'
        },
        body: JSON.stringify({
          id: 0,
          bio: bio.bio,
          PageName: bio.name,
          qrLink: qr.toString(),
          galleryID: 0,
          userID: User.id,
        }),
      });
      const data = await response.json();
      if (!response.ok) {
        console.error("Failed to add page:", data);
        throw new Error(`Failed to add page. Status: ${response.status}`);
      }
      const res = await fetchPages(User.id);
      setPages(res);
      setAddPage(false);
       
       
    } catch (error) {
      console.error("Error adding page:", error);
    }
  };

  const deletePageFetch = async (id: any) => {
    try {
       

      const response = await fetch(
        `${baseUrl}/api/Page/DeleteByID/${id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
            'ngrok-skip-browser-warning': '1'
          },
        }
      );

      if (!response.ok) {
        throw new Error(`Failed to delete page. Status: ${response.status}`);
      }
      const res = await fetchPages(User.id);
      setPages(res);
       
    } catch (error) {
      console.error("Error deleting page:", error);
    }
  };

  const deletePage = async (id: any) => {
    deletePageFetch(id);

     
  };

  const changePageFetch = async (page: any) => {
    try {
       

      const response = await fetch(
        `${baseUrl}/api/Page/PatchByID/${page.id}`,
        {
          method: "PATCH",
          headers: {
            "Content-Type": "application/json",
            'ngrok-skip-browser-warning': '1'
          },
          body: JSON.stringify({
            id: page.id,
            bio: page.bio,
            qrLink: "string",
          }),
        }
      );

      if (!response.ok) {
        const errorDetails = await response.json();
        console.error(
          `Failed to update page. Status: ${response.status}. Details:`,
          errorDetails
        );
        throw new Error(`Failed to update page. Status: ${response.status}`);
      }
      const res = await fetchPages(User.id);
      setPages(res);
       

   
    } catch (error) {
      console.error("Error updating page:", error);
    }
  };

  const changePage = (page: any) => {
    changePageFetch(page);
 
     
  };

  const UploadPhoto = async (file: any) => {
    try {
      const formData = new FormData();
      formData.append("formFile", file);
      formData.append("id", String(User.id));
      const response = await fetch(
        `${baseUrl}/api/User/ProfilePicture/${User.id}`,
        {
          method: "PATCH",
          headers: {'ngrok-skip-browser-warning': '1'},
          body: formData,
        }
      );
      const data = await response.json();
      if (!response.ok) {
        console.error("Failed to add page:", data);
        throw new Error(`Failed to add page. Status: ${response.status}`);
      }
      const res = await fetchUserID();
      setUser(res);
       
       
    } catch (error) {
      console.error("Error adding page:", error);
    }
  };

  const handleOnChange = async (e: any) => {
    let target = e.target.files;
    AddPhoto(target[0]);
     
    let v = window.location.href;
     
  };

  const AddPhoto = async (file: any) => {
    if (file == undefined) {
      alert("Choose an image");
    } else {
       
      UploadPhoto(file);
    }
  };

  const DeleteUser = async () => {
    try {
       

      const response = await fetch(
        `${baseUrl}/api/User/DeleteByID/${User.id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
            'ngrok-skip-browser-warning': '1'
          },
        }
      );

      if (!response.ok) {
        throw new Error(`Failed to delete user. Status: ${response.status}`);
      }
      window.location.href = `${baseUrl}/home`;
       
    } catch (error) {
      console.error("Error deleting user:", error);
    }
  };
  const onSelectedPage = (pageId: number) => {
    setSelectedPage(pageId);
  };

  const onAddPage = (set: boolean) => {
    setAddPage(set);
  };

  return (
    <div className="top-of-page">
      <div style={{ textAlign: "center" }}>
        <div
          className="user-image-container"
          style={{
            marginTop: "40px",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <div style={{ textAlign: "center" }}>
          <CardMedia
              component="img"
              sx={{
                width: 180,
                height: 180,
                borderRadius: "50%",
                marginRight: "20px",
                objectFit: "cover",
                "@media (max-width:600px)": {
                  width: 140,
                  height: 140,
                },
              }}
              image={User.pictureURL}
              alt="User Picture"
            />
          </div>
        </div>

    <div className="user-details" style={{ marginTop: "10px" }}></div>

        <Typography
          variant="h4"
          component="div"
          style={{ marginBottom: "10px" }}
        >
          {User.username}
        </Typography>
        <Typography
          component="div"
          style={{ fontSize: 14, textDecoration: "" }}
          color="text.secondary"
          gutterBottom
        >
          {`${User.firstName} ${User.lastName}`}
        </Typography>
      </div>
      <StripeCheckout userID={User.id} />
      <div>
        <a
          className="show-pages-dropdown"
          style={{ textAlign: "center", width: "35%", marginRight: "3%" }}
        >
          <SubPageLister
            ref={PageRef}
            pages={Upages}
            onSelectedPage={onSelectedPage}
            onAddPage={onAddPage}
            userID={User.id}
          />
        </a>

        {selectedPage != null && (
          <div>
            <PageNavigator pageId={selectedPage} userId={User.id} />
          </div>
        )}
      </div>
    </div>
  );
};
export default UserPage;
