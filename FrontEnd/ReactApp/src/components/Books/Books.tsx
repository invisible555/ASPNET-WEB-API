import React from "react";
import Book from "./Book/Book";
import styles from "./Books.module.css";

function Books() {
  return (
    <div className={styles.container}>
      <h2 className={styles.title}>Książki: </h2>
      <Book />
      <Book />
    </div>
  );
}

export default Books;
