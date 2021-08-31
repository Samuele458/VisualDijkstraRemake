import {
  faCheckCircle,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import React, { useState, useEffect } from "react";
import { useParams } from "react-router";

import axios from "axios";

import Loading from "../../components/Loading";

const SignupVerificationPage = () => {
  const verifyingStates = {
    LOADING: 0,
    VERIFIED: 1,
    ERROR: 2,
  };

  const { token } = useParams();

  const [currentState, setCurrentState] = useState(verifyingStates.LOADING);

  useEffect(() => {
    axios
      .get("/api/verification?token=" + token, {})
      .then((response) => {
        setCurrentState(verifyingStates.VERIFIED);
      })
      .catch((error) => {
        setCurrentState(verifyingStates.ERROR);
      });
  }, []);

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
