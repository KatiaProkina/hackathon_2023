import React from "react";
import "../FinishPage/FinishPage.css";
import { useNavigate } from "react-router-dom";

const FinishPage = (props) => {
  const navigate = useNavigate();
  const onClickHandler = () => navigate("/");

  console.log(props.score);
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
