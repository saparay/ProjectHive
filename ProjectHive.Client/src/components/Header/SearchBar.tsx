import { useSharedFilterRequestBody } from "../../services/CustomSharedStates";
import "./css/search.css";
import SearchButtonIcon from "/images/search_icon.webp";
export default function SearchBar() {
  const { filterDataRequestBody, setFilterDataRequestBody } =
    useSharedFilterRequestBody();
  return (
    <>
      <div
        className="nav-bar-conmponent-container"
        style={{ alignContent: "flex-end" }}
      >
        <div className="nav-bar-search-bar">
          <button disabled style={{borderRadius: '5px 0px 0px 5px', backgroundColor: "white"}}>
            <img style={{ maxHeight: "20px" }} src={SearchButtonIcon} alt="" />
          </button>
          <input
            style={{ padding: "5px" }}
            type="text"
            placeholder="sreach projects..."
            name="search"
            id="search-bar"
            value={filterDataRequestBody.searchText || ""}
            onChange={(e) =>
              setFilterDataRequestBody((prev) => ({
                ...prev,
                searchText: e.target.value,
              }))
            }
          />
        </div>
      </div>
    </>
  );
}
