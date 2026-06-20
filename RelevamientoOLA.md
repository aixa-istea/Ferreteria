Relevamiento General:
La ferretería "El Tornillo", la cual es atendida por sus dos dueños y un hijo como empleado/vendedor, presenta el siguiente funcionamiento y necesidades:
Cuando el cliente ingresa al local, selecciona o solicita uno o más productos en el mostrador. En ese momento, el vendedor inicia la toma de datos para registrarlo o buscarlo en el sistema. Acto seguido, se verifica la existencia de stock; el sistema debe mostrar de forma simultánea el precio de venta y la disponibilidad. Si el cliente lo desea, se le informa el precio independientemente de si hay existencias o no.
Si hay stock disponible y el cliente acepta las condiciones, se realiza la carga del pedido indicando la cantidad deseada, siendo este un paso repetitivo por cada artículo. Luego de despachar dicho producto, se procede al cobro en la misma pantalla, donde el vendedor selecciona el medio de pago (Efectivo, TDD, TDC o QR). Al procesarse la transacción, el sistema genera el comprobante definitivo de venta (Ticket/Factura) y descuenta automáticamente las unidades del inventario.
En cuanto a la gestión de abastecimiento, semanalmente se realiza un control de stock donde se analizan los productos con existencias mínimas o que deben reponerse. Con este listado de productos faltantes, se genera un pedido formal de compra a los proveedores. Semanalmente, el proveedor realiza la entrega de la mercadería solicitada. La misma es recibida y controlada. Una vez validada, se hace el pago al proveedor y se registra la factura correspondiente, finalmente se da de alta o actualiza el stock de los productos recibidos.
Análisis de Tareas Operativas: 
Atendido por sus 2 Dueños + 1 Hijo como empleado/vendedor 
El cliente ingresa y selecciona o solicita un producto. 
Toma de Datos: Se solicitan los datos del cliente para registrarlos o buscarlos en la Tabla de Clientes. 
Verificación de Stock y Precio: El vendedor consulta el producto en el sistema. El sistema muestra el precio de venta y la disponibilidad de stock de forma simultánea. Si el cliente lo desea, se le informa el precio independientemente de si hay existencias o no.
Carga del Pedido y Cobro: Si hay stock y el cliente acepta, se indica la cantidad deseada (paso repetitivo por cada producto). Al finalizar la carga, el mismo vendedor selecciona el medio de pago en la pantalla (Efectivo, TDD, TDC o QR).
Registro y Comprobante: El sistema procesa el pago, genera el comprobante definitivo de venta (Ticket/Factura) y descuenta automáticamente las unidades del inventario.
Control de stock: Se analizan los productos que se quedaron sin stock para determinar qué se necesita pedir. 
Pedido de compra: Semanalmente se realiza el pedido formal de los productos faltantes a los Proveedores. Pago a proveedores 1 vez a la semana. 
Recepción: Los proveedores se presentan a cobrar y entregan su Factura. 
Control y Registro: Se recibe la mercadería (si corresponde), se registra la factura en el sistema y se procesa el pago al proveedor.
Objetivo General
Desarrollar e implementar un sistema informático de gestión de inventario y ventas para la ferretería "El Tornillo" en un plazo de 4 meses, que permita optimizar el control de stock y centralizar el proceso de venta directa y cobro en el mostrador.
Objetivos Específicos 
1. Ventas y Clientes
Automatizar el registro y la búsqueda de datos de clientes en el mostrador para reducir el tiempo de atención a menos de 2 minutos por cliente.
Sistematizar la consulta unificada de precios y existencias para agilizar la respuesta al cliente en el mostrador.
2. Caja y Pagos

Integrar en la interfaz de venta las múltiples formas de pago (Efectivo, TDD, TDC y QR) para centralizar la recaudación diaria en un solo paso operativo.

3. Stock y Alertas 

Implementar un módulo de verificación de stock en tiempo real que descuente las unidades del inventario automáticamente al confirmarse la venta.

Generar reportes automáticos de productos sin stock o por debajo del stock mínimo para facilitar la toma de decisiones antes del pedido semanal.

4.Compras y Proveedores

Registrar y asociar las facturas de los proveedores con la mercadería recibida para mantener actualizado el costo de los productos y el historial de pagos de la ferretería.

Límite:

Desde: El momento en que un cliente ingresa al local solicitando un producto o el vendedor inicia la consulta de datos en el mostrador.

Hasta: El registro definitivo de la factura del proveedor, el procesamiento de su correspondiente pago y la actualización del stock de mercadería recibida.

Alcance: 

Módulo de Clientes:

ABM de Clientes: Alta de nuevos clientes, baja (o inactivación) y modificación de datos personales (DNI/CUIT, Teléfono, etc.).
Consulta y búsqueda rápida de clientes por DNI/CUIT en el mostrador.

Módulo de Productos e Inventario:

ABM de Productos: Alta de nuevos artículos ferreteros, baja y modificación de descripciones, precios de costo, precios de venta y parametrización de StockMinimo.
Consulta Unificada: Pantalla de búsqueda que muestra el precio de venta y el stock disponible actual de manera inmediata.
Monitoreo automático de existencias con alertas visuales de productos por debajo del stock mínimo.

Módulo de Proveedores y Compras:

ABM de Proveedores: Alta, baja y modificación de las empresas proveedoras (Razón Social, CUIT, contacto).
Registro de Pedidos de Compra: Generación semanal de la orden de pedido basada en el reporte de alertas de stock.
Registro de Recepción de Mercadería: Ingreso de stock físico al sistema para sumar existencias de forma automática.
Registro de Facturas de Proveedores y Procesamiento de Pago.

Módulo de Gestión de Ventas y Facturación:

Carga de Pedido Directo: Selección de productos, validación visual de stock y carga de cantidades en una sola interfaz de mostrador.
Procesamiento de Pago y Cierre: Selección del medio de pago (Efectivo, TDD, TDC, QR) y emisión del ticket final de venta en el mismo momento.
Descuento Automatizado de Stock: Impacto inmediato en las tablas de ventas e inventario al confirmar la transacción, sin estados intermedios (sin remito pendiente).

