import React, {useState} from "react";
import axios from "axios";
import '../styles/Register.css';


export default function Register() {

    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");


    const handleSave = () => {
        if (username === "" || email === "" || password === "") {
            alert("Please fill in all fields");
            return;
        }
        const data = {
            Username: username,
            Email: email,
            Password: password
        }
        const url = 'https://localhost:7212/api/Users/register';
        axios.post(url, data).then((response) => {
            const dt = response.data;
            console.log(dt);
            alert("Registration successful");
        }).catch((error) => {
            console.log(error);
            alert(error);
        });
    };


    return (

        <div className="registerContainer">
            <h1>Register</h1>
            <form className="registerForm">
                <label htmlFor="username">Enter Username</label>
                <input type="text" placeholder="John Doe"  onChange={(e) => setUsername(e.target.value)}></input>
                <label htmlFor="email">Enter Email</label>
                <input type="email" placeholder="johndoe@gmail.com" onChange={(e) => setEmail(e.target.value)}></input>
                <label htmlFor="password">Enter Password</label>
                <input type="password" placeholder="********"  onChange={(e) => setPassword(e.target.value)}></input>
                <button id="regBtn" type="button" onClick = {() => handleSave()}>Register</button>
            </form>
        </div>
    );
}

