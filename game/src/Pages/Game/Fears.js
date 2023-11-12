import React from "react";
import scare2 from "../../../public/scare-robot.png";
import scare3 from "../../../public/scare-bones-man.png";
import scare4 from "../../../public/scare-shark.png";
import scare5 from "../../../public/scare-warrior.png";
import scare6 from "../../../public/scare-witch.png";

const fears = [
  {
    name: "1",
    src: scare2, // Замени 'source2' на фактический путь к изображению
    alt: "ужас",
    points: 2,
  },

  {
    name: "2",
    src: scare3, // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3,
  },
  {
    name: "3",
    src: scare4, // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3,
  },
  {
    name: "4",
    src: scare5, // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3,
  },
  {
    name: "5",
    src: scare6, // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3,
  },
];

export function getRandomFear() {
  const randomIndex = Math.floor(Math.random() * fears.length);
  return fears[randomIndex];
}
