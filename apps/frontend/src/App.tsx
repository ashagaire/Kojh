import { BrowserRouter, Routes, Route } from "react-router-dom";
import CompanyList from "./pages/CompanyList";
import "./App.css";
import React from "react";

function App() {
  return (
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<CompanyList />} />
        </Routes>
      </BrowserRouter>
    </React.StrictMode>
  );
}

export default App;
