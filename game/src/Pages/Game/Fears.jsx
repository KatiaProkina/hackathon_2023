import React from "react";

const fears = [
  {
    name: "1",
    src: "source1", // Замени 'source1' на фактический путь к изображению
    alt: "страх",
    points: 1
  },
  {
    name: "2",
    src: "source2", // Замени 'source2' на фактический путь к изображению
    alt: "ужас",
    points: 2
  },
  {
    name: "3",
    src: "source3", // Замени 'source3' на фактический путь к изображению
    alt: "кошмар",
    points: 3
  }
];

export function getRandomFear() {
  const randomIndex = Math.floor(Math.random() * fears.length);
  return fears[randomIndex];
}
