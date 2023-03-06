import React from "react";
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { useLocation } from "react-router-dom";
import DeleteModal from "../elements/DeleteModal"
import "../styles/MovieList.css"
import axios from "axios";


const MovieList = (props) => {

    const path = useLocation();
    const addMovie = (movie) => {

        const data = {
            UserID: localStorage.getItem("userID"),
            MovieID: movie.imdbID,
            Poster: movie.Poster,
            Title: movie.Title,
            Year: movie.Year,
        }
        console.log(data);

        const url = 'https://localhost:7212/api/Movies/addmovie'; // url to backend, may differ
        axios.post(url, data).then((response) => {
            
            const dt = response.data;
            console.log(dt);

            if (dt.statusMessage === "Add movie failed: request to the server failed") {
                alert("Add movie failed: request to the server failed");
                return;
            } else if (dt.statusMessage === "Add movie failed: movie already added to list or database failed") {
                alert("Add movie failed: movie already added to list or database failed");
                return;
            }else {
                alert("Movie added successfully");
            }
        })
        .catch((error) => {
            console.log(error);
            alert(error);
        });
    }



    return (
        <>
            {props.movies.map((movie, index) => (
                <div className="movieContainer" key={index}>
                    <Card bg="dark" text="light" >
                        <Card.Img className="movieImg" variant="top" src={movie.Poster || movie.poster} alt='No Image' />
                        <Card.Body>
                            <Card.Title>{movie.Title || movie.title}</Card.Title>
                            <Card.Text>{movie.Year || movie.year}</Card.Text>
                            {path.pathname === "/addentry" ? <Button variant="primary" onClick={() => addMovie(movie)}>Add to List</Button> : <DeleteModal movie={movie}></DeleteModal>}
                        </Card.Body>
                    </Card>
                </div>
            ))}


        </>
    )
}

export default MovieList;