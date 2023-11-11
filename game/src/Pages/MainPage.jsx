import React from "react";
import GamePage from "./GamePage/GamePage";
import StartPage from "./StartPage/StartPage";
import FinishPage from "./FinishPage/FinishPage";
const MainPage = () => {
  return (
    <div>
      <StartPage />
      <GamePage />
      <FinishPage />
    </div>
  );
};

export default MainPage;
