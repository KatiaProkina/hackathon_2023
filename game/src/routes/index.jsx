import { createBrowserRouter } from "react-router-dom";
import FinishPage from "../Pages/FinishPage/FinishPage";
import Game from "../Pages/Game/Game";
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
        element: <Game />,
      },
      {
        path: "/finish",
        element: <FinishPage />,
      },
    ],
  },
]);
