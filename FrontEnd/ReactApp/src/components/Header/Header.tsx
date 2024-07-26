import styles from "./Header.module.css";
import SearchBar from "./SearchBar/SearchBar";
import IHeaderProps from "../../interfaces/IHeaderProps";

function Header(props: IHeaderProps) {
  return (
    <header className={`${styles.header} container`}>
      <SearchBar onSearch={props.onSearch} />
    </header>
  );
}

export default Header;
