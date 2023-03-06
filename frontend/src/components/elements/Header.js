import React from "react";
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import LogoutModal from "../elements/LogoutModal";
import { MdOutlineArrowBackIosNew } from "react-icons/md";
import { useLocation } from "react-router-dom";
import "../styles/Header.css";

 function Header() {
    const path = useLocation();
    const handleGetName = () => {
        const name = localStorage.getItem("name");
        return name;
    };
    

    return (
        <>
          <Navbar>
            <Container>
              {path.pathname === "/addentry" ? <a className="back-button" href="./dashboard"><MdOutlineArrowBackIosNew  ></MdOutlineArrowBackIosNew></a> : null}
              {path.pathname === "/dashboard" ? <Navbar.Brand href="./dashboard">{handleGetName()}'s Movie List</Navbar.Brand> : <Navbar.Brand>Add Entry</Navbar.Brand>}
              <Navbar.Toggle />
              <Navbar.Collapse className="justify-content-end navBar-right">
                <Navbar.Text>
                  Signed in as: {handleGetName()}
                </Navbar.Text>
                {path.pathname === "/dashboard" ? <Button className="addEntry" variant="primary" href="./addentry">Add Entry</Button> : null}
                <LogoutModal></LogoutModal>
              </Navbar.Collapse>
            </Container>
          </Navbar>
        </>
    );
}

export default Header;