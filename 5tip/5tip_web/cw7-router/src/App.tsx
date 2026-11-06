import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { createBrowserRouter, RouterProvider } from 'react-router';
import Layout from './components/Layout';
import Home from './pages/Home';
import PageNotFound from './pages/PageNotFound';
import About from './pages/About';

const router = createBrowserRouter([
   { 
    path: "/",
     element: <Layout />,
    children: [
      //elementy do Outlet
      {index: true, element: <Home />},
      {path:"about", element:<About />},




      {path: "*", element: <PageNotFound/>}
    ]}
])


function App() { 
  return <RouterProvider router={router}/>
}

export default App
