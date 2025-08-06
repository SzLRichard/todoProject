import { createBrowserRouter, RouterProvider } from "react-router-dom"
import HomePage from "./page/HomePage"
import ErrorPage from "./page/errorPage"


const router = createBrowserRouter(
  [
    {
      path: "/",
      element: <HomePage />,
      errorElement: <ErrorPage />
    }
  ]
)

function App() {
  return <RouterProvider router={router} />
}

export default App
