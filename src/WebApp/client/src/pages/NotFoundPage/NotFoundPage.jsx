import { faExclamationTriangle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";

const NotFoundPage = () => {
  return (
    <div className="not-found-page-wrapper">
      <div className="not-found-page">
        <div className="vflex flex-align-center">
          <FontAwesomeIcon icon={faExclamationTriangle} className="text-7" />
          <h1 className="text-6">404</h1>
          <h2 className="text-2">Not Found</h2>
        </div>
      </div>
    </div>
  );
};

export default NotFoundPage;
