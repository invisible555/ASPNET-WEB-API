import React, { Component } from "react";
import Book from "./Book/Book";
import styles from "./Books.module.css";

class Books extends Component {
  render() {
    
    return (
      <div className={styles.container}>
        <h2 className={styles.title}>Książki: </h2>
        {this.props.books.map(book =><Book key={book.id} {...book} />)}
      </div>
    );
  }
}

export default Books;
