import React, { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";

import AuthApi from "../../AuthApi";
import useError from "../../hooks/useError";

import Loading from "../Loading";

const LoginForm = (props) => {
  const Auth = useContext(AuthApi);
  const { addError } = useError();
  const [onLoading, setOnLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data) => {
    setOnLoading(true);
    setErrorMessage("");
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
        if (error.response.status === 404)
          setErrorMessage("Invalid credentials");
        else addError("Server error");
        setOnLoading(false);
      });
  };

  return (
    <form className="form" onSubmit={handleSubmit(onSubmit)}>
      <h2>Login</h2>
      <div className="form-item">
        <div className="form-item-header">
          <label htmlFor="email" className="form-label">
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
            <p className="form-error">Password must be at least 8 characters</p>
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

      <div className="toolbar">
        <button type="submit" className="button">
          Submit
        </button>
      </div>
      <div className="toolbar">
        {onLoading && <Loading />}
        <p className="error">{errorMessage}</p>
      </div>
      <p className="small-text center-text">
        Do not have an account?{" "}
        <a href="#" onClick={props.handleSignupButtonClick}>
          Click here to sign up
        </a>
        .
      </p>
    </form>
  );
};

export default LoginForm;
