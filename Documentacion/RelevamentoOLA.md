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

## 🎯 Objetivo General

Desarrollar e implementar un sistema informático de gestión de inventario y ventas para la ferretería **"El Tornillo"** en un plazo de **4 meses**, que permita optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.

---
## 🚧 Límite

| | Punto |
|---|-------|
| **Desde** | El momento en que un cliente ingresa al local solicitando un producto o el vendedor inicia la consulta de datos en el mostrador. |
| **Hasta** | El registro definitivo de la factura del proveedor, el procesamiento de su correspondiente pago y la actualización del stock de mercadería recibida. |

---

---

## 🗂️ Alcance

### ✅ Incluye

- **ABM de Clientes**
- **ABM de Productos**
- **ABM de Marcas**
- **ABM de Proveedores**
- **Registro de Ventas**
- **Registro de Pedidos y Pagos a Proveedores**
- **ABM Usuarios**
- **ABM Roles**
- **Informes** de venta de productos, facturación, clientes, inventario.

### ❌ No Incluye

- **Ventas Online**
- **Entrega a domicilio**
- **Facturación de sueldos**

---



