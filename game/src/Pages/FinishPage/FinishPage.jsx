import React, { useState } from "react";
import "./FinishPage.css";
import { useNavigate } from "react-router-dom";
import axios from 'axios'

const FinishPage = ({ score }) => {
  const navigate = useNavigate();
  const [username, setUsername] = useState(""); // Состояние для имени пользователя

  const onClickHandler = () => {
    // Перейти обратно на главную
    navigate("/");
  };

    // Отправить данные на сервер или выполнить другие необходимые действия
  const sendResultHandler = () => {
    sendResultsToServer(username, score);
  }


  const sendResultsToServer = async (username, score) => {
    try {
      const response = await axios.post("ваш_серверный_эндпоинт", {
        username: username,
        score: score,
      });

      // Выводим данные из ответа в консоль
      console.log("Данные успешно отправлены на сервер:", response.data);
    } catch (error) {
      // Обрабатываем ошибку при отправке запроса
      console.error("Ошибка при отправке данных на сервер:", error);
    }
  };

  return (
    <div className="container-finish">
      <div className="scores">Твои очки: {score}</div>
      {/* Добавляем форму для ввода имени пользователя */}
      <div>
      <form className="form">
        <label>
          Имя пользователя:
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </label>
        
      </form>
        <button type="button" onClick={onClickHandler} className="restart_btn">
          Начать заново
        </button>
        <button type="button" onClick={sendResultHandler} className="restart_btn">
          отправить результат
        </button>
      </div>
    </div>
  );
};

export default FinishPage;





