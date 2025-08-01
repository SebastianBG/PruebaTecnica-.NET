import { useState, useEffect } from "react";
import { getHistory } from "../api/backend";

export default function HistoryTab() {
    const [history, setHistory] = useState([]);

    useEffect(() => {
        async function fetchHistory() {
            const data = await getHistory();
            setHistory(data);
        }

        fetchHistory();
    }, []);

    return (
        <div style={{ paddingTop: "1rem" }}>
            <h2>Historial de búsquedas</h2>
            {history.length === 0 ? (
                <p>No hay resultados aún.</p>
            ) : (
                <table className="table-history">
                    <thead>
                        <tr>
                            <th>Fecha</th>
                            <th>Cat Fact</th>
                            <th>Query</th>
                            <th>GIF</th>
                        </tr>
                    </thead>
                    <tbody>
                        {history.map((item) => (
                            <tr key={item.id}>
                                <td>{new Date(item.searchDate).toLocaleString()}</td>
                                <td>{item.catFact}</td>
                                <td>{item.queryWords}</td>
                                <td>
                                    <a href={item.gifUrl} target="_blank" rel="noopener noreferrer">
                                        Ver GIF
                                    </a>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}