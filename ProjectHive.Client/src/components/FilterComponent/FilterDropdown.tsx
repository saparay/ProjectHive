import { AccountList } from "../../Models/AccountListModel";
import { GeographyLocation } from "../../Models/GeographyLocationModel";
import { StatusList } from "../../Models/StatusListModel";
import { VerticalList } from "../../Models/VerticalListModel";
import { useSharedFilterRequestBody } from "../../services/CustomSharedStates";

interface FilterDropdownProps {
  dropdownList:
    | AccountList[]
    | VerticalList[]
    | StatusList[]
    | GeographyLocation[];
  dropdownPlaceholder?: string;
}
export default function FilterDropdown(props: FilterDropdownProps) {
  const { setFilterDataRequestBody } =  useSharedFilterRequestBody();
  return (
    <select className="filter-list-dropdown" defaultValue="" 
    onChange={(e) => {
      if(props.dropdownPlaceholder === 'Account List') setFilterDataRequestBody(prev => ({
        ...prev,
        accountList: [parseInt(e.target.value)]
      }))
      if(props.dropdownPlaceholder === 'Vertical List') setFilterDataRequestBody(prev => ({
        ...prev,
        verticalList: [parseInt(e.target.value)]
      }))
      if(props.dropdownPlaceholder === 'Status List') setFilterDataRequestBody(prev => ({
        ...prev,
        statusList: [parseInt(e.target.value)]
      }))
      if(props.dropdownPlaceholder === 'Geography Location') setFilterDataRequestBody(prev => ({
        ...prev,
        geographyLocation: [parseInt(e.target.value)]
      }))
    }}
    >
      <option value="" disabled>
        {props.dropdownPlaceholder}
      </option>
      {props.dropdownList.map((item) => {
        return (
          <option
            className="filter-dropdown-option"
            value={item.id}
            key={item.id}
          >
            {item.value}
          </option>
        );
      })}
    </select>
  );
}
