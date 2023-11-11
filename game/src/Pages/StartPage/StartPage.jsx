import React from "react";
import { useNavigate } from "react-router-dom";

const StartPage = () => {
  const navigate = useNavigate();

  const handleStart = () => {
    navigate("/game");
  };

  return (
    <div>
      <h1>Hi</h1>
      <button onClick={handleStart}>Start</button>
    </div>
  );
};
export default StartPage;
