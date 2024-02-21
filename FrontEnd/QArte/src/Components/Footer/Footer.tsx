import React from "react";
import { Box, Container, Typography, Link } from "@mui/material";

const Footer: React.FC = () => {
  return (
    <Box component="footer" sx={{ bgcolor: "lightgrey", py: 6, mt: "auto" }}>
      <Container maxWidth="lg">
        <Typography variant="body1" align="center">
          © {new Date().getFullYear()} QArté
        </Typography>
        <Typography
          variant="body2"
          color="text.secondary"
          align="center"
        ></Typography>
      </Container>
    </Box>
  );
};

export default Footer;
