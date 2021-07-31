const Dialog = (props) => {
  return (
    <div className="dialog-box">
      <div className="dialog">{props.children}</div>
    </div>
  );
};

export default Dialog;
