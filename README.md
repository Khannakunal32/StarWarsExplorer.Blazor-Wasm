# Star Wars Explorer 🌌✨

A modern single-page web application (SPA) built with **Blazor WebAssembly** and **.NET 8**, showcasing information from the Star Wars universe using the [SWAPI.tech](https://www.swapi.tech/) API.

> 🛠️ **Developed in under 5 hours** as a technical demonstration of Blazor WASM and .NET 8.

🔗 **Live Demo**: [https://kk-starwarsexplorer.netlify.app/](https://kk-starwarsexplorer.netlify.app/)

## 🚀 Features

- 🔎 **Search** for Characters, Planets, and Films
- 🛰️ **Navigate** between related resources (e.g., view characters appearing in a film)
- 📚 **Pagination** support for large datasets
- 🛡️ **Global Exception Interception**
- 🎨 **Polished, Responsive UI** built with Bootstrap
- 🧹 **Clean architecture** with service abstractions and reusable components
- 🧩 **Dynamic Templates** using `RenderFragment<T>` for flexibility
- ⚡ **Optimized API calls** to avoid redundant requests

---

## 🛠️ Technologies Used

- **.NET 8 / Blazor WebAssembly**
- **C#**
- **Bootstrap 5** for styling
- **HttpClient** for API calls
- **Custom Exception Middleware** for error handling
- **SWAPI.tech** API as the backend

---

## 🗺️ Application Structure

| Layer | Details |
|:---|:---|
| `Services/` | API services and helpers for SWAPI integration |
| `Components/` | Reusable Blazor components like PaginatedListPage, SearchBox, PaginationControl, etc. |
| `Pages/` | Feature pages (e.g., Characters.razor, Planets.razor) |
| `Models/` | Typed models for API responses |

---

## 🖥️ Demo Walkthrough

- **Landing Page**: Displays a paginated, searchable list of resources (Planets, Characters, or Films).
- **Search**: Instantly filter by name or title with responsive updates.
- **Detail Links**: Navigate from a Film to view all Characters featured.
- **Error Handling**: API errors are caught globally and displayed as non-intrusive toast notifications.

---

## 🏗️ Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/sanjaybk1998/starwars.explorer.git
   cd starwars.explorer
   dotnet restore
   dotnet run
   ```
2. Open your browser and navigate to: [https://localhost:5001](https://localhost:5001)

## 📋 Notes
- The application uses [https://www.swapi.tech/](https://www.swapi.tech/) for all Star Wars data.
- Some API limitations (such as partial linking between resources) are handled gracefully.
- Global error handling ensures that users are informed of any API/server issues without application crashes.

- 🧠 Bonus Features
- **Global Exception Interceptor**:
Catches exceptions from all service calls and shows user-friendly error messages via toasts.
- **Dynamic Item Rendering**:
PaginatedListPage uses RenderFragment<T> to dynamically render different item cards (FilmCard, PlanetCard, CharacterCard).
- **Optimized API Requests**:
First-render optimization to prevent multiple redundant API hits.
- **Cross linking of pages**:
1. Films will display navigable planets and character data.
2. Character id's can further show character name on user demand of a button press
