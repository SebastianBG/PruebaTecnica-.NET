# Prueba Tecnica en .NET con React
Una aplicación fullstack que conecta datos aleatorios sobre gatos (Cat Facts) con gifs relacionados (Giphy), mostrando resultados visuales y guardando un historial de búsqueda. Desarrollada en .NET 8 para el backend y React (JavaScript) con Vite para el frontend.


---

## ⚙️ Tecnologías usadas

- Backend: .NET 8, ASP.NET Core Web API, Entity Framework Core, SQLite
- Frontend: React + Vite (JavaScript)
- Estilos: CSS puro
- API externas:
  - Cat Fact API: https://catfact.ninja/fact
  - Giphy API: https://developers.giphy.com/

---

## 🧠 ¿Qué hace esta app?

- Al cargar, obtiene un fact aleatorio sobre gatos.
- Muestra un GIF relacionado usando las 3 primeras palabras del fact.
- Permite refrescar el GIF manteniendo el mismo texto.
- Guarda el fact, el query usado y el gif en una base de datos local.
- Permite visualizar el historial completo.

---

## 🧪 Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js (LTS)](https://nodejs.org/)
- npm
- Visual Studio o Visual Studio Code

---

## 🚀 Instalación y ejecución

### 1. Clona el repositorio

```bash
git clone https://github.com/SebastianBG/PruebaTecnica-.NET.git
```

## 2. Backend (.NET)

```bash
cd CatGiphyApp-Backend
dotnet restore
dotnet run
```

El backend estará disponible en:

https://localhost:7123/swagger → Swagger UI

https://localhost:7123/api → API base

## 3. Frontend (React)
En otra terminal:

```bash
cd CatGiphyApp-Frontend
npm install
npm run dev
```
La app se abrirá en: http://localhost:5173

## 📚 Endpoints del Backend

| Método | Ruta                    | Descripción                          |
|--------|-------------------------|--------------------------------------|
| GET    | `/api/fact`            | Devuelve un cat fact aleatorio       |
| GET    | `/api/gif?fact=...`    | Devuelve un GIF basado en el fact    |
| GET    | `/api/history`         | Devuelve el historial completo       |

## 🔐 Notas sobre CORS
El backend ya está configurado para aceptar solicitudes desde el frontend (http://localhost:5173).
No necesitas configurar nada adicional si ejecutas ambos localmente.