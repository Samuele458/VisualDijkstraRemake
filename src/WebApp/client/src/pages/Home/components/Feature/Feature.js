import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const Feature = (props) => {
  return (
    <div className="feature v-flex zoom-2">
      <FontAwesomeIcon icon={props.icon} className="feature-icon" />
      <h2 className="feature-title">{props.title}</h2>
      <p className="feature-text">{props.text}</p>
    </div>
  );
};

export default Feature;
