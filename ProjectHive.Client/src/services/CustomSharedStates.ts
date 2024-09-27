import { useState } from "react";
import { useBetween } from "use-between";
import { FilterDataRequestBody } from "../Models/ProjectTrackerModel";

function useSharedFilteredDataState() {
  const [filterDataRequestBody, setFilterDataRequestBody] =
    useState<FilterDataRequestBody>({
      page: 1,
      pageSize: 10,
    });
  return { filterDataRequestBody, setFilterDataRequestBody };
}

export const useSharedFilterRequestBody = () =>
  useBetween(useSharedFilteredDataState);
