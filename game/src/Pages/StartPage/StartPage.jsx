import React from "react";
import { useNavigate } from "react-router-dom";
import icon1 from "../../../public/fairy.png";
import icon2 from "../../../public/dragon.png";
import icon3 from "../../../public/rainbow.png";
import icon4 from "../../../public/unicorn.png";
import "../StartPage/StartPage.css";

const StartPage = () => {
  const navigate = useNavigate();

  const handleStart = () => {
    navigate("/game");
  };

  return (
    <div className="container">
      <img src="../../../public/rainbow_big.png" alt="" className="rainbow" />
      <img src="../../../public/oblako.png" alt="" className="oblako1" />
      <img src="../../../public/oblako.png" alt="" className="oblako2" />
      <div className="title-block">
        <h1>Победитель страхов</h1>

        <img src={icon1} alt="" className="icon1" />
        {/* <img src={icon2} alt="" className="icon2" /> */}
        <img src={icon3} alt="" className="icon3" />
        <img src={icon4} alt="" className="icon4" />
        <div className="title-description-game-block">
          У тебя есть 15 секунд, чтобы победить как можно больше страхов. Кликая
          на страх - ты побеждаешь его. Чем больше страхов ты победишь, тем
          больше очков наберешь. Удачи!
        </div>
      </div>
      <button className="start-game-btn" onClick={handleStart}>
        Начать игру
      </button>
    </div>
  );
};
export default StartPage;
