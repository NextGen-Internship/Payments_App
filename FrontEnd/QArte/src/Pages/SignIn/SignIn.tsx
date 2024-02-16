// import * as React from "react";
import React, { useState } from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import LinkMui from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import axios from "axios";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { CredentialResponse, GoogleLogin } from "@react-oauth/google";
import { TokenResponse } from "@react-oauth/google";
import { Link, useNavigate } from "react-router-dom";
import UserService from "../../Services/UserService";
import ApiService from "../../Services/ApiService";
import ApiResponseDTO from "../../Interfaces/DTOs/ApiResponseDTO";
import SignInDTO from "../../Interfaces/DTOs/SignInDTO";
import AuthUtils from "../../utils/AuthUtils.ts";
import { useSelector, useDispatch } from "react-redux";
import { setUser, setLoggedIn } from "../../store/loginSlice.ts";

function Copyright(props: any) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {"Copyright © "}
      <LinkMui color="inherit" href="https://mui.com/">
        Your Website
      </LinkMui>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

const apiService = new ApiService();
const userService = new UserService(apiService);

export default function SignIn() {
  // const [email, setEmail] = useState("");
  // const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const email = data.get("email") as string;
    const password = data.get("password") as string;

    const signInData: SignInDTO = {
      email: email,
      password: password,
    };

    try {
      const response = await userService.loginUser(signInData);
      if (response.succeed) {
        dispatch(setLoggedIn(true)); //save into redux that the user is loggedin successfuly
        dispatch(setUser(response.data)); //save data about the user into redux
        localStorage.setItem("token", response.data.token); //store the token into localstorage
        navigate("/home"); //navigate to home page
      } else {
        alert(`Login failed: ${response.message}`);
      }
    } catch (error) {
      console.error("Login error:", error);
      alert("An error occurred during login.");
    }
  };

  const handleLoginWithgoogle = async (CredentialResponse: any) => {
    // console.log("Login with google success.", CredentialResponse);
    // localStorage.setItem("googleToken", CredentialResponse.credential);
    // //localStorage.setItem("userImage", CredentialResponse.profileObj.imageUrl);
    // dispatch(setLoggedIn(true));
    // //if user exists -> if yes => get login with google method from backend
    // navigate("/aditionalInformation");
    console.log("Login with Google success.", CredentialResponse);
    const token = CredentialResponse.credential;
    localStorage.setItem("googleToken", token);
    try {
      const response = await axios.post(
        "https://localhost:7191/api/Authentication/google-signIn",
        { token }, // Directly passing the object
        { headers: { "Content-Type": "application/json" } }
      );
      console.log(response.data);
      if (response.data.userExists) {
        dispatch(setLoggedIn(true));
        navigate("/home");
      } else {
        navigate("/aditionalInformation");
      }
    } catch (error) {
      console.error("Error during the sign-in process:", error);
    }
  };

  const error = () => {
    console.log("Google login error");
  };
  /*const success = (response: CredentialResponse) => {
    console.log(response);
    // Assuming response.credential contains the token you need
    const googleToken = response.credential;
    localStorage.setItem('googleToken', googleToken);
    navigate("/profile");
  };*/
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
            Sign in
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
              id="email"
              label="Email Address"
              name="email"
              autoComplete="email"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              autoComplete="current-password"
            />
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember me"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>

            <GoogleLogin onSuccess={handleLoginWithgoogle} onError={error} />

            <Grid container>
              <Grid item xs>
                <LinkMui href="#" variant="body2">
                  Forgot password?
                </LinkMui>
              </Grid>
              <Grid item>
                <Link to="/signUp" variant="body2" component="{Link}">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}
