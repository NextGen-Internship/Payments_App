import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import Snackbar from "@mui/material/Snackbar";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";
import './StripeCheckout.css';

const StripeCheckout = ({ userID }: any) => {
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [message, setMessage] = useState("");
  const baseUrl = import.meta.env.VITE_BASE_URL;

  useEffect(() => {
     
    const searchParams = new URLSearchParams(window.location.search);
     

    if (searchParams.get("paymentSuccess") === "true") {
      setMessage("Payment successful!");
      setOpenSnackbar(true);
    } else if (searchParams.get("paymentCancelled") === "true") {
      setMessage("Payment canceled.");
      setOpenSnackbar(true);
    }

    if (
      searchParams.has("paymentSuccess") ||
      searchParams.has("paymentCancelled")
    ) {
      window.history.replaceState(null, "", window.location.pathname);
    }
  }, []);

  const handleSubmit = async (event: any) => {
    event.preventDefault();

    const currentPageURL = window.location.href.split("?")[0];
    const successURL = `${currentPageURL}?paymentSuccess=true`;
    const cancelURL = `${currentPageURL}?paymentCancelled=true`;

    try {
      const response = await fetch(
        `${baseUrl}/api/Stripe/create-checkout-session`,
        {
          method: "POST",
          headers: { 
            "Content-Type": "application/json", 
            'ngrok-skip-browser-warning': '1',},
          body: JSON.stringify({ successURL, cancelURL, userID }),
        })
      
      if (response.ok) {
        const responseData = await response.json();
        window.location.href = responseData.redirectUrl;
      } else {
        console.error("Error creating checkout session");
      }
    } catch (error) {
      console.error("An error occurred while making the request", error);
    }
  };

  const handleCloseSnackbar = (
    event?: React.SyntheticEvent | Event,
    reason?: string
  ) => {
    if (reason === "clickaway") {
      return;
    }
    setOpenSnackbar(false);
  };

  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Button
        id="donate"
        type="submit"
        variant="contained"
        color="success"
        size="large"
        style={{zIndex: '25'}}
        onClick={handleSubmit}
      >
        Donate
      </Button>
      <Snackbar
        open={openSnackbar}
        autoHideDuration={6000}
        onClose={handleCloseSnackbar}
        message={message}
        action={
          <IconButton
            size="small"
            aria-label="close"
            color="inherit"
            onClick={handleCloseSnackbar}
          >
            <CloseIcon fontSize="small" />
          </IconButton>
        }
      />
    </div>
  );
};

export default StripeCheckout;

