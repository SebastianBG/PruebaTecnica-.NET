import axios from "axios";

const API_URL = "https://localhost:5256/api";

export async function getCatFact() {
    const res = await axios.get(`${API_URL}/fact`);
    return res.data;
}

export async function getGif(fact) {
    const res = await axios.get(`${API_URL}/gif`, {
        params: { fact },
    });
    return res.data.gifUrl;
}

export async function getHistory() {
    const res = await axios.get(`${API_URL}/history`);
    return res.data;
}