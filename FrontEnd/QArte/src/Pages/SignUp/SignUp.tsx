import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
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
import ApiService from "../../Services/ApiService";
import ApiResponseDTO from "../../Interfaces/DTOs/ApiResponseDTO";
import UserService from "../../Services/UserService";
import SignUpDTO from "../../Interfaces/DTOs/SignUpDTO";

import MenuItem from "@mui/material/MenuItem";
const defaultTheme = createTheme();

export default function SignUp() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [username, setUsername] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [address, setAddress] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [IBAN, setIBAN] = useState("");
  const [PhoneNumber, setPhoneNumber] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [confirmPasswordError, setConfirmPasswordError] = useState("");
  const [selectedCountry, setSelectedCountry] = useState("");
  const [settlementCycle, setSettlementCycle] = useState("");

  const userService = new UserService(new ApiService());
  const navigate = useNavigate();
  const validateEmail = (email: string): boolean => {
    const reg =
      /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return reg.test(String(email).toLowerCase());
  };

  const validatePassword = (password: string): boolean => {
    return password.length >= 8;
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    setEmailError("");
    setPasswordError("");
    setConfirmPasswordError("");

    let isValid = true;

    const isBanned = false;
    const roleID = 0;
    const pictureURL = "";

    if (!validateEmail(email)) {
      setEmailError("Invalid email address");
      isValid = false;
    }
    if (!validatePassword(password)) {
      setPasswordError("Password must be at least 8 characters long");
      isValid = false;
    }
    if (password !== confirmPassword) {
      setConfirmPasswordError("Passwords do not match");
      isValid = false;
    }
    if (isValid) {
      try {
        const userData: SignUpDTO = {
          ID: 0,
          Email: email,
          Password: password,
          Username: username,
          FirstName: firstName,
          LastName: lastName,
          Address: address,
          Country: selectedCountry,
          City: city,
          postalCode: postalCode,
          IBAN: IBAN,
          PhoneNumber: PhoneNumber,
          isBanned: isBanned,
          RoleID: 0,
          BankAccountID: 0,
          stripeAccountID: "",
          PictureURL: pictureURL,
          SettlementCycleEnum: parseInt(settlementCycle),
          SettlementCycleID: 0,
          paymentMethodEnum: 0,
          roleEnum: 0,
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
        };


        const response: ApiResponseDTO = await userService.registerUser(
          userData
        );



        if (response.succeed) {

          if (response.data?.token) {
            localStorage.setItem("token", response.data.token);
          }
          navigate("/login");
        } else {
          alert(`Registration failed: ${response.message}`);
        }
      } catch (error) {
        console.error("Registration error:", error);
        alert("An error occurred during registration.");
      }
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
            Sign Up
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
              id="emailAddress"
              label="Email Address"
              name="emailAddress"
              autoComplete="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              error={!!emailError}
              helperText={emailError}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              autoComplete="new-password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              error={!!passwordError}
              helperText={passwordError}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="confirmPassword"
              label="Confirm Password"
              type="password"
              id="confirmPassword"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              error={!!confirmPasswordError}
              helperText={confirmPasswordError}
            />

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
              name="firstName"
              label="First Name"
              type="text"
              id="firstName"
              autoComplete="given-name"
              aria-label="First Name"
              onChange={(e) => setFirstName(e.target.value)}
            />

            <TextField
              margin="normal"
              required
              fullWidth
              name="lastName"
              label="Last Name"
              type="text"
              id="lastName"
              autoComplete="family-name"
              onChange={(e) => setLastName(e.target.value)}
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
              id="country"
              label="Country"
              name="country"
              select
              value={selectedCountry}
              onChange={(e) => setSelectedCountry(e.target.value)}
            >

              <MenuItem value="US">United States</MenuItem>
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
            {/* SettlementCycle */}
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
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link to="/signin">Already have an account? Sign in</Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
