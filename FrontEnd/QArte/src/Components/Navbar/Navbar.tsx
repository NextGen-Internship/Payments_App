import * as React from "react";
import { NavLink, useNavigate } from "react-router-dom";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import MenuIcon from "@mui/icons-material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import AdbIcon from "@mui/icons-material/Adb";
//import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { clearUser, setLoggedIn } from "../../store/loginSlice";
import { RootState } from "../../store/store";
import Logo from "../../assets/QArte_BO.webp";
import "./Navbar.css";

const pages = ["Home", "Explore", "Login", "SignUp"];
//const settings = ["Logout"];

export function ResponsiveAppBar() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const userImage = useSelector((state: RootState) => state.user.avatar);
  const isLoggedIn = useSelector((state: RootState) => state.user.isLoggedIn);
  const settings = isLoggedIn ? ["Profile", "Logout"] : [];
  //const userImage = useSelector((state: RootState) => state.user.avatar);

  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const handleNavClick = (page: string) => {
    if (page === "Profile") {
      setAnchorElNav(null);
      navigate("/profile");
    } else if (page === "Login" || page === "SignUp") {
      navigate(`/${page.toLowerCase()}`);
    } else {
      navigate(`/${page.toLowerCase()}`);
    }
    setAnchorElNav(null);
  };

  const handleLogout = () => {
    dispatch(clearUser());

    sessionStorage.removeItem("token");
    sessionStorage.removeItem("googleToken");
    sessionStorage.removeItem("userPictureUrl");
    sessionStorage.removeItem("userId");
    setAnchorElUser(null);
    navigate("/home");
  };

  const handleProfile = () => {
    setAnchorElNav(null);
    setAnchorElUser(null);
    setAnchorElNav(null)
    navigate("/profile");
  };

  return (
    <AppBar position="static" sx={{ backgroundColor: "#ffeef2" }}>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="/home"
            sx={{
              mr: 2,
              display: { xs: "none", md: "flex" },
              fontFamily: "monospace",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "black",
              textDecoration: "none",
            }}
          >
            <img src={Logo} />
            <NavLink to="/home" style={{textDecoration:"none", color:"black", marginTop:"18%"}}>QArté</NavLink>
            
          </Typography>
          {/* mobile version */}
         
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="default"
            >
              <MenuIcon />
            </IconButton>
    
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              {/* Render "Home" and "Explore" when logged in */}
              {isLoggedIn &&
                ["Home", "Explore","Profile"].map((page) => (
                  <MenuItem key={page} onClick={() => handleNavClick(page)}>
                    <Typography textAlign="center">{page}</Typography>
                  </MenuItem>
                ))}
              {isLoggedIn && (
                <MenuItem onClick={handleLogout}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              )}
              {/* Render "SignIn" and "SignUp" when logged out */}
              {!isLoggedIn && (
                <React.Fragment>
                  <MenuItem onClick={() => handleNavClick("Home")}>
                    <Typography textAlign="center">Home</Typography>
                  </MenuItem>
                  <MenuItem onClick={() => handleNavClick("Explore")}>
                    <Typography textAlign="center">Explore</Typography>
                  </MenuItem>
                  <MenuItem onClick={() => handleNavClick("Login")}>
                    <Typography textAlign="center">Login</Typography>

                  </MenuItem>
                  <MenuItem onClick={() => handleNavClick("SignUp")}>
                    <Typography textAlign="center">SignUp</Typography>
                  </MenuItem>
                </React.Fragment>
              )}
            </Menu>
          </Box>
          <img
            className="Q"
            src={Logo}
          />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="#"
            sx={{
              mr: 2,
              display: { xs: "flex", md: "none" },
              flexGrow: 1,
              fontFamily: "monospace",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "black",
              textDecoration: "none",
            }}
          >
            <NavLink
              to="/home"
              style={{ textDecoration: "none", color: "black" }}
            >
              QArté
            </NavLink>
          </Typography>

          <Box
            sx={{
              flexGrow: 1,
              display: { xs: "none", md: "flex" },
              justifyContent: "flex-end",
            }}
          >
            {pages.map((page) => (
              <React.Fragment key={page}>
                {(!isLoggedIn || ["Home", "Explore"].includes(page)) && (
                  <Button
                    onClick={() => handleNavClick(page)}
                    sx={{ my: 2, mx: 2, color: "black" }}
                  >
                    {page}
                  </Button>
                )}
              </React.Fragment>
            ))}
          </Box>

          <Box sx={{ flexGrow: 0 }}>
            {isLoggedIn && (
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar
                    alt="Profile Image"
                    src={userImage || "/static/images/avatar/2.jpg"}
                  />
                </IconButton>
              </Tooltip>
            )}
            {anchorElUser && (
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={handleProfile}>
                  <Typography textAlign="center">Profile</Typography>
                </MenuItem>

                <MenuItem onClick={handleLogout}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              </Menu>
            )}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
