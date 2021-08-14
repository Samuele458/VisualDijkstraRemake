import React, { useState, useEffect } from "react";
import axios from "axios";

import GraphEditor from "./components/GraphEditor";
import Navbar from "./components/Navbar";
import Dialog from "./components/Dialog";
import SignupForm from "./components/SignupForm";
import LoginForm from "./components/LoginForm";
import ErrorNotification from "./components/ErrorNotification";

import "./app.scss";

import AuthApi from "./AuthApi";
import ErrorProvider from "./providers/ErrorProvider";

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

  useEffect(() => {
    axios
      .get("/api/user")
      .then((response) => {
        if (response.data && response.data.Email) {
          setLoggedUser({ email: response.data.Email });
        }
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  }, []);

  return (
    <div>
      <AuthApi.Provider value={{ loggedUser, setLoggedUser }}>
        <ErrorProvider>
          <ErrorNotification />
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
        </ErrorProvider>
      </AuthApi.Provider>
    </div>
  );
}

export default App;
