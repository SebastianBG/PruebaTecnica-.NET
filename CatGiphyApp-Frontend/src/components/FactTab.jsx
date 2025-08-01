import { useState, useEffect, useRef } from "react";
import { getCatFact, getGif } from "../api/backend";

export default function FactTab() {
    const [fact, setFact] = useState("");
    const [gifUrl, setGifUrl] = useState("");
    const [loading, setLoading] = useState(false);
    const hasFetched = useRef(false);

    useEffect(() => {
        if (hasFetched.current) return;
        hasFetched.current = true;

        loadFactAndGif();
    }, []);

    async function loadFactAndGif() {
        setLoading(true);
        try {
            const fetchedFact = await getCatFact();
            setFact(fetchedFact);
            const gif = await getGif(fetchedFact);
            setGifUrl(gif);
        } catch (err) {
            console.error("Error al cargar fact y gif:", err);
        }
        setLoading(false);
    }

    async function refreshGif() {
        setLoading(true);
        try {
            const gif = await getGif(fact);
            setGifUrl(gif);
        } catch (err) {
            console.error("Error al refrescar gif:", err);
        }
        setLoading(false);
    }

    if (loading) return <p>Cargando...</p>;

    return (
        <div className="fact-container">
            {gifUrl && <img src={gifUrl} alt="gif" />}
            <div className="fact-text">
                <p>{fact}</p>
                <button onClick={refreshGif}>Refrescar GIF</button>
            </div>
        </div>
    );
}
