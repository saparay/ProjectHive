import { useState } from "react";
import { useBetween } from "use-between";
import { FilterDataRequestBody } from "../Models/ProjectTrackerModel";

function useSharedFilteredDataState() {
    const [filterDataRequestBody, setFilterDataRequestBody] = useState<FilterDataRequestBody>({});
    return { filterDataRequestBody, setFilterDataRequestBody };
};

export const useSharedFilterRequestBody = () => useBetween(useSharedFilteredDataState);