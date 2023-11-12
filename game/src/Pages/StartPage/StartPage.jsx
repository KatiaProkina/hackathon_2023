import React from "react";
import { useNavigate } from "react-router-dom";
import icon1 from "../../../public/fairy.png";
import icon2 from "../../../public/dragon.png";
import icon3 from "../../../public/rainbow.png";
import icon4 from "../../../public/unicorn.png";
import "../StartPage/StartPage.css";
import { useDisclosure } from "@chakra-ui/react";
import {
  Button,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalCloseButton,
  ModalBody,
  ModalFooter,
  Text,
} from "@chakra-ui/react";

const StartPage = () => {
  const navigate = useNavigate();

  const handleStart = () => {
    navigate("/game");
  };

  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <div className="container">
      <img src="../../../public/rainbow_big.png" alt="" className="rainbow" />
      <img src="../../../public/oblako.png" alt="" className="oblako1" />
      <img src="../../../public/oblako.png" alt="" className="oblako2" />
      <div className="title-block">
        <h1 className="name-game">Победитель страхов</h1>

        <img src={icon1} alt="" className="icon1" />

        <img src={icon3} alt="" className="icon3" />
        <img src={icon4} alt="" className="icon4" />
        <div className="title-description-game-block">
          У тебя есть 15 секунд, чтобы победить как можно больше страхов. Кликая
          на страх - ты побеждаешь его. Чем больше страхов ты победишь, тем
          больше очков наберешь. Удачи!
        </div>
      </div>
      <div className="btn-group">
        <>
          <Button
            onClick={onOpen}
            backgroundColor="rgb(164, 224, 246)"
            color="white"
            border-radius=" 6px"
            padding="15px 35px"
            font-size="30px"
            marginRight="25px"
          >
            Лучшие результаты
          </Button>

          <Modal isOpen={isOpen} onClose={onClose}>
            <ModalOverlay />
            <ModalContent>
              <ModalHeader>ТОП игроков </ModalHeader>
              <ModalCloseButton />
              <ModalBody>
                <Text />
              </ModalBody>
            </ModalContent>
          </Modal>
        </>
        <button className="start-game-btn" onClick={handleStart}>
          Начать игру
        </button>
      </div>
    </div>
  );
};
export default StartPage;
