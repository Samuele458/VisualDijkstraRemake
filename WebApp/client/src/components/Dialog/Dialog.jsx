const Dialog = (props) => {
  return (
    <div className="dialog-box">
      <div className="dialog">
        <p className="close-dialog" onClick={props.handleClose}>
          X
        </p>
        {props.children}
      </div>
    </div>
  );
};

export default Dialog;
