import React from "react";
import footerlinks from "./footerlinks.js";
import { HashLink as Link } from "react-router-hash-link";

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-content hflex-responsive">
        {footerlinks.map((list, i) => {
          return (
            <div className="links-section" key={i}>
              <h2 className="links-title subtitle-light">{list.title}</h2>
              <ul className="links-list">
                {list.links.map((link, j) => {
                  if (link.url[0] === "/")
                    return (
                      <li className="footer-link-entry">
                        <Link to={link.url}>{link.title}</Link>
                      </li>
                    );
                  else
                    return (
                      <li className="footer-link-entry">
                        <a href={link.url}>{link.title}</a>
                      </li>
                    );
                })}
              </ul>
            </div>
          );
        })}
      </div>
      <p className="footer-bottom-text text-light">
        &copy; Copyright 2021{" "}
        <a href="https://samuelegirgenti.it.nf">Samuele Girgenti</a> - All
        rights reserved
      </p>
    </footer>
  );
};

export default Footer;
