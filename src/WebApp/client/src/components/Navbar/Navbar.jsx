import React, { useContext } from "react";
import { HashLink, HashLink as Link } from "react-router-hash-link";

import AuthApi from "../../AuthApi";

import Logo from "../../logo.png";

const Navbar = (props) => {
  const Auth = useContext(AuthApi);

  return (
    <nav className="navbar">
      <div className="logo-box">
        <img src={Logo} alt="" srcset="" className="logo-img" />
        <h3 className="logo-text">Visual Dijkstra</h3>
      </div>
      <ul className="nav-list">
        <li className="nav-list-element">
          <Link className="nav-link" to="/">
            Home
          </Link>
        </li>
        <li className="nav-list-element">
          <Link className="nav-link" to="/app">
            WebApp
          </Link>
        </li>
        <li className="nav-list-element">
          <Link className="nav-link" to="/download">
            Download
          </Link>
        </li>
        {Auth.loggedUser == null ? (
          <>
            <li className="nav-list-element">
              <p
                className="nav-link"
                onClick={() => {
                  props.toggleLoginBox();
                }}
              >
                Login
              </p>
            </li>
            <li className="nav-list-element">
              <p
                className="nav-link"
                onClick={() => {
                  props.toggleSignupBox();
                }}
              >
                Sign up
              </p>
            </li>
          </>
        ) : (
          <li className="nav-list-element">
            <p
              className="nav-link"
              onClick={() => {
                props.handleLogout();
              }}
            >
              Logout
            </p>
          </li>
        )}
      </ul>
    </nav>
  );
};

export default Navbar;
