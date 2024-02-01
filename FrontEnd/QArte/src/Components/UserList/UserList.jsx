import React,{Component, useState, forwardRef, useRef} from "react";
import './UserList.css';
import UserPage from "../UserPage/UserPage";
import { BrowserRouter, Router, Route, Routes, Link, NavLink } from 'react-router-dom';

const UserList = ({users, onID}) =>{

    const [userList,SetUserList] = useState(users);



    return(
        <div>
            {users.map((user,index)=>(
                <li key={index}>
                    <NavLink to={`${user.id}`}>
                        <button className="btn" style={{backgroundColor:"green"}} onClick={()=> onID(user.id)}>{user.name}</button>
                    </NavLink>
                </li>
            ))}
        </div>
    );

}
export default UserList;