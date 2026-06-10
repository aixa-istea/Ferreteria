const API_BASE = 'http://localhost:5080/api';

async function apiFetch(endpoint, options = {}) {
  const url = `${API_BASE}${endpoint}`;
  const res = await fetch(url, {
    headers: { 'Content-Type': 'application/json', ...options.headers },
    ...options
  });
  if (!res.ok) {
    const err = await res.json().catch(() => ({ error: res.statusText }));
    throw new Error(err.error || res.statusText);
  }
  if (res.status === 204) return null;
  return res.json();
}

// Auth
const api = {
  login: dto => apiFetch('/auth/login', { method: 'POST', body: JSON.stringify(dto) }),

  // Productos
  getProductos: () => apiFetch('/productos'),
  getProducto: id => apiFetch(`/productos/${id}`),
  getBajoStock: () => apiFetch('/productos/bajo-stock'),
  createProducto: dto => apiFetch('/productos', { method: 'POST', body: JSON.stringify(dto) }),
  updateProducto: (id, dto) => apiFetch(`/productos/${id}`, { method: 'PUT', body: JSON.stringify(dto) }),
  deleteProducto: id => apiFetch(`/productos/${id}`, { method: 'DELETE' }),

  // Clientes
  getClientes: () => apiFetch('/clientes'),
  getClienteByDoc: doc => apiFetch(`/clientes/documento/${doc}`),
  createCliente: dto => apiFetch('/clientes', { method: 'POST', body: JSON.stringify(dto) }),
  updateCliente: (id, dto) => apiFetch(`/clientes/${id}`, { method: 'PUT', body: JSON.stringify(dto) }),
  deleteCliente: id => apiFetch(`/clientes/${id}`, { method: 'DELETE' }),

  // Proveedores
  getProveedores: () => apiFetch('/proveedores'),
  createProveedor: dto => apiFetch('/proveedores', { method: 'POST', body: JSON.stringify(dto) }),
  updateProveedor: (id, dto) => apiFetch(`/proveedores/${id}`, { method: 'PUT', body: JSON.stringify(dto) }),
  deleteProveedor: id => apiFetch(`/proveedores/${id}`, { method: 'DELETE' }),

  // Ventas
  getVentas: () => apiFetch('/ventas'),
  createVenta: dto => apiFetch('/ventas', { method: 'POST', body: JSON.stringify(dto) }),
  anularVenta: id => apiFetch(`/ventas/${id}/anular`, { method: 'PATCH' }),

  // Usuarios
  getUsuarios: () => apiFetch('/usuarios'),
  createUsuario: dto => apiFetch('/usuarios', { method: 'POST', body: JSON.stringify(dto) }),
  updateUsuario: (id, dto) => apiFetch(`/usuarios/${id}`, { method: 'PUT', body: JSON.stringify(dto) }),
  deleteUsuario: id => apiFetch(`/usuarios/${id}`, { method: 'DELETE' }),
};
