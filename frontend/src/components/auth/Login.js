import React, {useState} from "react";
import "../styles/Login.css"
import Button from 'react-bootstrap/Button';
import axios from "axios";

export default function Login() {

const [email, setEmail] = useState("");
const [password, setPassword] = useState("");

    const handleEmailChange = (value) => {
        setEmail(value);
    };

    const handlePasswordChange = (value) => {
        setPassword(value);
    };


const handleSave = (e) => {
    e.preventDefault();

    if (email === "" || password === "") {
        alert("Please fill in all fields");
        return;
    }
    const data = {
        Email: email,
        Password: password
    }
    const url = 'https://localhost:7212/api/Users/login'; // url to backend, may differ
    axios.post(url, data).then((response) => {
        const dt = response.data;
        console.log(dt);

        if (dt.statusMessage === "User doesn't exist or isn't valid") {
            alert("Invalid credentials or user doesn't exist");
            return;
        } else {
            // localStorage.setItem("token", dt.session.sessionkeysessionid); //save this when doing session variables
            localStorage.setItem("isLoggedIn", true);
            localStorage.setItem("name", dt.user.username);
            localStorage.setItem("userID", dt.user.userID);
            window.location.href = "./dashboard";
        }
        
    })
    .catch((error) => {
        console.log(error);
        alert(error);
    });
};

    return (
        <div className="loginContainer">
            <h1>Login</h1>
            <form className="loginForm">
                <label htmlFor="email">Enter Email</label>
                <input type="email" placeholder="johndoe@gmail.com" onChange={(e) => handleEmailChange(e.target.value)}></input>
                <label htmlFor="password">Enter Password</label>
                <input type="password" placeholder="********"  onChange={(e) => handlePasswordChange(e.target.value)}></input>
                <Button variant="primary" onClick={(e) => handleSave(e)}>Login</Button>
                <a id="regLink" type="button" onClick = {() => window.location.href = "./register"}>No account? Register</a>
                <a id="regLink" type="button" onClick = {() => window.location.href = "./"}>Return to homepage</a>
            </form>        
        </div>

    );
}