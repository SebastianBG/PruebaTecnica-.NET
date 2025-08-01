import { useState } from "react";
import FactTab from "./components/FactTab";
import HistoryTab from "./components/HistoryTab";
import "./App.css";

function App() {
  const [activeTab, setActiveTab] = useState("fact");

  return (
    <div className="container">
      <h1>CatGiphy App</h1>

      <div className="tabs">
        <button
          onClick={() => setActiveTab("fact")}
          className={activeTab === "fact" ? "active" : ""}
        >
          Resultado Actual
        </button>
        <button
          onClick={() => setActiveTab("history")}
          className={activeTab === "history" ? "active" : ""}
        >
          Historial
        </button>
      </div>

      {activeTab === "fact" ? <FactTab /> : <HistoryTab />}
    </div>
  );
}

export default App;
