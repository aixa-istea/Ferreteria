# Modelo de Datos - Ferretería "El Tornillo"

> Documentación técnica de la base de datos del sistema

---

## Resumen

| Característica | Detalle |
|----------------|---------|
| **Motor** | MySQL 8.0 |
| **Tablas** | 18 |
| **Vistas** | 4 |
| **Relaciones** | 22 claves foráneas |
| **Normalización** | 3NF (con excepción controlada) |

---

## Diagrama Entidad-Relación

![Modelo ER](./Recursos/ModeloER.png)

*Diagrama generado mediante ingeniería inversa desde MySQL Workbench.*

---

## Diseño del Modelo

### Principios aplicados

1. **Integridad referencial:** Todas las relaciones están definidas con claves foráneas.
2. **Auditoría:** Cada transacción registra el `id_usuario` que la realizó.
3. **Estandarización:** Uso de `ENUM` para estados fijos y tablas maestras para datos variables.

---

## Diccionario de Datos

> **Nota:** El detalle completo de campos, tipos y restricciones se desarrolla en el **Diccionario de Datos** (documento separado). Este documento se enfoca en la estructura general y las decisiones de diseño, basadas en el relevamiento del sistema y en el Diccionario de Datos como fuente principal para la definición de los campos.

### 1. Tablas Maestras

| Tabla | Propósito |
|-------|-----------|
| `roles` | Roles de usuario disponibles en el sistema |
| `usuarios` | Usuarios del sistema con credenciales de acceso |
| `clientes` | Clientes de la ferretería |
| `marcas` | Catálogo de marcas de productos |
| `categorias_producto` | Catálogo de categorías de productos |
| `productos` | Catálogo de productos con precios y stock |
| `proveedores` | Proveedores de productos |
| `medio_pago` | Medios de pago disponibles en el sistema |

---

### 2. Tablas Transaccionales

| Tabla | Propósito |
|-------|-----------|
| `venta` | Cabecera de cada transacción de venta |
| `detalle_venta` | Líneas de detalle de cada venta (productos vendidos) |
| `pedido_proveedor` | Cabecera de pedidos a proveedores |
| `detalle_pedido_proveedor` | Líneas de detalle de pedidos a proveedores |
| `factura_proveedor` | Facturas recibidas de proveedores |
| `recepcion_pedido` | Registro de recepción de pedidos |
| `recepcion_detalle` | Líneas de detalle de recepción de pedidos |
| `pago_proveedor` | Registro de pagos a proveedores |

---

### 3. Tablas de Relación (Muchos a Muchos)

#### `productos_x_categoria`

Relaciona productos con categorías.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `id_producto` | INT FK | ID del producto (PK compuesta) |
| `id_categoria` | INT FK | ID de la categoría (PK compuesta) |

#### `productos_x_proveedor`

Relaciona productos con proveedores.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `id_producto` | INT FK | ID del producto (PK compuesta) |
| `id_proveedor` | INT FK | ID del proveedor (PK compuesta) |

### Relaciones Principales

## Ventas

```text
clientes (1) ---< (N) venta (1) ---< (N) detalle_venta (N) >--- (1) productos
                                       |
                                       +--- (N) >--- (1) medio_pago
                                       +--- (N) >--- (1) usuarios
```

## Compras

```text
proveedores (1) ---< (N) pedido_proveedor (1) ---< (N) detalle_pedido_proveedor (N) >--- (1) productos
```

## Pagos a Proveedores

```text
factura_proveedor (1) ---< (N) pago_proveedor (N) >--- (1) medio_pago
```

### Reglas de Negocio

| Entidad | Campo | Valores posibles |
|---------|-------|------------------|
| `productos` | `estado` | `activo`, `discontinuado`, `eliminado` |
| `venta` | `estado_venta` | `confirmada`, `anulada` |
| `factura_proveedor` | `estado_factura` | `pendiente`, `pagada` |
| `pedido_proveedor` | `estado` | `pendiente`, `recibido` |
| `roles` | `nombre` | `admin`, `vendedor`, `cajero` |
| `medio_pago` | `nombre` | `efectivo`, `tarjeta_debito`, `tarjeta_credito`, `qr` |

### Seguridad

- Contraseñas: Almacenadas con hash SHA-256
- Auditoría: Las transacciones registran id_usuario
- Integridad: Claves foráneas en todas las relaciones

## Consultas Útiles

```sql
-- Productos con stock bajo
SELECT * FROM productos 
WHERE stock_actual < stock_minimo AND estado = 'activo';
```

![Productos con stock bajo](./Recursos/sql-stock-bajo.png)
*Productos con stock bajo, consulta desde MySQL Workbench.*

```sql
-- Valor del inventario
SELECT 
    SUM(stock_actual * precio_costo) AS valor_costo,
    SUM(stock_actual * precio_venta) AS valor_venta
FROM productos 
WHERE estado = 'activo';
```

![Valor del inventario](./Recursos/sql-valor-inventario.png)
*Valor del inventario, consulta desde MySQL Workbench.*

## Archivos Relacionados

- **Script SQL:** `database/ferreteria_el_tornillo.sql`
- **Relevamiento:** `documentacion/RelevamientoOLA.md`
- **Diccionario de Datos:** `documentacion/Diccionario de Datos.md`
- **README Principal:** `README.md`
