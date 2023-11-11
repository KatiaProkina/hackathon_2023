import { createBrowserRouter } from "react-router-dom";
import FinishPage from "../Pages/FinishPage/FinishPage";
import GamePage from "../Pages/GamePage/GamePage";
import StartPage from "../Pages/StartPage/StartPage";

export const router = createBrowserRouter([
  {
    path: "/",
    children: [
      {
        index: true,
        element: <StartPage />,
      },
      {
        path: "/game",
        element: <GamePage />,
      },
      {
        path: "/finish",
        element: <FinishPage />,
      },
    ],
  },
]);
