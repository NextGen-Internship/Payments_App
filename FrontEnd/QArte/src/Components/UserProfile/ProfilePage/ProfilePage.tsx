import React, { useState, useRef, useEffect } from "react";
import "./ProfilePage.css";
import ProfileSubPageLister, {
  SubPageListerRef,
} from "../ProfileSubPageLister/ProfileSubPageLister";
import PageAdd from "../PageAdd/PageAdd";
import { useNavigate } from "react-router-dom";
import StripeCheckout from "../../Stripe/StripeCheckout";
import Typography from "@mui/material/Typography";
import PageNavigator from "../ProfilePageNavigator";
import IconButton from "@mui/material/IconButton";
import EditIcon from "@mui/icons-material/Edit";
import Input from "@mui/material/Input";
import Button from "@mui/material/Button";
import CircularProgress from "@mui/material/CircularProgress";
import Box from "@mui/material/Box";

const ProfilePage = () => {
  const Uid = localStorage.getItem("userId");
  const val = Uid;

  const [showAddPage, setAddPage] = useState(false);
  const [User, setUser] = useState<any>({});
  const [Upages, setPages] = useState<any>([]);
  const [selectedPage, setSelectedPage] = useState<number | null>(null);

  const navigate = useNavigate();

  useEffect(() => {
    const getUser = async () => {
      try {
        console.log("val " + val);
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
      `https://localhost:7191/api/User/GetUserByID/${val}`
    );
    const userData = await res.json();
    console.log(userData);
    return userData;
  };
  const fetchUserID = async () => {
    const res = await fetch(
      `https://localhost:7191/api/User/GetUserByID/${User.id}`
    );
    const userData = await res.json();
    console.log(userData);
    return userData;
  };

  const fetchPages = async (id: number) => {
    const res = await fetch(
      `https://localhost:7191/api/Page/GetByUserID/${id}`
    );
    const pageData = await res.json();
    console.log(pageData);
    return pageData;
  };

  const PageRef = useRef<SubPageListerRef>(null);

  const Try = () => {
    setAddPage(!showAddPage);
    console.log(showAddPage);
  };

  const addPage = async (bio: any) => {
    const qr = Math.floor(Math.random() * 1000) + 1; // to fix
    //const qr = window.location.href;
    try {
      const response = await fetch("https://localhost:7191/api/Page/Post", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
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
      console.log("Page added successfully:", data);
      console.log("THe full data", res);
    } catch (error) {
      console.error("Error adding page:", error);
    }
  };

  const deletePageFetch = async (id: any) => {
    try {
      console.log("Deleting page: " + id);

      const response = await fetch(
        `https://localhost:7191/api/Page/DeleteByID/${id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error(`Failed to delete page. Status: ${response.status}`);
      }
      const res = await fetchPages(User.id);
      setPages(res);
      console.log("Page deleted successfully.");
    } catch (error) {
      console.error("Error deleting page:", error);
    }
  };

  const deletePage = async (id: any) => {
    deletePageFetch(id);

    console.log(Upages);
  };

  const changePageFetch = async (page: any) => {
    try {
      console.log("Updating page: ", page);

      const response = await fetch(
        `https://localhost:7191/api/Page/PatchByID/${page.id}`,
        {
          method: "PATCH",
          headers: {
            "Content-Type": "application/json",
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
      console.log("Page updated successfully.");

      // If you want to update the UI or perform other actions after the update, add them here.
    } catch (error) {
      console.error("Error updating page:", error);
    }
  };

  const changePage = (page: any) => {
    changePageFetch(page);
    // setPages(Upages);
    //PageRef.current.Awake(Upages[awake].id);
    console.log(Upages);
  };

  const UploadPhoto = async (file: any) => {
    try {
      const formData = new FormData();
      formData.append("formFile", file);
      formData.append("id", String(User.id));
      const response = await fetch(
        `https://localhost:7191/api/User/ProfilePicture/${User.id}`,
        {
          method: "PATCH",
          headers: {},
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
      console.log("Page added successfully:", data);
      console.log("THe full data", res);
    } catch (error) {
      console.error("Error adding page:", error);
    }
  };

  const handleOnChange = async (e: any) => {
    let target = e.target.files;
    AddPhoto(target[0]);
    console.log("file", target);
    let v = window.location.href;
    console.log(v);
  };

  const AddPhoto = async (file: any) => {
    if (file == undefined) {
      alert("Choose an image");
    } else {
      console.log(file);
      UploadPhoto(file);
    }
  };

  const DeleteUser = async () => {
    try {
      console.log("Deleting user: " + User.id);

      const response = await fetch(
        `https://localhost:7191/api/User/DeleteByID/${User.id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error(`Failed to delete user. Status: ${response.status}`);
      }
      window.location.href = `http://localhost:5173/home`;
      console.log("User deleted successfully.");
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
      {/* User Info and SubPageLister Container */}
      <div style={{ textAlign: "center" }}>
        {/* User Image Container */}
        <div
          className="user-image-container"
          style={{
            marginTop: "20px",
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <div
            className="delete-user-button"
            style={{ marginLeft: "auto", marginRight: "2%" }}
          >
            <Button
              variant="contained"
              style={{ backgroundColor: "red", color: "white" }}
              onClick={DeleteUser}
            >
              Delete User
            </Button>
          </div>
          <div style={{ textAlign: "center" }}>
            <img
              style={{ height: "225px", width: "225px", borderRadius: "50%" }}
              src={User.pictureURL}
              alt="userPicture"
            />
          </div>
          <div className="Edit-user-image">
            <label htmlFor="profile-picture-upload">
              <Input
                id="profile-picture-upload"
                type="file"
                name="image"
                onChange={handleOnChange}
                style={{ display: "none" }}
              />
              <IconButton
                size="large"
                title="Edit profile picture"
                component="span"
                style={{ color: "blue" }}
              >
                <EditIcon />
              </IconButton>
            </label>
          </div>
        </div>

        {/* User Details */}
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

      <div>
        <a
          className="show-pages-dropdown"
          style={{ textAlign: "center", width: "35%", marginRight: "3%" }}
        >
          <ProfileSubPageLister
            ref={PageRef}
            pages={Upages}
            onSelectedPage={onSelectedPage}
            onAddPage={onAddPage}
            userID={User.id}
          />
        </a>

        {showAddPage && <PageAdd onAdd={addPage} />}

        {selectedPage != null && (
          <div>
            <PageNavigator pageId={selectedPage} userId={User.id} />
          </div>
        )}
      </div>
    </div>
  );
};
export default ProfilePage;
