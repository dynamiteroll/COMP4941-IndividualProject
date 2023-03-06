# COMP4941-IndividualProject

## MyTopMovies

Welcome to MyTopMovies, an app that allows you to create your own list of favorite movies.

This app searches and fetches the movie data from OMDB api. Once searched, users can add them to their list of favorite movies (currently, it's just a centralized local MS SQL erver database, where the list for each user is separated by userID). Users can also delete the movies on their list if they're no longer their favorite movies.

Minimum viable product: complete.

Some features that don't currently work:

- session variables

Possible future features:

- being able to view other people's lists

Some requirements:
connect using your own MS SQL Server instance/connectionString
create the tables on MS SQL Server Management Studio using the supplied "SQLQuery1.sql" file
get an API key from OMDB api using link here: https://www.omdbapi.com/
run asp.net backend using visual studio
run react frontend with visual studio code with cmd npm start (this is CRA btw)
