import { useState } from "react";
import "./FinishPage.css";
import { useNavigate } from "react-router-dom";
import axios from 'axios'

const FinishPage = ({ score }) => {
  const navigate = useNavigate();
  // Состояние для имени пользователя
  const [username, setUsername] = useState(""); 

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
      // Проверяем, если score пустой или равен 0, устанавливаем score в 0
      if (!score || score === 0) {
        score = 0;
      }
  
      const response = await axios.post("https://localhost:44365/api/players/", {
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
      <button type="button" onClick={onClickHandler} className="restart_btn">
          Начать заново
        </button>
      {/* Добавляем форму для ввода имени пользователя */}

      <div className="form_wrapper">
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


        <button type="button" onClick={sendResultHandler} className="server_btn">
          Отправить результат
        </button>
      </div>
    </div>
  );
};

export default FinishPage;





