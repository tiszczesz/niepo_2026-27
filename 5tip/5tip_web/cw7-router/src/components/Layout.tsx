import { NavLink, Outlet } from "react-router";

const Layout = () => {
  return (
    <>
      <header>
        <nav
          className="d-flex gap-3 p-3"
          style={{ backgroundColor: "#c2bfbf" }}
        >
          <NavLink className="nav-link" to="/">
            Home
          </NavLink>
          <NavLink className="nav-link" to="/about">
            About
          </NavLink>
          <NavLink className="nav-link" to="/music">
            Music
          </NavLink>
        </nav>
      </header>
      <main className="container">
        <Outlet />
      </main>
      <footer
        style={{
          position: "fixed",
          bottom: 0,
          left: 0,
          width: "100%",
          borderTop: "solid grey 1px",
          textAlign: "center",
        }}
      >
        footer
      </footer>
    </>
  );
};

export default Layout;
