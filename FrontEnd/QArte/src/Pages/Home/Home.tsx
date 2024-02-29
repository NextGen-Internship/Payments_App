import { useState, useEffect } from "react";
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
  Dialog,
  IconButton,
  Box,
  Slide,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";


const Home = () => {
  
  const [imageOpen, setImageOpen] = useState(false); 
  const [videoOpen, setVideoOpen] = useState(false);
  const [selectedImg, setSelectedImg] = useState("");

  const artworks = [
    { title: "Sofia,Bulgaria", img: "src/assets/serdikaSofia.jpeg" },
    { title: "Paris,France", img: "src/assets/paris.jpeg" },
    { title: "Los Angeles,US", img: "src/assets/la,us.webp" },
  ];

  const handleClickOpenImage = (img: any) => {
    setSelectedImg(img);
    setImageOpen(true);
  };

  const handleImageClose = () => {
    setImageOpen(false);
  };

  const handleVideoOpen = () => {
    setVideoOpen(true);
  };

  const handleVideoClose = () => {
    setVideoOpen(false);
  };

  const HeroSection = () => (
    <Box
      sx={{
        position: "relative",
        height: "50vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundImage: "url(path-to-your-hero-background.jpg)",
        backgroundSize: "cover",
        backgroundPosition: "center",
        color: "#fff",
      }}
    >
      <Container>
        <Slide direction="down" in={checked} mountOnEnter unmountOnExit>
          <Typography variant="h2" component="h1" gutterBottom>
            Welcome to QArté
          </Typography>
        </Slide>
        <Slide
          direction="up"
          in={checked}
          mountOnEnter
          unmountOnExit
          timeout={500}
        >
          <Typography variant="h5" sx={{ mb: 4, color: "grey" }}>
            Explore the world of art and creativity
          </Typography>
        </Slide>
        <Button
          variant="contained"
          color="primary"
          onClick={handleVideoOpen}
          sx={{
            py: 1,
            px: 3,
            mt: 2,
            background: "#ffeef2",
            color: "black",
            "&:hover": {
              backgroundColor: "theColorYouWantOnHover",
            },
          }}
        >
          Watch Video
        </Button>
      </Container>
    </Box>
  );

  const [checked, setChecked] = useState(false);

  useEffect(() => {
    setChecked(true);
  }, []);


  return (

    <Container maxWidth="lg">
      <HeroSection />
      <Typography variant="h4" sx={{ mt: 5, mb: 3 }}>
        Featured Artworks
      </Typography>
      <Grid container spacing={4}>
        {artworks.map((artwork, index) => (
          <Grid item xs={12} sm={6} md={4} key={index}>
            <Card
              sx={{
                maxWidth: 345,
                mx: "auto",
                overflow: "hidden",
                transition: "0.3s",
                "&:hover": {
                  transform: "scale(1.05)",
                  boxShadow: "0 6px 20px rgba(0,0,0,0.2)",
                },
              }}
            >
              <CardActionArea onClick={() => handleClickOpenImage(artwork.img)}>
                <CardMedia
                  component="img"
                  height="140"
                  image={artwork.img}
                  alt={artwork.title}
                  sx={{
                    objectFit: "cover",
                    width: "100%",
                    transition: "transform 0.5s ease-in-out",
                    "&:hover": {
                      transform: "scale(2.0)",
                    },
                  }}
                />
                <CardContent
                  style={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "space-between",
                    minHeight: 10,
                  }}
                >
                  <Typography gutterBottom variant="h5" component="div">
                    {artwork.title}
                  </Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>
        ))}
      </Grid>

      <Dialog
        open={imageOpen}
        onClose={handleImageClose}
        maxWidth="md"
        fullWidth
      >
        <IconButton
          aria-label="close"
          onClick={handleImageClose}
          sx={{
            position: "absolute",
            right: 8,
            top: 8,
            color: (theme) => theme.palette.grey[500],
          }}
        >
          <CloseIcon />
        </IconButton>
        <img
          src={selectedImg}
          alt="Artwork"
          style={{ width: "100%", height: "auto" }}
        />
      </Dialog>


      <Dialog
        open={videoOpen}
        onClose={handleVideoClose}
        maxWidth="md"
        fullWidth
        sx={{
          "& .MuiDialog-paper": {
            width: "100%",
            maxWidth: "570px",
          },
        }}
      >
        <IconButton
          aria-label="close"
          onClick={handleVideoClose}
          sx={{
            position: "absolute",
            right: 8,
            top: 8,
            color: (theme) => theme.palette.grey[500],
          }}
        >
          <CloseIcon />
        </IconButton>
        <iframe
          width="560"
          height="315"
          src="https://www.youtube.com/embed/K0N4LVynvvM"
          allowFullScreen
          title="Embedded youtube"
        ></iframe>
      </Dialog>

      {/* About Section */}
      <Container sx={{ my: 5 }}>
        <Typography variant="h4" gutterBottom>
          About Us
        </Typography>
        <Typography sx={{ marginBottom: "40px", color: "black" }}>
          QArté is a platform dedicated to showcasing the beauty and diversity
          of art from around the world. Whether you are an artist looking to
          share your work or an art lover eager to discover new pieces, Artistic
          offers a space to connect, explore, and inspire. Art stands as a
          testament to human creativity, transcending time and cultural
          barriers. It has the power to evoke emotions, provoke thought, and
          inspire change. From the ancient cave paintings to contemporary
          digital art, each piece tells a story, capturing moments of joy,
          sorrow, and wonder. Through art, we explore the depths of human
          experience, learning more about ourselves and the world around us. At
          QArté, we believe in the transformative power of art. It's not just
          about viewing or creating art; it's about experiencing it. Art
          enriches our lives, offering new perspectives and understanding. It is
          a bridge that connects diverse cultures, fostering a global community
          of artists and art enthusiasts. We are committed to celebrating this
          vibrant community, bringing people together through the shared
          language of art. Join us on this journey of discovery and inspiration.
          Explore the vast landscape of art with QArté, where every piece is an
          adventure, every artist is a storyteller, and every viewer is part of
          a larger story of human creativity.
        </Typography>
        <Grid container spacing={4} justifyContent="center">
        
        </Grid>
      </Container>
    </Container>
   
  );
};

export default Home;
