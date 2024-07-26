import Header from "./components/Header/Header";
import Menu from "./components/Menu/Menu";
import Books from "./components/Books/Books";
import { Component } from "react";
import LoadingIcon from "./components/UI/LoadingIcon/LoadingIcon";
import IBook from "./interfaces/IBook";

class App extends Component {
  books: IBook[] = [
    {
      id: 1,
      name: "Ksiazka1",
      rating: 8.0,
      description: "fajna",
    },
    {
      id: 2,
      name: "Ksiazka2",
      rating: 8.0,
      description: "fajna",
    },
  ];
  state = {
    books: [],
    loading: true,
  };

  searchHandler = (term: string) => {
    console.log("Szukaj z app", term);
    const books = [...this.books].filter((x) =>
      x.name.toLowerCase().includes(term.toLowerCase())
    );
    this.setState({ books });
  };

  componentDidMount() {
    setTimeout(() => {
      this.setState({
        books: this.books,
        loading: false,
      });
    }, 1000);
    console.log("component zamontowany");
  }

  render() {
    return (
      <div className="App">
        <Header onSearch={this.searchHandler} />
        <Menu />
        {this.state.loading ? (
          <LoadingIcon />
        ) : (
          <Books books={this.state.books} />
        )}
      </div>
    );
  }
}

export default App;
