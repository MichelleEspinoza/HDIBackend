# HDI Backend API

Sistema de gestión de pólizas y reportes de incidentes HDI.

## 📋 Requisitos Previos
- **Node.js**: Versión 22.x o superior (se recomienda usar [nvm](https://github.com/nvm-sh/nvm) para gestionar versiones).
- **PostgreSQL**: 15+.


## 🚀 Instalación
1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/MichelleEspinoza/HDIBackend
   cd HdiBackend
2. **Configuración:**
    Configura tu cadena de conexión en appsettings.json.
3. **Base de datos:**
    dotnet ef database update
    dotnet run

🛠️ Tecnologías
ASP.NET Core 8
Entity Framework Core 8.0
PostgreSQL 15.12
BCrypt.Net
Node 22.22.0

📋 Changelog
## 🚀 Primeros pasos
1. **Instalar dependencias:**
   ```bash
   npm install
2. **Variables de entorno:**
Crea un archivo .env en la raíz y define API_URL=http://localhost:5000/api.
3. **Iniciar desarrollo::**
   ```bash
   dotnet run