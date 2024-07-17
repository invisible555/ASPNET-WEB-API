import React from "react";

function SerachBar() {
  return (
    <div className="d-flex">
      <input className="form-control" type="text" placeholder="Szukaj..." />
      <button className="btn btn-primary">Szukaj</button>
    </div>
  );
}

export default SerachBar;
