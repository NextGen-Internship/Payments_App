import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { jwtDecode } from "jwt-decode";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import { setAvatar} from "../../store/loginSlice";


const defaultTheme = createTheme();

interface DecodedToken {
  email?: string;
  given_name?: string;
  family_name?: string;
  picture?: string;
}

function generateRandomPassword(length = 12) {
  const charset =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  let password = "";
  for (let i = 0; i < length; i++) {
    const randomIndex = Math.floor(Math.random() * charset.length);
    password += charset[randomIndex];
  }
  return password;
}

export default function AditionalInformation() {
  const [email, setEmail] = useState<string | null>(null);
  const [username, setUsername] = useState<string>("");
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [address, setAddress] = useState<string>("");
  const [country, setCountry] = useState<string>("");
  const [picture, setPicture] = useState<string>("");
  const [city, setCity] = useState<string>("");
  const [postalCode, setPostalCode] = useState<string>("");
  const [IBAN, setIBAN] = useState<string>("");
  // const [settlementCycleID, setSettlementCycleID] = useState<string>("");
  // const [paymentMethodEnum, setPaymentMethodEnum] = useState<string>("");

  //const [decodedToken, setDecodedToken] = useState("");

  const navigate = useNavigate();
  const dispatch = useDispatch(); 

  React.useEffect(() => {
    const googleToken = localStorage.getItem("googleToken");
    if (googleToken) {
      const decoded: DecodedToken = jwtDecode(googleToken);
      console.log(decoded);
      if (decoded.email) setEmail(decoded.email);
      if (decoded.given_name) setFirstName(decoded.given_name);
      if (decoded.family_name) setLastName(decoded.family_name);
      if (decoded.picture) {
        dispatch(setAvatar(decoded.picture));
        setPicture(decoded.picture);
      }
    } else {
      console.error("Token not found.");
    }
  }, [dispatch]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const isBanned = false;
    const phoneNumber = "+359888940130";
    const password = generateRandomPassword();
    const fullData = {
      ID: 0,
      Email: email ?? "",
      Password: password,
      Username: username,
      FirstName: firstName,
      LastName: lastName,
      Address: address,
      Country: country,
      City: city,
      postalCode: postalCode,
      IBAN: IBAN,
      PhoneNumber: phoneNumber,
      isBanned: isBanned,
      RoleID: 0,
      BankAccountID: 0,
      stripeAccountID: "",
      PictureURL: picture,
      SettlementCycleEnum: 0,
      SettlementCycleID: 0,
      paymentMethodEnum: 0,
      roleEnum: 0,
    };

    try {
      const response = await axios.post(
        "https://localhost:7191/api/User/PostUser",
        fullData,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("googleToken")}`,
            "Content-Type": "application/json",
          },
        }
      );

      // checking for successful login
      if (response.status === 200) {
        console.log("Success");
        navigate("/home");
      } else {
        throw new Error("Error while trying to login");
      }
    } catch (error) {
      console.error("Error", error);
      alert("An error occurred while submitting additional information.");
    }
  };
  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Aditional Information
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            {/* Username */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="username"
              label="Username"
              name="username"
              autoComplete="username"
              onChange={(e) => setUsername(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="address"
              label="Address"
              name="address"
              autoComplete="address"
              onChange={(e) => setAddress(e.target.value)}
            />
            {/* Country */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="country"
              label="Country"
              name="country"
              autoComplete="country"
              onChange={(e) => setCountry(e.target.value)}
            />
            {/* City */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="city"
              label="City"
              name="city"
              autoComplete="city"
              onChange={(e) => setCity(e.target.value)}
            />
            {/* PostalCode */}
            <TextField
              margin="normal"
              required
              fullWidth
              id="postalCode"
              label="PostalCode"
              name="postalCode"
              autoComplete="postalCode"
              onChange={(e) => setPostalCode(e.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="iban"
              label="IBAN"
              name="iban"
              autoComplete="IBAN"
              onChange={(e) => setIBAN(e.target.value)}
            />
            <FormControlLabel
              control={<Checkbox value="agree" color="primary" />}
              label="I agree to the terms and conditions"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Submit
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                {/* <Link to="/signin" variant="body2">
                  Already have an account? Sign in
                </Link> */}
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}