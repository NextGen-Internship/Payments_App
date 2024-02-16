import React from "react";
import { useNavigate } from "react-router-dom";
import {
  Container,
  Typography,
  Button,
  Grid,
  Card,
  CardMedia,
  CardContent,
  CardActionArea,
} from "@mui/material";

const Home = () => {
  const navigate = useNavigate();

  const artworks = [
    { title: "Artwork 1", img: "src/assets/SERDIKA.png" },
    { title: "Artwork 2", img: "src/assets/snimka.png" },
    { title: "Artwork 3", img: "src/assets/snimkaSS.png" },
  ];

  return (
    <Container maxWidth="lg">
      {/* Hero Section */}
      <Container sx={{ my: 5, textAlign: "center" }}>
        <Typography variant="h2" gutterBottom>
          Welcome to QArté
        </Typography>
        <Typography variant="h5" gutterBottom>
          Explore the world of art and creativity
        </Typography>
        <Button
          variant="contained"
          color="primary"
          onClick={() => navigate("/explore")}
        >
          Explore Now
        </Button>
      </Container>

      {/* Featured Artworks */}
      <Typography variant="h4" sx={{ mt: 5, mb: 3 }}>
        Featured Artworks
      </Typography>
      <Grid container spacing={4}>
        {artworks.map((artwork, index) => (
          <Grid item xs={12} sm={6} md={4} key={index}>
            <Card>
              <CardActionArea>
                <CardMedia
                  component="img"
                  height="140"
                  image={artwork.img}
                  alt={artwork.title}
                />
                <CardContent>
                  <Typography gutterBottom variant="h5" component="div">
                    {artwork.title}
                  </Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>
        ))}
      </Grid>

      {/* About Section */}
      <Container sx={{ my: 5 }}>
        <Typography variant="h4" gutterBottom>
          About Us
        </Typography>
        <Typography>
          QArté is a platform dedicated to showcasing the beauty and diversity
          of art from around the world. Whether you are an artist looking to
          share your work or an art lover eager to discover new pieces, Artistic
          offers a space to connect, explore, and inspire.
        </Typography>
      </Container>
    </Container>
  );
};

export default Home;
