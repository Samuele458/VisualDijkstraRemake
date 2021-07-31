import React, { useState } from "react";

import GraphEditor from "./components/GraphEditor";
import Navbar from "./components/Navbar";
import Dialog from "./components/Dialog";
import SignupForm from "./components/SignupForm";

import "./app.scss";

function App() {
  const [displayLogin, setDisplayLogin] = useState(false);
  const [displaySignup, setDisplaySignup] = useState(false);

  const toggleLoginBox = () => {
    setDisplayLogin(!displayLogin);
  };

  const toggleSignupBox = () => {
    setDisplaySignup(!displaySignup);
  };

  return (
    <div>
      <Navbar
        toggleLoginBox={toggleLoginBox}
        toggleSignupBox={toggleSignupBox}
      />
      {displaySignup && (
        <Dialog>
          <SignupForm />
        </Dialog>
      )}
      <GraphEditor />
    </div>
  );
}

export default App;
