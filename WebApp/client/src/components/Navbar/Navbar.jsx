import React, { useContext } from "react";

import AuthApi from "../../AuthApi";

const Navbar = (props) => {
  const Auth = useContext(AuthApi);

  console.log("NAVBAR:", Auth.loggedUser);

  return (
    <nav className="navbar">
      <ul className="nav-list">
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
