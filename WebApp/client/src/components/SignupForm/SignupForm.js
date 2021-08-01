import React, { useRef, useContext } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";

import AuthApi from "../../AuthApi";

const SignupForm = () => {
  const Auth = useContext(AuthApi);

  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm();

  const password = useRef({});
  password.current = watch("password", "");

  const onSubmit = async (data) => {
    axios
      .post("/api/register", {
        Name: data.username,
        Email: data.email,
        Password: data.password,
      })
      .then((response) => {
        axios
          .post("/api/login", {
            Email: data.email,
            Password: data.password,
          })
          .then((response) => {
            console.log("SUCCESS LOGIN", response);
            Auth.setLoggedUser(data);
          })
          .catch((error) => {
            console.log("ERROR LOGIN", error);
          });
      })
      .catch((error) => {
        console.log("ERROR", error);
      });
  };
  console.log(errors);

  return (
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
    </form>
  );
};

export default SignupForm;
