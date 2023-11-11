import React from "react";
import scare1 from "../../../public/scared_ghost.png";
import scare2 from "../../../public/scare-robot.png";
import scare3 from "../../../public/scare-bones-man.png";

const fears = [
  {
    name: "1",
    src: scare1, // Замени 'source1' на фактический путь к изображению
    alt: "страх",
    points: 1,
  },
  {
    name: "2",
    src: scare2, // Замени 'source2' на фактический путь к изображению
    alt: "ужас",
    points: 2,
  },
  {
    name: "3",
    src: scare3, // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3,
  },
];

export function getRandomFear() {
  const randomIndex = Math.floor(Math.random() * fears.length);
  return fears[randomIndex];
}
