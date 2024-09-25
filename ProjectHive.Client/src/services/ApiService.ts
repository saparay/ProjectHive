import axios from "axios";
import { FilterDataRequestBody } from "../Models/ProjectTrackerModel";

export const BaseUrl = 'https://localhost:7032/api';

// const { searchText } = useSharedSearchText();

export async function RetriveAllProjects(filterRequestBody?: FilterDataRequestBody){
    return await axios.post(`${BaseUrl}/ProjectTracker`, filterRequestBody);
}
export async function RetriveProjectDetails(id: number){
    return await axios.get(`${BaseUrl}/ProjectTracker/${id}`);
}
export async function RetriveAllAccount(){
    return await axios.get(`${BaseUrl}/AccountList`)
}
export async function RetriveAllVertical(){
    return await axios.get(`${BaseUrl}/VerticalList`)
}
export async function RetriveAllStatus(){
    return await axios.get(`${BaseUrl}/StatusList`)
}
export async function RetriveAllGeographyLocation(){
    return await axios.get(`${BaseUrl}/GeographyLocation`)
}


