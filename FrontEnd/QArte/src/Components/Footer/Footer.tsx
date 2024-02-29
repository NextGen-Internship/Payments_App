import React from "react";
import { Box, Container, Typography, Link } from "@mui/material";

const Footer: React.FC = () => {
  return (
    <Box component="footer" sx={{ bgcolor: "#ffeef2", py: 6, mt: "auto" }}>
      <Container maxWidth="lg">
        <Typography variant="body1" align="center" sx={{ color: "black" }}>
          {" "}
            © {new Date().getFullYear()} QArté
          |{" "}
          <Link
            href="https://blankfactor.com/"
            color="textPrimary" 
            target="_blank"
            rel="noopener noreferrer"
          >
            Blankfactor
          </Link>{" "}
          |{" "}
          <Link
            href="https://www.linkedin.com/company/blankfactor"
            color="textPrimary"
            target="_blank"
            rel="noopener noreferrer"
          >
            LinkedIn
          </Link>
        </Typography>
      
        <Typography
          variant="body2"
          color="text.primary" 
          align="center"
        >
         
        </Typography>
      </Container>
    </Box>
  );
};

export default Footer;
