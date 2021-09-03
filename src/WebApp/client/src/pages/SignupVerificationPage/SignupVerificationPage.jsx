import {
  faCheckCircle,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import React, { useState, useEffect, useContext } from "react";
import { useParams } from "react-router";
import axios from "axios";

import Loading from "../../components/Loading";

import AuthApi from "../../AuthApi";

const SignupVerificationPage = () => {
  const verifyingStates = {
    LOADING: 0,
    VERIFIED: 1,
    ERROR: 2,
  };

  const Auth = useContext(AuthApi);

  const { token } = useParams();

  const [currentState, setCurrentState] = useState(verifyingStates.LOADING);

  const redirect = () => {
    setTimeout(() => {
      window.location.href = "/";
    }, 5000);
  };

  useEffect(() => {
    axios
      .get("/api/verification?token=" + token, {})
      .then((response) => {
        setCurrentState(verifyingStates.VERIFIED);
        redirect();
      })
      .catch((error) => {
        setCurrentState(verifyingStates.ERROR);
        redirect();
      });
  }, []);

  if (Auth.loggedUser) {
    redirect();
  }

  return (
    <div className="signup-verification-page-wrapper">
      <div className="signup-verification-page">
        {currentState === verifyingStates.LOADING ? (
          <>
            <Loading dimension="large-icon" />
            <div className="text-content">
              <h1 className="title">Verifying...</h1>
            </div>
          </>
        ) : currentState === verifyingStates.ERROR ? (
          <>
            <FontAwesomeIcon
              icon={faExclamationTriangle}
              className="extra-large-icon"
              style={{ color: "#f94545" }}
            />
            <div className="text-content">
              <h1 className="title">Error on verifying token</h1>
              <h2>
                Please check that you have opened the right link. If yes, please
                try again later.{" "}
              </h2>
            </div>
          </>
        ) : currentState === verifyingStates.VERIFIED ? (
          <>
            <FontAwesomeIcon
              icon={faCheckCircle}
              className="extra-large-icon"
              style={{ color: "#28f16e" }}
            />
            <div className="text-content">
              <h1 className="title">Account verified!</h1>
              <h2>You can close this tab, or login into your account</h2>
            </div>
          </>
        ) : null}
      </div>
    </div>
  );
};

export default SignupVerificationPage;
