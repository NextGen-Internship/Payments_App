import React, { useState, useEffect } from "react";
import "./ExplorePage.css";
import OutlinedCard from "./UserCard/UserCard";
import Autocomplete from "@mui/material/Autocomplete";
import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";

const ExplorePage = () => {
  const [userList, setUserList] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState([]);
  const [searchValue, setSearchValue] = useState("");
  const baseUrl = import.meta.env.VITE_BASE_URL;
  
  useEffect(() => {
    const getUsers = async () => {
      const fetchUsersData = await fetchUsers();
      setUserList(fetchUsersData);
      setFilteredUsers(fetchUsersData);
    };

    getUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      const response = await fetch(`${baseUrl}/api/User`, {
        headers: {
          'ngrok-skip-browser-warning': '1',
        },
      });
  

      if (!response.ok) {
        throw new Error("Failed to fetch users");
      }

      const data = await response.json();
       

      return data;
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    const search = e.target.value.toLowerCase();
    const filteredUsers = userList.filter((user: any) =>
      user.username.toLowerCase().includes(search)
    );

    setFilteredUsers(filteredUsers);
    setSearchValue(search);
  };

  return (
    <div>
      <Stack
        spacing={2}
        sx={{
          width: "20%",
          textAlign: "center",
          marginTop: "2%",
          marginBottom: "4%",
          paddingX: "2%",
        }}
      >
        <Autocomplete
          freeSolo
          options={userList.map((user: any) => user.username)}
          renderInput={(params) => (
            <TextField
              {...params}
              label="Search users..."
              value={searchValue}
              onChange={handleSearch}
            />
          )}
        />
      </Stack>

      <ul>
        {filteredUsers.map((user: any, index: number) => (
          <li key={index} style={{ listStyle: "none" }}>
              <OutlinedCard user={user} />
          </li>
        ))}
      </ul>
    </div>
  );
};
export default ExplorePage;
