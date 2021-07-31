import React from "react";

import { useForm } from "react-hook-form";

const SignupForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data) => {
    console.log(errors, data);
  };

  return (
    <form className="form" onSubmit={handleSubmit(onSubmit)}>
      <h2>Sign Up</h2>
      <div className="form-item">
        <label htmlFor="username" className="form-label">
          Username
        </label>
        {errors.username && (
          <p className="form-error">{errors.username.message}</p>
        )}
        <input
          type="text"
          className="form-input"
          placeholder="Enter username"
          {...register("username", { required: true, minLength: 8 })}
        />
      </div>
      <div className="form-item">
        <label htmlFor="username" className="form-label">
          Email
        </label>
        <input
          type="text"
          className="form-input"
          placeholder="Enter email"
          {...register("email", { required: true })}
        />
      </div>
      <div className="form-item">
        <label htmlFor="password" className="form-label">
          Password
        </label>
        <input
          type="password"
          className="form-input"
          placeholder="Enter password"
          {...register("password", { required: true })}
        />
      </div>
      <div className="form-item">
        <label htmlFor="repeatPassword" className="form-label">
          Repeat password
        </label>
        <input
          type="password"
          className="form-input"
          placeholder="Enter password again"
          {...register("repeatPassword", { required: true })}
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
