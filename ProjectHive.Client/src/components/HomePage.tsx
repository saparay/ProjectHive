import FilterComponent from "./FilterComponent/FilterComponent";
import Header from "./Header";
import Pagination from "./Pagination";
import ProjectHiveList from "./ProjectHiveList";

export default function HomePage() {
  return (
    <>
      <FilterComponent />
      <ProjectHiveList />
      <Pagination />
    </>
  );
}
