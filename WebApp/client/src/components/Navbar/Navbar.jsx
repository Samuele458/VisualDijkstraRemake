const Navbar = (props) => {
  return (
    <nav className="navbar">
      <ul className="nav-list">
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
      </ul>
    </nav>
  );
};

export default Navbar;
