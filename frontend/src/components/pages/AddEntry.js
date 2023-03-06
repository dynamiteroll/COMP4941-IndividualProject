import React, {useState} from "react";
import MovieList from "../elements/MovieList";
import Header from "../elements/Header";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import "../styles/AddEntry.css"
import axios from "axios";


export default function AddEntry() {
    const [errorMessage, setErrorMessage] = useState("");

const getMovies = (e) => {
    e.preventDefault();
    const search = document.querySelector(".searchBar input").value;
    const type = "movie";
    const APIKEY = ""; // supply your own API key
    const url = "http://www.omdbapi.com/?s=" + search + "&type=" + type + "&apikey=" + APIKEY;

    axios.get(url).then (response => {
        // console.log(response.data);
        setMovies(response.data.Search);
        console.log(movies);

        if (response.data.Response === "False") {
            setErrorMessage("No movies found");
        } else{
            setErrorMessage();
        }


    }).catch(error => {
        console.log(error);
       
    });

}


const [movies, setMovies] = useState([]);

    return (
        <>
            <Header/>
            <Form className="d-flex justify-content-center searchBar">
                <Form.Control
                    type="search"
                    placeholder="Search"
                    className="me-2"
                    aria-label="Search"
                />
                <Button variant="outline-success" onClick={(e) => {getMovies(e)}}>Search</Button>
            </Form>
            <br></br>
            {errorMessage ? (
            <div className="error-message">{errorMessage}</div>
        ) : (
            <div className="listContainer">
            <MovieList movies={movies} />
            </div>
        )}

        </>    
    )
}