import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import axios from "axios";

const DeleteModal = ({movie}) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const deleteMovie = (movie) => {

    const data = {
        UserID: localStorage.getItem("userID"),
        MovieID: movie.movieID,
    }
    console.log(data);

    const url = 'https://localhost:7212/api/Movies/deletemovie'; // url to backend, may differ
    axios.post(url, data).then((response) => {
        const dt = response.data;
        console.log(dt);

        if (dt.statusMessage === "Delete movie failed: movie not found in list or database failed") {
            alert("Delete movie failed: movie not found in list or database failed");
            return;
        } else if (dt.statusMessage === "Delete movie failed: request to the server failed") {
            alert("Delete movie failed: request to the server failed");
            return;
        } else {
            alert("Movie deleted from list");
            window.location.reload();
        }
    })
    .catch((error) => {
        console.log(error);
        alert(error);
    });

}

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Delete
      </Button>

      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
      >
        <Modal.Header closeButton>
          <Modal.Title>Delete movie</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Do you want to delete this movie?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" style={{backgroundColor: "#dc143c", borderColor: "#dc143c"}} onClick={() => deleteMovie(movie)}>Ok</Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteModal;