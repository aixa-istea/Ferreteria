# 🛠️ Sistema de Gestión — Ferretería "El Tornillo"

> Sistema informático de gestión de inventario y ventas para optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.

---

## 📋 Relevamiento

La ferretería **"El Tornillo"** es atendida por sus **dos dueños** y **un hijo** como empleado/vendedor. A continuación se describe su funcionamiento actual y las necesidades detectadas.
Cuando el cliente ingresa al local, selecciona o solicita uno o más productos en el mostrador. En ese momento, el vendedor inicia la toma de datos para registrarlo o buscarlo en el sistema. Acto seguido, se verifica la existencia de stock; el sistema debe mostrar de forma simultánea el precio de venta y la disponibilidad. Si el cliente lo desea, se le informa el precio independientemente de si hay existencias o no.
Si hay stock disponible y el cliente acepta las condiciones, se realiza la carga del pedido indicando la cantidad deseada, siendo este un paso repetitivo por cada artículo. Luego de despachar dicho producto, se procede al cobro en la misma pantalla, donde el vendedor selecciona el medio de pago (Efectivo, TDD, TDC o QR). Al procesarse la transacción, el sistema genera el comprobante definitivo de venta (Ticket/Factura) y descuenta automáticamente las unidades del inventario.
En cuanto a la gestión de abastecimiento, semanalmente se realiza un control de stock donde se analizan los productos con existencias mínimas o que deben reponerse. Con este listado de productos faltantes, se genera un pedido formal de compra a los proveedores. Semanalmente, el proveedor realiza la entrega de la mercadería solicitada. La misma es recibida y controlada. Una vez validada, se hace el pago al proveedor y se registra la factura correspondiente, finalmente se da de alta o actualiza el stock de los productos recibidos.

---

## 🎯 Objetivo

Desarrollar e implementar un sistema informático de gestión de inventario y ventas para la ferretería **"El Tornillo"** en un plazo de **4 meses**, que permita optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.

---
## 🚧 Límite

| | Punto |
|---|-------|
| **Desde** | El momento en que un cliente ingresa al local solicitando un producto o el vendedor inicia la consulta de datos en el mostrador. |
| **Hasta** | El registro definitivo de la factura del proveedor, el procesamiento de su correspondiente pago y la actualización del stock de mercadería recibida. |

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
