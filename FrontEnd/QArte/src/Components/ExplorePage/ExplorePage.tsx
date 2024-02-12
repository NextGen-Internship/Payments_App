import React,{Component, useState, useEffect, forwardRef, useRef} from "react";
import './ExplorePage.css';
import UserPage from "../UserPage/UserPage";
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';
import UserDTO from '../../Interfaces/DTOs/UserDTO';

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
            (user.firstName + ' ' + user.lastName).toLowerCase().includes(search));
        

        setFilteredUsers(filteredUsers);
        setSearchValue(search);
    }




    return (
        <div>
          <input
            type="text"
            placeholder="Search users..."
            value={searchValue}
            onChange={handleSearch}
          />
          <ul>
            {filteredUsers.map((user:any , index: number) => (
              <li key={index}>
                <NavLink to={`${user.id}`}>
                <button
                  className="btn"
                  style={{ backgroundColor: "green" }}
                >
                  {(user.firstName +" "+ user.lastName)}
                </button>
                </NavLink>
              </li>
            ))}
          </ul>
        </div>
      );

}
export default ExplorePage;