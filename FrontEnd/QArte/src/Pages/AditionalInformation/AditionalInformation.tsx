import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";

import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { jwtDecode } from "jwt-decode";
import axios from "axios";
import { useDispatch} from "react-redux";

import MenuItem from "@mui/material/MenuItem";
import SignIn from "../SignIn/Login.tsx";
import { setUser, setLoggedIn, setAvatar } from "../../store/loginSlice.ts";

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
const baseUrl = import.meta.env.VITE_BASE_URL;

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
  const [settlementCycle, setSettlementCycle] = useState("");
  const [PhoneNumber, setPhoneNumber] = useState("");


  const navigate = useNavigate();
  const dispatch = useDispatch();

  React.useEffect(() => {
    const googleToken = sessionStorage.getItem("googleToken");
    if (googleToken) {
      const decoded: DecodedToken = jwtDecode(googleToken);
       
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
    const googleToken = sessionStorage.getItem("googleToken") ?? "";
    const isBanned = false;
    const password = generateRandomPassword();
    const fullData = {
      userInfo: {
        ID: 0,
        Email: email ?? "",
        Password: password,
        Username: username,
        FirstName: firstName,
        LastName: lastName,
        Address: address,
        Country: country,
        City: city,
        PostalCode: postalCode,
        IBAN: IBAN,
        PhoneNumber: PhoneNumber,
        IsBanned: isBanned,
        RoleID: 0,
        BankAccountID: 0,
        StripeAccountID: "",
        PictureURL: picture,
        SettlementCycleEnum: parseInt(settlementCycle),
        SettlementCycleID: 0,
        PaymentMethodEnum: 0,
        RoleEnum: 0,
        pages: [
          {
            id: 0,
            pageName: "",
            bio: "",
            qrLink: "",
            galleryID: 0,
            userID: 0,
          },
        ],
      },
      googleToken: googleToken,
    };

    try {
      const response = await axios.post(
        `${baseUrl}/api/Authentication/google-login`,
        fullData,
        {
          headers: {
            "Content-Type": "application/json",
            'ngrok-skip-browser-warning': '1',
          },
        }
      );


      if (response.status === 200) {
         
        if (response.data.succeed === true) {
          sessionStorage.setItem("userId", response.data.id.toString());



          dispatch(setLoggedIn(true)); 
          dispatch(setUser(response.data)); 
  
          const token = response.data.data;
          const userId = response.data.id; 
  
          const pictureUrl = response.data.picUrl;
          if (pictureUrl) {
             
             
            sessionStorage.setItem("userPictureUrl", pictureUrl);
            dispatch(setAvatar(pictureUrl));
          }
          if (token) {
            sessionStorage.setItem("token", token);
          } else {
            console.error("Token is missing in the response.");
          }
  
          if (userId) {
            sessionStorage.setItem("userId", userId.toString());
          } else {
            console.error("User ID is missing in the response.");
          }
          navigate("/home");
        }
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
            <TextField
              margin="normal"
              required
              fullWidth
              id="phoneNumber"
              label="phoneNumber"
              name="phoneNumber"
              autoComplete="phoneNumber"
              onChange={(e) => setPhoneNumber(e.target.value)}
            />
        
            <TextField
              margin="normal"
              required
              fullWidth
              id="country"
              label="Country"
              name="country"
              select
              value={country}
              onChange={(e) => setCountry(e.target.value)}
            >
            
              <MenuItem value="BG">Bulgaria</MenuItem>
            </TextField>

          
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
        
            <TextField
              margin="normal"
              required
              fullWidth
              id="settlementCycle"
              label="settlementCycle"
              name="settlementCycle"
              select
              value={settlementCycle}
              onChange={(e) => setSettlementCycle(e.target.value)}
            >
              <MenuItem value="0">Daily</MenuItem>
              <MenuItem value="1">Weekly</MenuItem>
              <MenuItem value="2">Monthly</MenuItem>
            </TextField>
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
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
