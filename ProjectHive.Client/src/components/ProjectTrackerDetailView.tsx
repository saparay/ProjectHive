import { useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { RetriveProjectDetails } from "../services/ApiService";
import { ProjectTrackerDetail } from "../Models/ProjectTrackerModel";
import "./css/ProjectTrackerDetailView.css";
import html2canvas from "html2canvas";
import jsPDF from "jspdf";
import pdfImageIcon from "/images/pdf_icon.png";
import backIconImg from "../../public/images/back_icon.webp";

export default function ProjectTrackerDetailView() {
  const { id } = useParams();
  const [projectTracker, setProjectTracker] = useState<ProjectTrackerDetail>();
  const contentRef = useRef<HTMLDivElement>(null);
  const navigate = useNavigate();
  useEffect(() => {
    if (id) {
      const projectTrackerId: number = parseInt(id, 10);
      if (!isNaN(projectTrackerId)) {
        RetriveProjectDetails(projectTrackerId).then((response) => {
          setProjectTracker(response.data);
        });
      }
    }
  }, [id]);

  const handleDownloadPDF = () => {
    const input = contentRef.current;
    if (input) {
      html2canvas(input, {
        scale: 2, // Increase scale for better resolution
        useCORS: true, // Handle CORS issues for images
      })
        .then((canvas) => {
          const imgData = canvas.toDataURL("image/png");
          const pdf = new jsPDF("p", "mm", "a4");
          const imgWidth = 210; // A4 width in mm
          const pageHeight = 295; // A4 height in mm
          const imgHeight = (canvas.height * imgWidth) / canvas.width;
          let heightLeft = imgHeight;
          let position = 0;

          pdf.addImage(imgData, "PNG", 0, position, imgWidth, imgHeight);
          heightLeft -= pageHeight;

          while (heightLeft >= 0) {
            position = heightLeft - imgHeight;
            pdf.addPage();
            pdf.addImage(imgData, "PNG", 0, position, imgWidth, imgHeight);
            heightLeft -= pageHeight;
          }

          pdf.save(`${projectTracker?.projectName}.pdf`);
        })
        .catch((error) => {
          console.error("Error generating PDF:", error);
        });
    }
  };

  return (
    <>
      <div>
        <div className="back-button-container">
          <button onClick={() => navigate('/')} title="Back">
            <img src={backIconImg} alt="" style={{ height: "30px" }} />
          </button>
        </div>
        <div className="pdf-downmoad-button-container">
          <button onClick={handleDownloadPDF} title="Download as PDF">
            <img
              src={pdfImageIcon}
              alt="Download as PDF"
              style={{ height: "25px" }}
            />
            <div className="download-button-text">Download as PDF</div>
          </button>
        </div>
      </div>
      <div className="detail-container" ref={contentRef}>
        <div className="detail-header">
          <div>{projectTracker?.projectName}</div>
        </div>
        <div className="detail-row-1">
          <div className="detail-column-1">
            <div className="deatil-column-label">Project Id</div>
            <div className="deatil-column-data">
              {projectTracker?.projectId}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Project Description</div>
            <div className="deatil-column-data textarea-style">
              {projectTracker?.projectDescription}
            </div>
          </div>
        </div>
        <div className="detail-row-2">
          <div className="detail-column-1">
            <div className="deatil-column-label">Account List</div>
            <div className="deatil-column-data">
              {projectTracker?.accountList.value}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Vertical List</div>
            <div className="deatil-column-data">
              {projectTracker?.verticalList.value}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Status List</div>
            <div className="deatil-column-data">
              {projectTracker?.statusList.value}
            </div>
          </div>
        </div>
        <div className="detail-row-3">
          <div className="detail-column-1">
            <div className="deatil-column-label">Arrival Source</div>
            <div className="deatil-column-data">
              {projectTracker?.arrivalSource}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Arrival Source IG</div>
            <div className="deatil-column-data">
              {projectTracker?.arrivalSourceIG}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Arrival Source</div>
            <div className="deatil-column-data">
              {projectTracker?.arrivalSource}
            </div>
          </div>
        </div>
        <div className="detail-row-4">
          <div className="detail-column-1">
            <div className="deatil-column-label">Arrival Source IG</div>
            <div className="deatil-column-data">
              {projectTracker?.arrivalSourceIG}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Customer Name</div>
            <div className="deatil-column-data">
              {projectTracker?.customerName}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Customer Email</div>
            <div className="deatil-column-data">
              {projectTracker?.customerEmail}
            </div>
          </div>
        </div>
        <div className="detail-row-5">
          <div className="detail-column-1">
            <div className="deatil-column-label">Arrival Date</div>
            <div className="deatil-column-data">
              {projectTracker?.arrivalDate}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Questions Submission Date</div>
            <div className="deatil-column-data">
              {projectTracker?.questionsSubmissionDate}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Questions Response Date</div>
            <div className="deatil-column-data">
              {projectTracker?.questionsResponseDate}
            </div>
          </div>
        </div>
        <div className="detail-row-6">
          <div className="detail-column-1">
            <div className="deatil-column-label">Submission Date</div>
            <div className="deatil-column-data">
              {projectTracker?.submissionDate}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Client Presentation Date</div>
            <div className="deatil-column-data">
              {projectTracker?.clientPresentationDate}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Deal Decision Date</div>
            <div className="deatil-column-data">
              {projectTracker?.dealDecisionDate}
            </div>
          </div>
        </div>
        <div className="detail-row-7">
          <div className="detail-column-1">
            <div className="deatil-column-label">
              Expected Project Start Date
            </div>
            <div className="deatil-column-data">
              {projectTracker?.expectedProjectStartDate}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Closure Date</div>
            <div className="deatil-column-data">
              {projectTracker?.closureDate}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Revenue Start Date</div>
            <div className="deatil-column-data">
              {projectTracker?.revenueStartDate}
            </div>
          </div>
        </div>
        <div className="detail-row-8">
          <div className="detail-column-1">
            <div className="deatil-column-label">Solution Architect</div>
            <div className="deatil-column-data">
              {projectTracker?.solutionArchitect}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Up Or Cross Sell</div>
            <div className="deatil-column-data">
              {projectTracker?.upOrCrossSell}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">
              Up Or Cross Selling Description
            </div>
            <div className="deatil-column-data">
              {projectTracker?.upOrCrossSellingDescription}
            </div>
          </div>
        </div>
        <div className="detail-row-9">
          <div className="detail-column-1">
            <div className="deatil-column-label">
              Prior Practice Experience With Customer
            </div>
            <div className="deatil-column-data">
              {projectTracker?.priorPracticeExperienceWithCustomer}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">
              Reson For Not Proposing Tools
            </div>
            <div className="deatil-column-data">
              {projectTracker?.resonForNotProposingTools}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Deal TCV</div>
            <div className="deatil-column-data">{projectTracker?.dealTCV}</div>
          </div>
        </div>
        <div className="detail-row-10">
          <div className="detail-column-1">
            <div className="deatil-column-label">Deal PAT</div>
            <div className="deatil-column-data">{projectTracker?.dealPAT}</div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Win Probability</div>
            <div className="deatil-column-data">
              {projectTracker?.winProbability}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Overall Team Size</div>
            <div className="deatil-column-data">
              {projectTracker?.overallTeamSize}
            </div>
          </div>
        </div>
        <div className="detail-row-11">
          <div className="detail-column-1">
            <div className="deatil-column-label">Geography Location</div>
            {projectTracker?.geographyLocations?.map((item) => (
              <div className="deatil-column-data" key={item.id}>
                {item.value}
              </div>
            ))}
          </div>
        </div>
        <div className="detail-row-12">
          <div className="detail-column-1">
            <div className="deatil-column-label">Total Team Size</div>
            <div className="deatil-column-data">
              {projectTracker?.totalTeamSize}
            </div>
          </div>
          <div className="detail-column-2">
            <div className="deatil-column-label">Mail List</div>
            <div className="deatil-column-data textarea-style">
              {projectTracker?.mailList}
            </div>
          </div>
          <div className="detail-column-3">
            <div className="deatil-column-label">Comments</div>
            <div className="deatil-column-data textarea-style">
              {projectTracker?.comments}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
