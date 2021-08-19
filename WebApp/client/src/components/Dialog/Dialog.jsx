import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";

const Dialog = (props) => {
  return (
    <div className="dialog-box">
      <div className="dialog">
        <p className="close-dialog" onClick={props.handleClose}>
          <FontAwesomeIcon icon={faTimes} />
        </p>
        {props.children}
      </div>
    </div>
  );
};

export default Dialog;
