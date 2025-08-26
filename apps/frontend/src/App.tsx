import { Routes, Route } from "react-router-dom";
import CompanyList from "./pages/CompanyList";
import "./App.css";
import Layout from "./components/Layout";

function App() {
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<div> Landing Page </div>} />
        <Route path="/companies" element={<CompanyList />} />
      </Routes>
    </Layout>
  );
}

export default App;
