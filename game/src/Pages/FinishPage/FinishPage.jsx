import React from "react";
import "../FinishPage/FinishPage.css";
import Game from "../Game/Game";

const FinishPage = (props) => {

  const onClickHandler = () => {
    return <Game></Game>

  }

  return (
    <div className="container-finish">
      <div className="scores">Твои очки: {props.score}</div>
      <button onClick={onClickHandler} className="restart_btn">
        Начать заново
      </button>
    </div>
  );
};
export default FinishPage;
