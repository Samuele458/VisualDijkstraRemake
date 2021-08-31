import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner } from "@fortawesome/free-solid-svg-icons";

const Loading = (props) => {
  return (
    <FontAwesomeIcon
      icon={faSpinner}
      spin
      className={props.dimension ? props.dimension : "standard-icon"}
      style={{
        visibility:
          typeof props.show === "undefined"
            ? "visible"
            : props.show
            ? "visible"
            : "hidden",
      }}
    />
  );
};

export default Loading;
