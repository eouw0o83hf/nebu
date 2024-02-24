import React from 'react'
import ReactDOM from 'react-dom/client'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Home from './components/home/Home.tsx';
import ErrorPage from './components/error/Error.tsx';
import BucketList from './components/buckets/BucketList.tsx';
import FileList from './components/files/FileList.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    errorElement: <ErrorPage />,
  },
  {
    path: "/buckets",
    element: <BucketList />,
  },
  {
    path: "/files",
    element: <FileList />,
  }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
