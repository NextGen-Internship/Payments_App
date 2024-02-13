import React,{Component, useState, useEffect, forwardRef, useRef} from "react";
import './ExplorePage.css';
import UserPage from "../UserPage/UserPage";
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';
import OutlinedCard from "./UserCard/UserCard"
import FreeSolo from "./SearchBar/SearchBar"
import Autocomplete from '@mui/material/Autocomplete';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';

const ExplorePage = () =>{

    const [userList,setUserList] = useState([]);
    const [filteredUsers, setFilteredUsers] = useState([]);
    const [searchValue, setSearchValue] = useState("");

    useEffect(() => {

        const getUsers = async () =>
        {
          const fetchUsersData = await fetchUsers();
          setUserList(fetchUsersData);
          setFilteredUsers(fetchUsersData);
        }

        getUsers();
      }, []);
      
    const fetchUsers = async() => 
    {
      try {
        const response = await fetch('https://localhost:7191/api/User');
        if (!response.ok) {
          throw new Error('Failed to fetch users');
        }

        const data = await response.json();
        console.log("Data: " + data);
        
        return data;
      } catch (error) {
        console.error('Error fetching users:', error);
      }
    }

    const handleSearch = (e : React.ChangeEvent<HTMLInputElement>) => {

        const search = e.target.value.toLowerCase();
        const filteredUsers = userList.filter((user : any) =>
          `${user.firstName} ${user.lastName}`.toLowerCase().includes(search)
        );
        

        setFilteredUsers(filteredUsers);
        setSearchValue(search);
    }




    return (
        <div>
          <Stack spacing={2} sx={{ width: 400, textAlign: 'center', marginTop: '2%', marginBottom: '4%',paddingX : '2%'}}>
            <Autocomplete
              freeSolo
              options={userList.map((user : any) => `${user.firstName} ${user.lastName}`)}
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
            {filteredUsers.map((user:any , index: number) => (
              <li key={index} style={{listStyle: 'none'}}>
                <NavLink to={`${user.id}`} style={{ textDecoration: 'none' }}>
                  <OutlinedCard user={user}/>
                </NavLink>
              </li>
            ))}
          </ul>
        </div>
      );

}
export default ExplorePage;