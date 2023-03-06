import React from "react";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom";
import Login from "./components/auth/Login";
import Register from "./components/auth/Register";
import Dashboard from "./components/pages/Dashboard";
import PrivateRoutes from "./components/utils/PrivateRoutes";
import Home from "./components/pages/Home";
import AddEntry from "./components/pages/AddEntry";
//import Profile from "./components/pages/Profile"; // possible future feature

function App() {
  return (
    <div className="App">
      <Router>
          <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route element={<PrivateRoutes/>}>
                <Route path="/dashboard" element={<Dashboard />} />
                <Route path="/addentry" element={<AddEntry />} />
                {/* <Route path="/profile" element={<Profile/>} /> */} {/* possible future feature */}
              </Route>
          </Routes>
      </Router>
    </div>
  );
}

export default App;
