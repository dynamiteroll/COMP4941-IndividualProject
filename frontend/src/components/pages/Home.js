import React from "react";
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import "../styles/Home.css"

export default function Home() {
    return   (  
        <>
            <div className="homeContainer">
                <Navbar className="light navBar" expand="lg">
                    <Container>
                    <Navbar.Brand>MyTopMovies</Navbar.Brand>
                        <Navbar.Toggle />
                        <Navbar.Collapse className="justify-content-end">
                        <Button className="me-3" variant="primary" href="./register">Sign up</Button>
                        <Button variant="Secondary" href="./login">Sign in</Button>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>

                <Card className="d-flex justify-content-center" style={{ border: 0 }}>
                    <Card.Body>
                        <Card.Title>Welcome to MyTopMovies</Card.Title>
                        <Card.Text>
                            This is a simple movie list app. You can search for movies and add them to your list of favorites.
                        </Card.Text>
                        <Button variant="primary" href="./register">Get Started</Button>
                    </Card.Body>
                </Card>
            </div>


        </>
    )
}