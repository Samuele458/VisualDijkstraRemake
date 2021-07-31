import React, { useState, useEffect } from "react";
import axios from "axios";

import GraphEditor from "./components/GraphEditor";
import Navbar from "./components/Navbar";
import Dialog from "./components/Dialog";
import SignupForm from "./components/SignupForm";
import LoginForm from "./components/LoginForm";

import "./app.scss";

import AuthApi from "./AuthApi";

function App() {
  const [displayLogin, setDisplayLogin] = useState(false);
  const [displaySignup, setDisplaySignup] = useState(false);
  const [loggedUser, setLoggedUser] = useState(null);

  const toggleLoginBox = () => {
    setDisplayLogin(!displayLogin);
  };

  const toggleSignupBox = () => {
    setDisplaySignup(!displaySignup);
  };

  const handleLogout = () => {
    axios
      .post("/api/logout")
      .then((response) => {
        setLoggedUser(null);
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  };

  useEffect(() => {
    if (loggedUser != null) {
      setDisplayLogin(false);
      setDisplaySignup(false);
    }
  }, [loggedUser]);

  return (
    <div>
      <AuthApi.Provider value={{ loggedUser, setLoggedUser }}>
        <Navbar
          toggleLoginBox={toggleLoginBox}
          toggleSignupBox={toggleSignupBox}
          handleLogout={handleLogout}
        />
        {displaySignup && (
          <Dialog handleClose={toggleSignupBox}>
            <SignupForm />
          </Dialog>
        )}
        {displayLogin && (
          <Dialog handleClose={toggleLoginBox}>
            <LoginForm />
          </Dialog>
        )}
        <GraphEditor />
      </AuthApi.Provider>
    </div>
  );
}

export default App;
