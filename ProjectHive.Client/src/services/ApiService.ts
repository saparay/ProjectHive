import axios from "axios";
import { FilterDataRequestBody } from "../Models/ProjectTrackerModel";

export const BaseUrl = "http://localhost:5205/api";

// const { searchText } = useSharedSearchText();

export async function RetriveAllProjects(
  filterRequestBody?: FilterDataRequestBody
) {
  console.log('filterRequestBody?.page', filterRequestBody?.page)
  return await axios.post(
    `${BaseUrl}/ProjectTracker?page=${filterRequestBody?.page}&pageSize=${filterRequestBody?.pageSize}`,
    filterRequestBody?.body
  );
}
export async function ExportToExcel() {
  try {
    // Make the GET request to fetch the file from the backend
    const response = await axios({
      url: `${BaseUrl}/ProjectTracker/export-excel`, // Replace with your API endpoint
      method: "GET",
      responseType: "blob", // Ensure the response is a Blob
    });
    const contentDisposition = response.headers["content-disposition"];
    console.log(contentDisposition);
    const filename = getDynamicFilename();
    // Create a URL for the Blob file and download it
    const fileURL = window.URL.createObjectURL(new Blob([response.data]));
    const link = document.createElement("a");
    link.href = fileURL;
    link.setAttribute("download", filename); // Specify the filename here
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link); // Cleanup the link element after download
  } catch (error) {
    console.error("Error downloading the file:", error);
  }
}
export async function RetriveProjectDetails(id: number) {
  return await axios.get(`${BaseUrl}/ProjectTracker/${id}`);
}
export async function RetriveAllAccount() {
  return await axios.get(`${BaseUrl}/AccountList`);
}
export async function RetriveAllVertical() {
  return await axios.get(`${BaseUrl}/VerticalList`);
}
export async function RetriveAllStatus() {
  return await axios.get(`${BaseUrl}/StatusList`);
}
export async function RetriveAllGeographyLocation() {
  return await axios.get(`${BaseUrl}/GeographyLocation`);
}

const getDynamicFilename = () => {
  const now = new Date();
  const timestamp = now.toISOString().slice(0, 19).replace(/:/g, "-");
  return `ProjectData_${timestamp}.xlsx`; // Filename with a timestamp
};
