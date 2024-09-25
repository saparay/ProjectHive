import NotFoundImage from "../../public/images/not_found_Image.avif";

export default function NotFound() {
  return (
    <>
      <div
        className="not-found-container"
        style={{
          // display: 'initial',
          // justifyContent: 'center',
          marginLeft: "30%",
          marginRight: "30%",
          marginTop: "5%",
        }}
      >
        <div className="not-fount-image">
          <img
            src={NotFoundImage}
            alt="Not Found"
            style={{ height: "500px", width: "100%", borderRadius: '20px' }}
          />
        </div>
        <div className="not-founr-message">
          <p style={{ textAlign: "center", fontWeight: 'bold' }}>404 Not Found</p>
        </div>
      </div>
    </>
  );
}
