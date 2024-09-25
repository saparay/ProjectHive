import { Route, Routes } from 'react-router-dom'
import Header from './components/Header'
import HomePage from './components/HomePage'
import ProjectTrackerDetailView from './components/ProjectTrackerDetailView'
import NotFound from './components/NotFound'

function App() {

  return (
    <>
    <Header />
    <Routes>
      <Route path='/' element={<HomePage/>}/>
      <Route path='detail/:id' element={<ProjectTrackerDetailView/>}/>
      <Route path='*' element={<NotFound/>}/>
    </Routes>
    </>
  )
}

export default App
