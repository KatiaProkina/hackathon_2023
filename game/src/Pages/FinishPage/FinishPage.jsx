import React from "react";
import "../FinishPage/FinishPage.css";

const FinishPage = (props) => {
  return (
    <div className="container-finish">
      <div className="scores">Твои очки: {props.score}</div>
      <button onClick={props.deleteResult} className="restart_btn">
        Начать заново
      </button>
    </div>
  );
};
export default FinishPage;
