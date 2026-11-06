import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { createBrowserRouter, RouterProvider } from 'react-router';
import Layout from './components/Layout';
import Home from './pages/Home';
import PageNotFound from './pages/PageNotFound';
import About from './pages/About';
import Music from './pages/Music';

const router = createBrowserRouter([
   { 
    path: "/",
     element: <Layout />,
    children: [
      //elementy do Outlet
      {index: true, Component: Home},
      {path:"about", Component: About},
     // {path:"music", element:<Music />},
      {path:"music",Component: Music},




      {path: "*", element: <PageNotFound/>}
    ]}
])


function App() { 
  return <RouterProvider router={router}/>
}

export default App
