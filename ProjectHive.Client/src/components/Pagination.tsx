import './css/Pagination.css'

export default function Pagination() {
  return (
    <>
      <div className="pagination-container">
          <button className="previous-page-button">Prev</button>

          <div className="current-page-number">1</div>

          <button className="next-page-button">Next</button>
      </div>
    </>
  );
}
