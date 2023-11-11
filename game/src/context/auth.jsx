import React, { useState } from "react";
export const AuthContext = React.createContext();

export const AuthContextProvider = ({ children }) => {
  const [score, setScore] = useState(0);

  return (
    <AuthContext.Provider value={{ score, setScore }}>
      {children}
    </AuthContext.Provider>
  );
};
