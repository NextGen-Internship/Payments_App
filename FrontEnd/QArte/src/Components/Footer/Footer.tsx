import React from "react";
import { Box, Container, Typography, Link } from "@mui/material";

const Footer: React.FC = () => {
  return (
    <Box component="footer" sx={{ bgcolor: "#ffeef2", py: 6, mt: "auto" }}>
      <Container maxWidth="lg">
        <Typography variant="body1" align="center" sx={{ color: "black" }}>
          {" "}
          {/* Add sx prop for black color */}© {new Date().getFullYear()} QArté
          |{" "}
          <Link
            href="https://blankfactor.com/"
            color="textPrimary" // Change to textPrimary for black color if using default theme or specify 'black'
            target="_blank"
            rel="noopener noreferrer"
          >
            Blankfactor
          </Link>{" "}
          |{" "}
          <Link
            href="https://www.linkedin.com/company/blankfactor"
            color="textPrimary" // Change to textPrimary for black color if using default theme or specify 'black'
            target="_blank"
            rel="noopener noreferrer"
          >
            LinkedIn
          </Link>
        </Typography>
        {/* If you have any text for the second Typography, set its color similarly */}
        <Typography
          variant="body2"
          color="text.primary" // This sets the color to black based on the theme's primary text color
          align="center"
        >
          {/* Additional text here if needed */}
        </Typography>
      </Container>
    </Box>
  );
};

export default Footer;
