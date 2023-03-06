import React, { useEffect, useState } from "react";
import Header from "../elements/Header";
import MovieList from "../elements/MovieList";
import "../styles/Dashboard.css"
import axios from "axios";

export default function Dashboard() {
  const [movies, setMovies] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {
    const getMovies = async () => {
      const url = "https://localhost:7212/api/Movies/getmovies"; // url to backend, may differ
      const UserID = localStorage.getItem("userID");

      try {
        const response = await axios.get(url, { params: { UserID } });
        console.log(response.data.movieList);
        setMovies(response.data.movieList);
        console.log(movies);
        setIsLoading(false);

        if (response.data.statusMessage === "No movies found") {
          setErrorMessage("No movies found, add some movies to your list by clicking \"Add Entry\"");
        }

      } catch (error) {
        console.log(error);
        setErrorMessage("Failed to fetch movies");
        setIsLoading(false);
      }
    };

    getMovies();
  });

  return (
    <>
      <Header />
      <br />
      {isLoading ? (
        <div className="error-message">Loading movies...</div>
      ) : errorMessage ? (
        <div className="error-message">{errorMessage}</div>
      ) : (
        <div className="listContainer">
          <MovieList movies={movies} />
        </div>
      )}
    </>
  );
}