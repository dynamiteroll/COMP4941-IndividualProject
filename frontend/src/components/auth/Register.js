import React, {useState} from "react";
import axios from "axios";
import Button from 'react-bootstrap/Button';
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
        const url = 'https://localhost:7212/api/Users/register'; // url to backend, may differ
        axios.post(url, data).then((response) => {
            const dt = response.data;
            console.log(dt);
            alert("Registration successful");
        }).then(() => {
            window.location.href = "./login";
        })
        
        .catch((error) => {
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
                <Button variant="primary" onClick={(e) => handleSave(e)}>Register</Button>
                <a id="logLink" type="button" onClick = {() => window.location.href = "./login"}>Already have an account? Login</a>
                <a id="logLink" type="button" onClick = {() => window.location.href = "./"}>Return to homepage</a>
            </form>
        </div>
    );
}

