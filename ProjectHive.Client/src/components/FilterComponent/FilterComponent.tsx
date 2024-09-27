import { useEffect, useState } from "react";
import "./css/FilterComponent.css";
import {
  ExportToExcel,
  RetriveAllAccount,
  RetriveAllGeographyLocation,
  RetriveAllStatus,
  RetriveAllVertical,
} from "../../services/ApiService";
import { AccountList } from "../../Models/AccountListModel";
import FilterDropdown from "./FilterDropdown";
import { VerticalList } from "../../Models/VerticalListModel";
import { StatusList } from "../../Models/StatusListModel";
import { GeographyLocation } from "../../Models/GeographyLocationModel";
import { useSharedFilterRequestBody } from "../../services/CustomSharedStates";

export default function FilterComponent() {
  const [accountList, setAccountList] = useState<AccountList[]>([]);
  const [verticalList, setVerticalList] = useState<VerticalList[]>([]);
  const [statusList, setStatusList] = useState<StatusList[]>([]);
  const [geographyLocation, setGeographyLocation] = useState<
    GeographyLocation[]
  >([]);
  const { setFilterDataRequestBody } = useSharedFilterRequestBody();

  useEffect(() => {
    RetriveAllAccount().then((response) => {
      setAccountList(response.data);
    });
    RetriveAllVertical().then((response) => {
      setVerticalList(response.data);
    });
    RetriveAllStatus().then((response) => {
      setStatusList(response.data);
    });
    RetriveAllGeographyLocation().then((response) => {
      setGeographyLocation(response.data);
    });
  }, []);
  return (
    <>
      <div className="filter-container">
        <div className="filter-header">Filter Component</div>
        <div className="filter-dropdown-container">
          <FilterDropdown
            dropdownList={accountList}
            dropdownPlaceholder="Account List"
          />
          <FilterDropdown
            dropdownList={verticalList}
            dropdownPlaceholder="Vertical List"
          />
          <FilterDropdown
            dropdownList={statusList}
            dropdownPlaceholder="Status List"
          />
          <FilterDropdown
            dropdownList={geographyLocation}
            dropdownPlaceholder="Geography Location"
          />
          <button
            className="filter-reset-button"
            onClick={() =>
              setFilterDataRequestBody({
                page: 1,
                pageSize: 10,
              })
            }
          >
            Reset
          </button>
          <button className="filter-go-button">Create Project Tracker</button>
          <button
            className="filter-excel-button"
            onClick={() => ExportToExcel()}
          >
            Export To Excel
          </button>
        </div>
      </div>
    </>
  );
}
