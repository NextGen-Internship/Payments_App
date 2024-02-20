import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import CardMedia from "@mui/material/CardMedia";

// import React from "react";
import { Box } from "@mui/material";

const OutlinedCard = ({ user }: any) => {
  return (
    <Box
      sx={{
        margin: "2% 20%", // Adjust margins for larger screens
        "@media (max-width:600px)": {
          // Media query for small screens
          margin: "2% 5%", // Reduced side margins on small screens
        },
      }}
    >
      <Card
        variant="outlined"
        sx={{
          display: "flex",
          //flexDirection: { xs: "column", sm: "row" }, // Vertical layout on small devices
          flexDirection: "column",
          justifyContent: "center",
          //alignItems: "center",
          alignItems: "flex-start",
          minHeight: "15vh",
        }}
      >
        <CardMedia
          component="img"
          sx={{
            width: { xs: "50%", sm: "8%" }, // Responsive width
            height: "auto", // Adjust height automatically
            marginRight: "20px",
            "@media (max-width:600px)": {
              // Adjustments for small screens
              marginRight: "0",
              marginBottom: "10px",
              width: "40%", // Adjust width on small screens
            },
          }}
          image={user.pictureURL}
          alt="User Picture"
        />
        <CardContent
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "flex-start",
          }}
          // sx={{
          //   display: "flex",
          //   flexDirection: "column",
          //   //alignItems: { xs: "center", sm: "flex-start" }, // Center-align on small screens
          //   alignItems: "flex-start",
          // }}
        >
          <Typography
            variant="h5"
            component="div"
            sx={{ mt: { xs: "10px", sm: "0" }, textAlign: "left" }}
          >
            {user.username}
          </Typography>
          <Typography
            variant="body2"
            color="text.secondary"
            gutterBottom
            sx={{ textAlign: "left" }}
          >
            {`${user.firstName} ${user.lastName}`}
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
};

export default OutlinedCard;

// const OutlinedCard = ({ user }: any) => {
//   console.log(user);
//   const card = (
//     <React.Fragment>
//       <CardContent style={{ display: "flex", alignItems: "center" }}>
//         <CardMedia
//           component="img"
//           sx={{ height: "15%", marginRight: "20px", width: "8%" }}
//           image={user.pictureURL}
//           title="userPicture"
//         />
//         <div>
//           <Typography variant="h4" component="div" sx={{ marginTop: "15%" }}>
//             {user.username}
//           </Typography>
//           <Typography
//             component="div"
//             sx={{ fontSize: 14, textDecoration: "" }}
//             color="text.secondary"
//             gutterBottom
//           >
//             {`${user.firstName} ${user.lastName}`}
//           </Typography>
//         </div>
//       </CardContent>
//     </React.Fragment>
//   );

//   return (
//     <Card
//       variant="elevation"
//       style={{
//         justifyContent: "center",
//         alignItems: "center",
//         minHeight: "5vh",
//         marginTop: "2%",
//         marginLeft: "20%",
//         marginRight: "20%",
//       }}
//     >
//       {card}
//     </Card>
//   );
// };

// export default OutlinedCard;
