# Ferretería El Tornillo
### Sistema de Gestión de Inventario y Ventas

**Materia:** Ingeniería de Software — ISTEA 2026  
**Grupo 1:** Rafael Enrique Cortez, Noelia Elisabeth Sanabria, Aixa Jezabel Sosa, Tomás Torres, Guillermo Eduardo Vicente

---

## Índice

- [Descripción](#descripción)
- [Documentación del proyecto](#documentación-del-proyecto)
- [Tecnologías](#tecnologías)
- [Requisitos previos](#requisitos-previos)
- [Cómo levantar el proyecto](#cómo-levantar-el-proyecto)
- [Usuarios de prueba](#usuarios-de-prueba)
- [Estructura del repositorio](#estructura-del-repositorio)

---

## Descripción

Sistema informático de gestión de inventario y ventas para la ferretería "El Tornillo". Centraliza el proceso de venta directa, cobro en el mostrador, control de stock y gestión de proveedores.

---

## Documentación del proyecto

| Documento | Descripción |
|---|---|
| [Relevamiento y OLA](Documentacion/RelevamentoOLA.md) | Objetivo, Límite y Alcance del sistema |
| [Diccionario de Datos](Documentacion/Diccionario%20de%20Datos.md) | Definición de entidades y atributos |
| [Modelo de Datos](Documentacion/Modelo%20de%20Datos.md) | Estructura de la base de datos, vistas y decisiones de diseño |
| [Diagrama de Actividad](Documentacion/UML/DiagramaActividad.md) | Flujo del proceso de negocio |
| [Diagrama de Secuencia — Venta](Documentacion/UML/DiagramaSecuencia-Cliente.md) | Interacción Cliente-Vendedor-Sistema |
| [Diagrama de Secuencia — Abastecimiento](Documentacion/UML/DiagramaSecuencia-Proveedor.md) | Interacción Empleado-Sistema-Proveedor |

---

## Tecnologías

| Capa | Tecnología |
|---|---|
| Backend | ASP.NET Core 8 Web API (C#) |
| Base de datos | MySQL 8 (en Docker) |
| ORM | Entity Framework Core + Pomelo (scaffold Database First) |
| Frontend | PWA — HTML5, CSS3, JavaScript vanilla |
| Contenedores | Docker Desktop + docker-compose |
| Control de versiones | Git + GitHub |

---

## Requisitos previos

| Herramienta | Descripción |
|---|---|
| [Docker Desktop](https://www.docker.com/products/docker-desktop) | Para correr MySQL en contenedor |
| [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/community/) | Para correr el backend C# |
| [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) | Para importar la base de datos |
| [VS Code](https://code.visualstudio.com/) | Para correr la PWA |
| Extensión Live Server (VS Code) | Para servir el frontend localmente |

---

## Cómo levantar el proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/aixa-istea/Ferreteria.git
cd Ferreteria
```

### 2. Levantar la base de datos con Docker

> Docker Desktop tiene que estar abierto y corriendo.

```bash
docker-compose up -d
```

Para verificar que está corriendo:
```bash
docker ps
```

### 3. Importar la base de datos

1. Abrí **MySQL Workbench** y conectate con:
   - **Host:** 127.0.0.1 — **Port:** 3308 — **User:** root — **Password:** ferreteria123
2. Abrí el archivo `database/ferreteria_el_tornillo.sql`
3. Ejecutalo con el botón del rayo (o `Ctrl+Shift+Enter`)

### 4. Levantar la API

1. Abrí `Ferreteria.sln` con **Visual Studio 2022**
2. Seleccioná el perfil **Container (Dockerfile)**
3. Presioná **F5**

La API queda disponible en `http://localhost:5080/swagger`

### 5. Levantar la PWA

1. Abrí **VS Code** → `File → Open Folder` → carpeta `ferreteria-pwa`
2. Click derecho en `index.html` → **Open with Live Server**

---

## Usuarios de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| cmendoza | admin123 | Admin |
| lgimenez | vende456 | Vendedor |
| rsosa | vende789 | Vendedor |
| palvarez | caja321 | Cajero |
| dfernandez | caja654 | Cajero |

---

## Estructura del repositorio

```
Ferreteria/
├── Documentacion/
│   ├── UML/                         # Diagramas de actividad y secuencia
│   ├── Recursos/                    # Imágenes y recursos gráficos
│   ├── RelevamentoOLA.md            # Objetivo, Límite y Alcance
│   ├── Diccionario de Datos.md      # Definición de entidades
│   └── Modelo de Datos.md           # Estructura de DB y vistas
│
├── Ferreteria.API/                  # ASP.NET Core Web API
│   ├── Controllers/                 # Endpoints REST
│   ├── Services/                    # Lógica de negocio
│   └── DTOs/                        # Objetos de transferencia
│
├── Ferreteria.Data/                 # Capa de acceso a datos
│   ├── EF/                          # DbContext
│   ├── Models/                      # Entidades EF Core
│   └── Repositories/
│       ├── Interfaces/
│       └── Implementations/
│
├── ferreteria-pwa/                  # Frontend PWA
│   ├── pages/                       # Pantallas
│   ├── css/                         # Estilos
│   └── js/                          # Lógica y cliente API
│
├── database/
│   └── ferreteria_el_tornillo.sql   # Dump completo (estructura + datos)
│
├── docker-compose.yml               # Configuración Docker
└── README.md
```