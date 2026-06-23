# 📘 **Diccionario de Datos (DD)**

---

> Este documento fue usado como referencia para el diseño de la base de datos. Describe las estructuras de almacenamiento utilizadas en el sistema de gestión de la ferretería El Tornillo. La especificación se encuentra documentada utilizando la notación Yourdon, definiendo las entidades del sistema, sus atributos, claves primarias, claves foráneas y dominios de valores permitidos cuando corresponda.

---

* **clientes** = { @id_cliente, nombre, apellido, dirección, telefono, email, tipo_documento [dni | cuit], numero_documento }


* **productos** = { @id_producto, id_marca(fk), descripción, precio_costo, precio_venta, stock_actual, stock_minimo, estado [activo | discontinuado | eliminado] }


* **marcas** = { @id_marca, nombre }


* **categorias_producto** = { @id_categoria, nombre }


* **productos_x_categoria** = { @id_producto, @id_categoria }


* **proveedores** = { @id_proveedor, razón_social, cuit, dirección, teléfono, email }


* **productos_x_proveedor** = { @id_producto, @id_proveedor }


* **venta** = { @id_venta, fecha, total_venta, id_medio_de_pago(fk), estado_venta [confirmada | anulada], id_usuario(fk), id_cliente (fk) }


* **detalle_venta** = { @id_venta(fk), @id_producto(fk), cantidad, precio_venta }


* **medio_pago** = { @id_medio_de_pago, nombre [efectivo | tarjeta_debito, tarjeta_credito | qr] }


* **pedido_proveedor** = { @id_pedido, fecha, id_proveedor(fk), estado [pendiente | recibido], id_usuario(fk) }


* **detalle_pedido_proveedor** = { @id_pedido(fk), @id_producto(fk), cantidad, precio_costo, subtotal }


* **factura_proveedor** = { @id_factura, numero_factura, fecha, id_proveedor(fk), total, estado_factura [pendiente | pagada] }


* **recepcion_pedido** = { @id_recepcion, fecha, id_pedido_proveedor(fk), id_factura_proveedor(fk), id_usuario(fk) }


* **recepcion_detalle** = { @id_recepcion(fk), @id_producto(fk), cantidad_recibida }


* **pago_proveedor** = { @id_pago, fecha, id_factura_proveedor(fk), total, id_medio_pago(fk), id_usuario(fk) }


* **usuarios** = { @id_usuario, nombre, apellido, telefono, email, usuario_login, password_hash, id_rol(fk) }


* **roles** = { @id_rol, nombre [admin | vendedor | cajero] }
