import { useSharedFilterRequestBody } from "../services/CustomSharedStates";
import "./css/Pagination.css";

export interface PaginationProps{
  isNextDisabled?: boolean;
  isPrevDisabled?: boolean;
}


export default function Pagination(props: PaginationProps) {
  const { filterDataRequestBody, setFilterDataRequestBody } =
    useSharedFilterRequestBody();
  return (
    <>
      <div className="pagination-container">
        <button
        disabled={props.isPrevDisabled}
          className="previous-page-button"
          onClick={() => {
            let pageNumber: number = filterDataRequestBody?.page;
            setFilterDataRequestBody((prev) => ({
              ...prev,
              page: pageNumber - 1,
            }));
          }}
        >
          Prev
        </button>

        <div className="current-page-number">{filterDataRequestBody?.page}</div>

        <button
        disabled={props.isNextDisabled}
          className="next-page-button"
          onClick={() => {
            let pageNumber: number = filterDataRequestBody?.page;
            setFilterDataRequestBody((prev) => ({
              ...prev,
              page: pageNumber + 1,
            }));
          }}
        >
          Next
        </button>

        <select
          id="page-size-selector"
          className="current-page-number"
          value={filterDataRequestBody.pageSize} // Bind the state to the select value
          onChange={(e) => {
            setFilterDataRequestBody(prev => ({
              ...prev,
              pageSize: parseInt(e.target.value)
            }))
          }} // Handle the change event
        >
          <option value="10">10</option>
          <option value="25">25</option>
          <option value="50">50</option>
          <option value="100">100</option>
        </select>
      </div>
    </>
  );
}
