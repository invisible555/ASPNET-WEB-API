import Header from "./components/Header/Header";
import Menu from "./components/Menu/Menu";
import Books from "./components/Books/Books";
import { Component, useState } from "react";

class App extends Component {

  state = {
    books: [
      {
        id: 1,
        name: "Ksiazka1",
        rating: "8.0",
        description: "fajna",
      },
      {
        id: 2,
        name: "Ksiazka2",
        rating: "8.0",
        description: "fajna",
      },
    ],
  };
  render() {

    return (
      <div className="App">
        <Header />
        <Menu />
        <Books books={this.state.books} />
      </div>
    );
  }
}

export default App;
