import { useState, useEffect, useContext } from "react";
import FinishPage from "../FinishPage/FinishPage";
import { useNavigate } from "react-router-dom";

import "./styles.css";
import { getRandomFear } from "./Fears";

function Game() {
  const navigate = useNavigate();

  const onStartPage = () => navigate("/");

  //настройки сложности (вынесутся в отдельный файл)
  // кол-во ячеек (кратно 3м)
  const CELLS = 9;
  //на сколько появляется страх в мс
  const TIME = 1500;
  //время Игры в секундах
  const gameTime = 15;

  //счет игры
  const [score, setScore] = useState(0);

  //отсчет времени
  const [time, setTime] = useState(gameTime);

  const [holes, setHoles] = useState(Array(CELLS).fill(null));

  useEffect(() => {
    const holeInterval = setInterval(() => {
      showHole();
    }, TIME);

    return () => clearInterval(holeInterval);
  }, []);

  useEffect(() => {
    const timerInterval = setInterval(() => {
      setTime((prevTime) => (prevTime > 0 ? prevTime - 1 : 0));
    }, 1000);

    // Обнулим интервал при размонтировании
    return () => clearInterval(timerInterval);
  }, []);

  const tapHole = (index) => {
    if (holes[index]) {
      const newHoles = [...holes];
      const fear = holes[index]; // выбор кол-ва очков в зависимости от страха.
      newHoles[index] = null;
      setHoles(newHoles);
      // Здесь живет логика подсчета очков и другие действия
      setScore((prevScore) => prevScore + fear.points);
    }
  };

  const showHole = () => {
    const randomIndex = Math.floor(Math.random() * holes.length);
    const newHoles = [...holes];
    newHoles[randomIndex] = getRandomFear();
    setHoles(newHoles);

    setTimeout(() => {
      newHoles[randomIndex] = null;
      setHoles(newHoles);
    }, 1000);
  };

  // а давай начнем сначала?
  const resetGame = () => {
    setTime(gameTime);
    setScore(0);
    setHoles(Array(CELLS).fill(null));
  };

  if (time > 0) {
    return (
      <div id="axis">
        <div className="game-container">
          <img
            src="../../../public/oblako.png"
            alt=""
            className="object van1 move-right"
          />
          <img
            src="../../../public/oblako.png"
            alt=""
            className="object van2 move-left"
          />
          <div className="scares-description">
            <h3>Описание страхов:</h3>
            <ul className="scares-list">
              <li>Акула - существо, символизирующее страх предательства.</li>
              <li>
                Грозный воин - Этот враг олицетворяет страх насилия. Грозный
                воин,олицетворяющий борьбу с прошлым травматическим опытом.
              </li>
              <li>
                Скелет - призрачная фигура, олицетворяющая страх одиночества.
              </li>
              <li>
                Ведьма - магическая сущность, олицетворяющая страх перед
                исчезновением матери.
              </li>
              <li>
                Робот - грозный враг-робот,символизирующий страх перед врачами.
              </li>
            </ul>
          </div>

          <div className="game-area">
            <div className="game-grid">
              {holes.map((fear, index) => (
                <div
                  key={index}
                  className={`hole ${fear ? "active" : ""}`}
                  onClick={() => tapHole(index)}
                >
                  {fear && (
                    <img src={fear.src} alt={fear.alt} className="fear" />
                  )}
                </div>
              ))}
            </div>
          </div>
          <div className="scores-time-block">
            <h2>Твои очки: {score}</h2>
            <h2>Time: {time}s</h2>
            <button className="resetBtn" onClick={resetGame}>
              Начать заново
            </button>
            <button className="resetBtn" onClick={onStartPage}>
              На главную
            </button>
          </div>
        </div>
      </div>
    );
  } else {
    return <FinishPage score={score} />;
  }
}

export default Game;
