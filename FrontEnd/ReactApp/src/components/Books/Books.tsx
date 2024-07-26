import { Component } from "react";
import Book from "./Book/Book";
import styles from "./Books.module.css";
import IBooksProps from "../../interfaces/IBookProps";

class Books extends Component<IBooksProps> {
  render() {
    return (
      <div className={styles.container}>
        <h2 className={styles.title}>Książki: </h2>
        {this.props.books.map((book) => (
          <Book key={book.id} {...book} />
        ))}
      </div>
    );
  }
}

export default Books;
