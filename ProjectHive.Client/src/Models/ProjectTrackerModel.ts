import { AccountList } from "./AccountListModel";
import { GeographyLocation } from "./GeographyLocationModel";
import { StatusList } from "./StatusListModel";
import { VerticalList } from "./VerticalListModel";

export interface ProjectTrackerDetail {
  id: number;
  projectId: string;
  projectName: string;
  projectDescription: string;
  arrivalSource: string;
  arrivalSourceIG: string;
  customerName: string;
  customerEmail: string;
  arrivalDate: string;
  questionsSubmissionDate: string;
  questionsResponseDate: string;
  submissionDate: string;
  clientPresentationDate: string;
  dealDecisionDate: string;
  expectedProjectStartDate: string;
  closureDate: string;
  revenueStartDate: string;
  solutionArchitect: string;
  upOrCrossSell: boolean;
  upOrCrossSellingDescription: string;
  priorPracticeExperienceWithCustomer: string;
  resonForNotProposingTools: string;
  dealTCV: number;
  dealPAT: number;
  winProbability: number;
  overallTeamSize: number;
  totalTeamSize: number;
  mailList: string;
  comments: string;
  createdDate: string;
  createdBy: string;
  lastUpdatedDate: string;
  lastUpdatedBy: string;
  accountList: AccountList;
  verticalList: VerticalList;
  statusList: StatusList;
  geographyLocations: GeographyLocation[];
}

export interface ProjectTrackerList{
  id: number;
  projectId: string;
  projectName: string;
  arrivalSource: string;
  arrivalDate: string;
  customerName: string;
  submissionDate: string;
}
export interface ProjectHiveListResponse {
    data: ProjectTrackerList[]
    next: string;
    hasNaxt: boolean;
    previous: string;
    totalCount: number;
}


export interface FilterDataRequestBody {
  searchText?: string;
  accountList?: number[];
  statusList?: number[];
  verticalList?: number[];
  geographyLocation?: number[];
}