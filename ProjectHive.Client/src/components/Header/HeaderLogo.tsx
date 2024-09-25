import HiveHeaderImage from "/images/HiveHeaderLogo.png";
import "./css/header.css";
import { useNavigate } from "react-router-dom";
export default function HeaderLogo() {
  const navigate = useNavigate();
  return (
    <>
      <div className="nav-bar-conmponent-container">
        <div className="nav-bar-logo" onClick={() => navigate('/')}>
          <img
            style={{ maxHeight: "50px", maxWidth: "50px" }}
            src={HiveHeaderImage}
            alt=""
          />
          <span style={{ fontSize: "40px", color: "white" }}>ProjectHive</span>
        </div>
      </div>
    </>
  );
}
