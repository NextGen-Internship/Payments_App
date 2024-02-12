import React,{Component, useState, forwardRef, useRef} from "react";
import './UserList.css';
import UserPage from "../UserPage/UserPage";
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';

const UserList = ({users}:any) =>{

    const [userList,SetUserList] = useState(users);



    return(
        <div>
            {users.map((user:any,index:any)=>(
                <li key={index}>
                    <NavLink to={`${user.id}`}>
                        <button className="btn" style={{backgroundColor:"green"}} >{user.name}</button>
                    </NavLink>
                </li>
            ))}
        </div>
    );

}
export default UserList;