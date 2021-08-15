import useError from "../../hooks/useError";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";

function ErrorNotification() {
  const { error, removeError } = useError();

  const handleSubmit = () => {
    removeError();
  };

  return (
    <div
      open={!!error}
      className="error-notification-box"
      style={{ visibility: error ? "visible" : "hidden" }}
    >
      <FontAwesomeIcon
        icon={faTimes}
        onClick={handleSubmit}
        className="btn-icon"
      />
      {error && error.message && <p>{error.message}</p>}
    </div>
  );
}

export default ErrorNotification;
