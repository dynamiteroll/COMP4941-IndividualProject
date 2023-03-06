import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

const LogoutModal = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleLogout = (e) => {
        e.preventDefault();
        localStorage.removeItem("isLoggedIn");
        localStorage.removeItem("name");
        localStorage.removeItem("userID");
        window.location.href = "./login";
    };

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Logout
      </Button>

      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
      >
        <Modal.Header closeButton>
          <Modal.Title>Log Out</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Do you want log out?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" style={{backgroundColor: "#dc143c", borderColor: "#dc143c"}} onClick={(e) => handleLogout(e)}>Log Out</Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default LogoutModal;