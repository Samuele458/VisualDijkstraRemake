import React, { useContext } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";

import AuthApi from "../../AuthApi";
import useError from "../../hooks/useError";

const LoginForm = () => {
  const Auth = useContext(AuthApi);
  const { addError } = useError();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data) => {
    axios
      .post("/api/login", {
        Email: data.email,
        Password: data.password,
      })
      .then((response) => {
        Auth.setLoggedUser(data);
      })
      .catch((error) => {
        addError("Login error");
      });
  };

  return (
    <form className="form" onSubmit={handleSubmit(onSubmit)}>
      <h2>Login</h2>
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
    </form>
  );
};

export default LoginForm;
