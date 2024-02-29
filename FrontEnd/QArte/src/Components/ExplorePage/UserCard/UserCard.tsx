
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import CardMedia from "@mui/material/CardMedia";
import { Box } from "@mui/material";
import { NavLink } from "react-router-dom";

const OutlinedCard = ({ user }: any) => {
  return (
    <Box
      sx={{
        margin: "2% 20%",
        "@media (max-width:600px)": {
          margin: "2% 5%",
        },
      }}
    >
      <NavLink to={`${user.id}`} style={{ textDecoration: "none" }}>
        <Card
          variant="outlined"
          sx={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "flex-start",
            alignItems: "center",
            minHeight: "15vh",
          }}
        >
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
            image={user.pictureURL}
            alt="User Picture"
          />
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
              flexGrow: 1,
            }}
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
      </NavLink>
    </Box>
  );

};

export default OutlinedCard;
