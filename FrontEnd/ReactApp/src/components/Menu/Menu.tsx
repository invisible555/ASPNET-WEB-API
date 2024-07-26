import styles from "./Menu.module.css";
function Menu() {
  return (
    <div className={`${styles.menuContainer} container`}>
      <ul className={styles.menu}>
        <li className={styles.menuItem}>
          <a>
            <a href="#"> Home</a>
          </a>
        </li>
      </ul>
    </div>
  );
}

export default Menu;
