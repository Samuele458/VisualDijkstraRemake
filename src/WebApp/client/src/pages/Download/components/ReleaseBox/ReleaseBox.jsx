import React from "react";

import marked from "marked";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import {
  faLinux,
  faWindows,
  faGithub,
} from "@fortawesome/free-brands-svg-icons";
import { faTags, faCode } from "@fortawesome/free-solid-svg-icons";

const parseMarkdown = (source) => {
  var rawMarkup;
  if (typeof source === "string") rawMarkup = marked(source);
  else rawMarkup = marked("Loading...");

  return { __html: rawMarkup };
};

const ReleaseBox = (props) => {
  /*const releaseDate = new Date(props.date);

  const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  const days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

  const dateString = `${days[releaseDate.getDay()]}, ${releaseDate.getDate()} ${
    months[releaseDate.getMonth()]
  } ${releaseDate.getFullYear()}`;*/

  return (
    <div className="release zoom-1">
      <h2 className="subtitle-black">
        {props.version}
        {props.latest ? (
          <span className="latest-version">
            <FontAwesomeIcon icon={faTags} style={{ marginRight: "0.5rem" }} />
            LATEST
          </span>
        ) : (
          ""
        )}
      </h2>
      <div className="btn-group">
        <h3>Download:</h3>
        {props.winLink ? (
          <a href={props.winLink} className="btn-dark">
            <FontAwesomeIcon icon={faWindows} className="btn-image" />
            Windows
          </a>
        ) : (
          ""
        )}
        {props.linuxLink ? (
          <a href={props.linuxLink} className="btn-dark">
            <FontAwesomeIcon icon={faLinux} className="btn-image" />
            Linux
          </a>
        ) : (
          ""
        )}
      </div>
      <h3 className="release-notes-title">Release notes</h3>
      <div
        className="markdown-area release-notes-box"
        dangerouslySetInnerHTML={parseMarkdown(props.notes)}
      ></div>
      <div className="btn-group">
        <a href={props.githubLink} className="btn-dark">
          <FontAwesomeIcon icon={faGithub} className="btn-image" />
          View on GitHub
        </a>
        <a href={props.sourceLink} className="btn-dark">
          <FontAwesomeIcon icon={faCode} className="btn-image" />
          Download source code
        </a>
      </div>
    </div>
  );
};

export default ReleaseBox;
