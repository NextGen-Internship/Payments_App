import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import Snackbar from "@mui/material/Snackbar";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";

const StripeCheckout = ({ userID }: any) => {
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [message, setMessage] = useState(""); // Added state to hold the message text

  useEffect(() => {
    console.log(window.location.href); // Debugging: Log the current URL
    const searchParams = new URLSearchParams(window.location.search);
    console.log(Array.from(searchParams.entries())); // Debugging: Log all query parameters

    if (searchParams.get("paymentSuccess") === "true") {
      setMessage("Payment successful. Thank you for your purchase!");
      setOpenSnackbar(true);
    } else if (searchParams.get("paymentCancelled") === "true") {
      setMessage("Payment canceled. Please try again.");
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
    //const successURL = currentPageURL; // Modify as needed for success handling
    const successURL = `${currentPageURL}?paymentSuccess=true`;
    const cancelURL = `${currentPageURL}?paymentCancelled=true`;

    try {
      const response = await fetch(
        "https://localhost:7191/api/Stripe/create-checkout-session",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
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
        type="submit"
        variant="contained"
        color="success"
        size="large"
        onClick={handleSubmit}
        style={{
          position: "fixed",
          bottom: "20px",
          left: "20px",
          fontSize: "24px",
          padding: "20px 30px",
        }}
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

// import react, { useState, useEffect } from "react";
// import Button from "@mui/material/Button";
// import Alert from "@mui/material/Alert";
// import Stack from "@mui/material/Stack";

// const StripeCheckout = ({ userID }: any) => {
//   const [showAlert, setShowAlert] = useState(false);

//   useEffect(() => {
//     const searchParams = new URLSearchParams(window.location.search);
//     if (searchParams.get("paymentCancelled") === "true") {
//       setShowAlert(true);

//       window.history.replaceState(null, "", window.location.pathname);
//       const timer = setTimeout(() => {
//         setShowAlert(false);
//       }, 6000);

//       // Clear the timer if the component unmounts
//       return () => clearTimeout(timer);
//     }
//   }, [location]);

//   const handleSubmit = async (event: any) => {
//     event.preventDefault();

//     const currentPageURL = window.location.href.split("?")[0];
//     const successURL = currentPageURL; // Assuming you handle success differently or at a different URL
//     const cancelURL = `${currentPageURL}?paymentCancelled=true`;

//     try {
//       const response = await fetch(
//         "https://localhost:7191/api/Stripe/create-checkout-session",
//         {
//           method: "POST",
//           headers: { "Content-Type": "application/json" },
//           body: JSON.stringify({ successURL, cancelURL, userID }),
//         }
//       );

//       if (response.ok) {
//         const responseData = await response.json();
//         window.location.href = responseData.redirectUrl;
//       } else {
//         console.error("Error creating checkout session");
//       }
//     } catch (error) {
//       console.error("An error occurred while making the request", error);
//     }
//   };

//   return (
//     <div
//       style={{
//         display: "flex",
//         alignItems: "center",
//         justifyContent: "center",
//       }}
//     >
//       {showAlert && (
//         <Stack
//           sx={{ width: "100%", position: "absolute", top: 20 }}
//           spacing={2}
//         >
//           <Alert severity="error">Payment canceled. Please try again.</Alert>
//         </Stack>
//       )}
//       <form onSubmit={handleSubmit}>
//         <Button
//           type="submit"
//           variant="contained"
//           color="success"
//           size="large"
//           style={{
//             position: "fixed",
//             bottom: "20px",
//             left: "20px",
//             fontSize: "24px",
//             padding: "20px 30px",
//           }}
//         >
//           Checkout
//         </Button>
//       </form>
//     </div>
//   );
// };
// export default StripeCheckout;
