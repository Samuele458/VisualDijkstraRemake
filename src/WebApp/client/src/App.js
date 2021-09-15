import React, { useState, useEffect } from "react";
import axios from "axios";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

import GraphEditor from "./components/GraphEditor";
import Navbar from "./components/Navbar";
import Dialog from "./components/Dialog";
import SignupForm from "./components/SignupForm";
import LoginForm from "./components/LoginForm";
import ErrorNotification from "./components/ErrorNotification";

import "./app.scss";

import AuthApi from "./AuthApi";
import ErrorProvider from "./providers/ErrorProvider";
import SignupVerificationPage from "./pages/SignupVerificationPage";
import NotFoundPage from "./pages/NotFoundPage";
import Home from "./pages/Home/Home";

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
        console.log("Error");
      });
  };

  const handleLoginButtonClick = (e) => {
    setDisplayLogin(true);
    setDisplaySignup(false);
  };

  const handleSignupButtonClick = (e) => {
    setDisplayLogin(false);
    setDisplaySignup(true);
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
      .catch((error) => {});
  }, []);

  return (
    <div>
      <AuthApi.Provider value={{ loggedUser, setLoggedUser }}>
        <ErrorProvider>
          <Router>
            <ErrorNotification />
            <Navbar
              toggleLoginBox={toggleLoginBox}
              toggleSignupBox={toggleSignupBox}
              handleLogout={handleLogout}
            />
            {displaySignup && (
              <Dialog handleClose={toggleSignupBox}>
                <SignupForm handleLoginButtonClick={handleLoginButtonClick} />
              </Dialog>
            )}

            {displayLogin && (
              <Dialog handleClose={toggleLoginBox}>
                <LoginForm handleSignupButtonClick={handleSignupButtonClick} />
              </Dialog>
            )}

            <Switch>
              <Route path="/" exact component={() => <Home />} />
              <Route path="/app" exact component={() => <GraphEditor />} />
              <Route path="/verify/:token" component={SignupVerificationPage} />
              <Route component={NotFoundPage} />
            </Switch>
          </Router>
        </ErrorProvider>
      </AuthApi.Provider>
    </div>
  );
}

export default App;
