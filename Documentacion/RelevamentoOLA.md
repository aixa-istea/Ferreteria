# 🛠️ Sistema de Gestión — Ferretería "El Tornillo"

> Sistema informático de gestión de inventario y ventas para optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.

---

## 📋 Relevamiento General

La ferretería **"El Tornillo"** es atendida por sus **dos dueños** y **un hijo** como empleado/vendedor. A continuación se describe su funcionamiento actual y las necesidades detectadas.

### 🛒 Proceso de venta

1. **Ingreso del cliente:** ingresa al local y selecciona o solicita uno o más productos en el mostrador.
2. **Toma de datos:** el vendedor inicia el registro o la búsqueda del cliente en el sistema.
3. **Verificación de stock y precio:** el sistema debe mostrar de forma **simultánea** el precio de venta y la disponibilidad.
   - Si el cliente lo desea, se le informa el precio **independientemente** de si hay existencias o no.
4. **Carga del pedido:** si hay stock y el cliente acepta, se indica la cantidad deseada (paso repetitivo por cada artículo).
5. **Cobro:** en la misma pantalla, el vendedor selecciona el medio de pago (Efectivo, TDD, TDC o QR).
6. **Cierre:** el sistema genera el comprobante definitivo (**Ticket / Factura**) y descuenta automáticamente las unidades del inventario.

### 📦 Gestión de abastecimiento

1. **Control semanal de stock:** se analizan los productos con existencias mínimas o que deben reponerse.
2. **Pedido de compra:** con ese listado de faltantes, se genera un pedido formal a los proveedores.
3. **Entrega:** semanalmente el proveedor entrega la mercadería solicitada.
4. **Recepción y control:** la mercadería es recibida y controlada.
5. **Validación final:** se realiza el pago al proveedor, se registra la factura correspondiente y se da de alta o se actualiza el stock de los productos recibidos.

---

## ⚙️ Análisis de Tareas Operativas

| # | Tarea | Descripción |
|---|-------|-------------|
| 0 | **Personal** | Atendido por 2 dueños + 1 hijo como empleado/vendedor. |
| 1 | **Ingreso del cliente** | El cliente ingresa y selecciona o solicita un producto. |
| 2 | **Toma de datos** | Se solicitan los datos del cliente para registrarlos o buscarlos en la Tabla de Clientes. |
| 3 | **Verificación de stock y precio** | El vendedor consulta el producto; el sistema muestra precio y stock de forma simultánea. Se informa el precio aunque no haya existencias. |
| 4 | **Carga del pedido y cobro** | Si hay stock y el cliente acepta, se indica la cantidad (repetitivo por producto). El vendedor selecciona el medio de pago (Efectivo, TDD, TDC o QR). |
| 5 | **Registro y comprobante** | El sistema procesa el pago, genera el comprobante (Ticket/Factura) y descuenta automáticamente el inventario. |
| 6 | **Control de stock** | Se analizan los productos sin stock para determinar qué pedir. |
| 7 | **Pedido de compra** | Pedido formal semanal de faltantes a proveedores. Pago a proveedores 1 vez por semana. |
| 8 | **Recepción** | Los proveedores se presentan a cobrar y entregan su factura. |
| 9 | **Control y registro** | Se recibe la mercadería (si corresponde), se registra la factura y se procesa el pago al proveedor. |

---

## 🎯 Objetivo General

Desarrollar e implementar un sistema informático de gestión de inventario y ventas para la ferretería **"El Tornillo"** en un plazo de **4 meses**, que permita optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.

---

## 📌 Objetivos Específicos

### 1. Ventas y Clientes
- Automatizar el registro y la búsqueda de datos de clientes en el mostrador para reducir el tiempo de atención a **menos de 2 minutos por cliente**.
- Sistematizar la consulta unificada de precios y existencias para agilizar la respuesta al cliente.

### 2. Caja y Pagos
- Integrar en la interfaz de venta las múltiples formas de pago (**Efectivo, TDD, TDC y QR**) para centralizar la recaudación diaria en un solo paso operativo.

### 3. Stock y Alertas
- Implementar un módulo de verificación de stock **en tiempo real** que descuente las unidades del inventario automáticamente al confirmarse la venta.
- Generar reportes automáticos de productos sin stock o por debajo del stock mínimo para facilitar la toma de decisiones antes del pedido semanal.

### 4. Compras y Proveedores
- Registrar y asociar las facturas de los proveedores con la mercadería recibida para mantener actualizado el costo de los productos y el historial de pagos.

---

## 🚧 Límite

| | Punto |
|---|-------|
| **Desde** | El momento en que un cliente ingresa al local solicitando un producto o el vendedor inicia la consulta de datos en el mostrador. |
| **Hasta** | El registro definitivo de la factura del proveedor, el procesamiento de su correspondiente pago y la actualización del stock de mercadería recibida. |

---

## 🗂️ Alcance

### 👥 Módulo de Clientes
- **ABM de Clientes:** alta de nuevos clientes, baja (o inactivación) y modificación de datos personales (DNI/CUIT, teléfono, etc.).
- Consulta y búsqueda rápida de clientes por DNI/CUIT en el mostrador.

### 📦 Módulo de Productos e Inventario
- **ABM de Productos:** alta de nuevos artículos ferreteros, baja y modificación de descripciones, precios de costo, precios de venta y parametrización de `StockMinimo`.
- **Consulta Unificada:** pantalla de búsqueda que muestra el precio de venta y el stock disponible actual de manera inmediata.
- Monitoreo automático de existencias con **alertas visuales** de productos por debajo del stock mínimo.

### 🚚 Módulo de Proveedores y Compras
- **ABM de Proveedores:** alta, baja y modificación de las empresas proveedoras (Razón Social, CUIT, contacto).
- **Registro de Pedidos de Compra:** generación semanal de la orden de pedido basada en el reporte de alertas de stock.
- **Registro de Recepción de Mercadería:** ingreso de stock físico al sistema para sumar existencias de forma automática.
- Registro de facturas de proveedores y procesamiento de pago.

### 🧾 Módulo de Gestión de Ventas y Facturación
- **Carga de Pedido Directo:** selección de productos, validación visual de stock y carga de cantidades en una sola interfaz de mostrador.
- **Procesamiento de Pago y Cierre:** selección del medio de pago (Efectivo, TDD, TDC, QR) y emisión del ticket final de venta en el mismo momento.
- **Descuento Automatizado de Stock:** impacto inmediato en las tablas de ventas e inventario al confirmar la transacción, sin estados intermedios (sin remito pendiente).
