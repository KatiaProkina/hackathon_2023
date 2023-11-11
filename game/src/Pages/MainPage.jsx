import React from "react";
import StartPage from "./StartPage/StartPage";
import FinishPage from "./FinishPage/FinishPage";
import Game from "./Game/Game";
const MainPage = () => {
  return (
    <div>
      <StartPage />
      <Game />
      <FinishPage />
    </div>
  );
};

export default MainPage;
