import React, { useRef, useContext, useState } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";

import AuthApi from "../../AuthApi";
import useError from "../../hooks/useError";
import Loading from "../Loading";

import Logo from "../../logo.png";

const SignupForm = (props) => {
  const Auth = useContext(AuthApi);

  const [onLoading, setOnLoading] = useState(false);
  const [submitted, setSubmitted] = useState(false);
  const [email, setEmail] = useState("");

  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm();

  const { addError } = useError();

  const password = useRef({});
  password.current = watch("password", "");

  const onSubmit = async (data) => {
    setOnLoading(true);
    axios
      .post("/api/register", {
        Name: data.username,
        Email: data.email,
        Password: data.password,
      })
      .then((response) => {
        setSubmitted(true);
        setEmail(data.email);

        /*
        axios
          .post("/api/login", {
            Email: data.email,
            Password: data.password,
          })
          .then((response) => {
            Auth.setLoggedUser(data);
            setOnLoading(false);
          })
          .catch((error) => {
            addError("Server error");
            setOnLoading(false);
          });
          */
      })
      .catch((error) => {
        addError("Server error");
        setOnLoading(false);
      });
  };

  return (
    <>
      {submitted ? (
        <div className="verify-email">
          <h2>Verify your email</h2>
          <div className="vflex flex-align-center content">
            <img
              src={Logo}
              alt=""
              srcset=""
              style={{ width: "10rem" }}
              className="zoom-1"
            />
            <div className="text-section">
              <p>
                We have sent an email to <b>{email}</b>
              </p>
              <p>
                Please click on the link we sent to your email in order to
                enable your account
              </p>
            </div>
          </div>
          <div className="toolbar">
            <button
              type="submit"
              className="button"
              onClick={props.handleLoginButtonClick}
            >
              Login
            </button>
          </div>
        </div>
      ) : (
        <form className="form" onSubmit={handleSubmit(onSubmit)}>
          <h2>Sign Up</h2>
          <div className="form-item">
            <div className="form-item-header">
              <label htmlFor="username" className="form-label">
                Username
              </label>
              {errors.username && errors.username.type === "required" && (
                <p className="form-error">Username required</p>
              )}
              {errors.username && errors.username.type === "minLength" && (
                <p className="form-error">Username too short</p>
              )}
            </div>
            <input
              type="text"
              className="form-input"
              placeholder="Enter username"
              {...register("username", {
                required: true,
                minLength: 8,
              })}
            />
          </div>
          <div className="form-item">
            <div className="form-item-header">
              <label htmlFor="username" className="form-label">
                Email
              </label>
              {errors.email && <p className="form-error">Email required</p>}
            </div>
            <input
              type="text"
              className="form-input"
              placeholder="Enter email"
              {...register("email", { required: true })}
            />
          </div>
          <div className="form-item">
            <div className="form-item-header">
              <label htmlFor="password" className="form-label">
                Password
              </label>
              {errors.password && errors.password.type === "required" && (
                <p className="form-error">Password required</p>
              )}
              {errors.password && errors.password.type === "minLength" && (
                <p className="form-error">
                  Password must be at least 8 characters
                </p>
              )}
            </div>
            <input
              name="password"
              type="password"
              className="form-input"
              placeholder="Enter password"
              {...register("password", { required: true, minLength: 8 })}
            />
          </div>
          <div className="form-item">
            <div className="form-item-header">
              <label htmlFor="repeatPassword" className="form-label">
                Repeat password
              </label>
              {errors.repeatPassword && (
                <p className="form-error">The passwords do not match</p>
              )}
            </div>
            <input
              type="password"
              className="form-input"
              placeholder="Enter password again"
              {...register("repeatPassword", {
                validate: (value) => value === password.current,
              })}
            />
          </div>
          <div className="toolbar">
            <button type="submit" className="button">
              Submit
            </button>
          </div>
          <div className="toolbar">{onLoading && <Loading />}</div>
          <p className="small-text center-text">
            Already have an account?{" "}
            <a href="#" onClick={props.handleLoginButtonClick}>
              Click here to login
            </a>
            .
          </p>
        </form>
      )}
    </>
  );
};

export default SignupForm;
