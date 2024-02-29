
import React from "react";
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
import { GoogleLogin } from "@react-oauth/google";
import { Link, useNavigate } from "react-router-dom";
import UserService from "../../Services/UserService.ts";
import ApiService from "../../Services/ApiService.ts";
import SignInDTO from "../../Interfaces/DTOs/SignInDTO.ts";
import { useDispatch } from "react-redux";
import { setUser, setLoggedIn, setAvatar } from "../../store/loginSlice.ts";

import { jwtDecode } from "jwt-decode";

function Copyright(props: any) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
     
    </Typography>
  );
}


const defaultTheme = createTheme();

const apiService = new ApiService();
const userService = new UserService(apiService);
const baseUrl = import.meta.env.VITE_BASE_URL;

export default function Login() {

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

    try {
      const response = await userService.loginUser(signInData);
      if (response.succeed) {
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
      } else {
        alert(`Login failed: ${response.message}`);
      }
    } catch (error) {
      console.error("Login error:", error);
      alert("An error occurred during login.");
    }
  };


  const handleLoginWithgoogle = async (CredentialResponse: any) => {
     
    const token = CredentialResponse.credential;
    sessionStorage.setItem("googleToken", token);
    try {
    
      
      const response = await axios.post(
        `${baseUrl}/api/Authentication/google-signIn`,
        { token },
        { headers: { "Content-Type": "application/json" 
      ,    'ngrok-skip-browser-warning': '1'} }
      );
      if (response.data.userExists) {
        dispatch(setLoggedIn(true));

        if (response.data.userId) {
          sessionStorage.setItem("userId", response.data.userId.toString());
        }

        const pictureUrl = response.data.picUrl;
        if (pictureUrl) {
           
           
          sessionStorage.setItem("userPictureUrl", pictureUrl);

          dispatch(setAvatar(pictureUrl));
        }
        navigate("/profile");
      } else {
        navigate("/additionalInformation");
      }
    } catch (error) {
      console.error("Error during the sign-in process:", error);
    }
  };

  const error = () => {
     
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
            Login
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
              Login
            </Button>

            <GoogleLogin onSuccess={handleLoginWithgoogle} onError={error} />

            <Grid container>
              <Grid item xs>
                <LinkMui href="#" variant="body2">
                  Forgot password?
                </LinkMui>
              </Grid>
              <Grid item>
                <Link to="/signUp">{"Don't have an account? Sign Up"}</Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}
