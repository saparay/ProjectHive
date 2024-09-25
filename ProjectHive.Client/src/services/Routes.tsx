import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import ProjectTrackerDetailView from "../components/ProjectTrackerDetailView";
import HomePage from "../components/HomePage";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {path: '', element: <HomePage/>},
            {path: 'detail/:id', element: <ProjectTrackerDetailView/>}
        ]
    }
])