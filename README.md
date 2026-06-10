# 🔩 Ferretería El Tornillo

Proyecto para Ingeniería de Software
Sistema de gestión de inventario y ventas para la ferretería "El Tornillo".  
---

## 🛠️ Tecnologías

- **Backend:** ASP.NET Core 8 Web API (C#)
- **Base de datos:** MySQL 8 (en Docker)
- **ORM:** Entity Framework Core + Pomelo
- **Frontend:** PWA (HTML, CSS, JavaScript)

---

## ⚙️ Requisitos previos

Antes de arrancar, instalá lo siguiente:

| Herramienta |
|---|
| Docker Desktop |
| Visual Studio 2022 Community |
| MySQL Workbench |
| VS Code (para la PWA) |
| Extensión Live Server (VS Code) |

---

## 🚀 Cómo levantar el proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/aixa-istea/Ferreteria.git
cd Ferreteria
```

### 2. Levantar la base de datos con Docker

> ⚠️ Docker Desktop tiene que estar abierto y corriendo.

Abrí una terminal en la carpeta raíz del proyecto y ejecutá:

```bash
docker-compose up -d
```

Esto levanta MySQL en el puerto **3308**. La primera vez tarda un poco porque descarga la imagen.

Para verificar que está corriendo:
```bash
docker ps
```
Deberías ver `mysql-ferreteria` en la lista con estado `Up`.

### 3. Importar la base de datos

1. Abrí **MySQL Workbench**
2. Creá una nueva conexión:
   - **Host:** 127.0.0.1
   - **Port:** 3308
   - **User:** root
   - **Password:** ferreteria123
3. Conectate y abrí el archivo `database/ferreteria_el_tornillo.sql`
4. Ejecutalo con el botón del rayo ⚡ (o Ctrl+Shift+Enter)

Esto crea la base de datos, todas las tablas y carga los datos de prueba.

### 4. Levantar la API

1. Abrí `Ferreteria.sln` con **Visual Studio 2022**
2. Verificá que el perfil de ejecución sea **Container (Dockerfile)**
3. Presioná **F5** o el botón ▶️

La API queda disponible en:
- `http://localhost:5080/swagger` → documentación interactiva

> 💡 La primera vez que buildea el contenedor puede tardar unos minutos.

### 5. Levantar la PWA

1. Abrí VS Code
2. `File → Open Folder` → seleccioná la carpeta `ferreteria-pwa`
3. Click derecho en `index.html` → **Open with Live Server**
4. Se abre el navegador en `http://127.0.0.1:5500`

---

## 🔑 Usuarios de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| cmendoza | admin123 | Admin |
| lgimenez | vende456 | Vendedor |
| rsosa | vende789 | Vendedor |
| palvarez | caja321 | Cajero |
| dfernandez | caja654 | Cajero |

---

## 📁 Estructura del proyecto

```
Ferreteria/
├── Ferreteria.API/          # ASP.NET Core Web API
│   ├── Controllers/         # Endpoints REST
│   ├── Services/            # Lógica de negocio
│   └── DTOs/                # Objetos de transferencia
├── Ferreteria.Data/         # Capa de datos
│   ├── EF/                  # DbContext
│   ├── Models/              # Entidades
│   └── Repositories/        # Acceso a datos
├── ferreteria-pwa/          # Frontend PWA
│   ├── pages/               # Pantallas
│   ├── css/                 # Estilos
│   └── js/                  # Lógica JS y cliente API
├── database/                # Scripts SQL
├── docker-compose.yml       # Configuración Docker
└── README.md
```

---

## 🌐 Endpoints principales

| Módulo | Endpoint |
|---|---|
| Auth | `POST /api/auth/login` |
| Productos | `GET /api/productos` |
| Bajo stock | `GET /api/productos/bajo-stock` |
| Clientes | `GET /api/clientes` |
| Ventas | `POST /api/ventas` |
| Proveedores | `GET /api/proveedores` |
| Usuarios | `GET /api/usuarios` |

Documentación completa en Swagger: `http://localhost:5080/swagger`