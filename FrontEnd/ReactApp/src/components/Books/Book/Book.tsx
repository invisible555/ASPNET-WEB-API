import styles from "./Book.module.css";
import img from "../../../assets/images/react.svg";

function Book(props) {

  return (
    <div className={`row ${styles.book}`}>
      <div className="col-4">
        <img src={img} alt="" className="img-fluid" />
      </div>
      <div className="col-8">
        <div className="row">
          <div className="col">
            <p>{props.name}</p>
            <p>{props.description}</p>
          </div>
        </div>
      </div>
      <div className="col-12">
        <p>Opis</p>
        <a href="#" className="btn btn-primary">
          Pokaż
        </a>
      </div>
    </div>
  );
}

export default Book;
