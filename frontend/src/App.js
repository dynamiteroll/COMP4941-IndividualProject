import React from "react";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom";
import Login from "./components/auth/Login";
import Register from "./components/auth/Register";
import Dashboard from "./components/pages/Dashboard";
import Profile from "./components/pages/Profile";
import PrivateRoutes from "./components/utils/PrivateRoutes";
import Home from "./components/pages/Home";

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
              </Route>
              {/* <Route path="/profile" element={<Profile />} /> */}
          </Routes>
      </Router>
    </div>
  );
}

export default App;
