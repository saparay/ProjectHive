import { useEffect, useState } from "react";
import { RetriveAllProjects } from "../services/ApiService";
import { ProjectHiveListResponse } from "../Models/ProjectTrackerModel";
import "./css/ProjectHiveList.css";
import { useSharedFilterRequestBody } from "../services/CustomSharedStates";
import { useNavigate } from "react-router-dom";
import Loader from "./Header/Loader";
import ErrprPage from "./ErrorPage";
import Pagination from "./Pagination";

export default function ProjectHiveList() {
  const navigate = useNavigate();
  const [projectTracker, setProjectTracker] =
    useState<ProjectHiveListResponse>();
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const { filterDataRequestBody } = useSharedFilterRequestBody();
  const [errorMsg, setErrorMsg] = useState<boolean>(false);

  useEffect(() => {
    setIsLoading(true);
    const debounceTimer = setTimeout(() => {
      RetriveAllProjects(filterDataRequestBody)
        .then((response) => setProjectTracker(response.data))
        .catch(() => setErrorMsg(true));
    }, 350);
    setIsLoading(false);
    return () => clearTimeout(debounceTimer);
  }, [filterDataRequestBody]);
  if (isLoading) {
    return (
      <div className="table-loader-container">
        <Loader />
      </div>
    );
  }
  if (errorMsg) {
    return (
      <>
        <ErrprPage />
      </>
    );
  }

  return (
    <>
      <div className="table-container">
        <div className="table-header-row">
          <div className="table-header-column">Project Id</div>
          <div className="table-header-column">Project Name</div>
          <div className="table-header-column">Arrival Source</div>
          <div className="table-header-column">Arrival Date</div>
          <div className="table-header-column">Cistomer Name</div>
          <div className="table-header-column">Submission Date</div>
          <div className="table-header-column">View</div>
          <div className="table-header-column">Edit</div>
        </div>
        {projectTracker?.data.map((item) => {
          return (
            <div className="table-body-row" key={item.id}>
              <div className="table-body-column" title={item.projectId}>
                {item.projectId}
              </div>
              <div className="table-body-column">{item.projectName}</div>
              <div className="table-body-column">{item.arrivalSource}</div>
              <div className="table-body-column">{item.arrivalDate}</div>
              <div className="table-body-column">{item.customerName}</div>
              <div className="table-body-column">{item.submissionDate}</div>
              <div className="table-body-column">
                <button onClick={() => navigate(`detail/${item.id}`)}>
                  View
                </button>
              </div>
              <div className="table-body-column">
                <button>Edit</button>
              </div>
            </div>
          );
        })}
      </div>
      <Pagination
        isNextDisabled={!projectTracker?.hasNext}
        isPrevDisabled={projectTracker?.previous === null}
      />
    </>
  );
}
