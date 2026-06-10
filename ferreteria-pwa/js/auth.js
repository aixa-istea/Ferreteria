// ── Roles ─────────────────────────────────────────────────────
const ROLES = {
  ADMIN:    'admin',
  VENDEDOR: 'vendedor',
  CAJERO:   'cajero'
};

// Páginas permitidas por rol
const PERMISOS = {
  'productos.html':   [ROLES.ADMIN, ROLES.VENDEDOR],
  'clientes.html':    [ROLES.ADMIN, ROLES.VENDEDOR],
  'ventas.html':      [ROLES.ADMIN, ROLES.VENDEDOR, ROLES.CAJERO],
  'proveedores.html': [ROLES.ADMIN],
  'usuarios.html':    [ROLES.ADMIN],
  'bajo-stock.html':  [ROLES.ADMIN, ROLES.VENDEDOR, ROLES.CAJERO],
};

// En productos, el cajero no puede hacer ABM
const SOLO_CONSULTA = [ROLES.CAJERO];

function getUsuario() {
  const u = sessionStorage.getItem('usuario');
  return u ? JSON.parse(u) : null;
}

function setUsuario(usuario) {
  sessionStorage.setItem('usuario', JSON.stringify(usuario));
}

function logout() {
  sessionStorage.removeItem('usuario');
  window.location.href = '/pages/login.html';
}

function requireAuth() {
  const usuario = getUsuario();
  if (!usuario) {
    window.location.href = '/pages/login.html';
    return;
  }

  // Verificar permiso para esta página
  const pagina = window.location.pathname.split('/').pop();
  const permitidos = PERMISOS[pagina];
  if (permitidos && !permitidos.includes(usuario.rol)) {
    window.location.href = getRedireccionPorRol(usuario.rol);
    return;
  }

  // Ocultar links del sidebar según rol
  aplicarSidebar(usuario.rol);
}

function getRedireccionPorRol(rol) {
  if (rol === ROLES.CAJERO) return '/pages/ventas.html';
  if (rol === ROLES.VENDEDOR) return '/pages/productos.html';
  return '/pages/productos.html';
}

function aplicarSidebar(rol) {
  // Ocultar links no permitidos en el sidebar
  document.querySelectorAll('.sidebar nav a').forEach(a => {
    const pagina = a.href.split('/').pop();
    const permitidos = PERMISOS[pagina];
    if (permitidos && !permitidos.includes(rol)) {
      a.style.display = 'none';
    }
  });
}

function esAdmin() {
  return getUsuario()?.rol === ROLES.ADMIN;
}

function esVendedor() {
  return getUsuario()?.rol === ROLES.VENDEDOR;
}

function esCajero() {
  return getUsuario()?.rol === ROLES.CAJERO;
}

// Oculta botones de ABM si el rol no tiene permiso
function aplicarPermisosABM(rolesPermitidos = [ROLES.ADMIN]) {
  const usuario = getUsuario();
  if (!rolesPermitidos.includes(usuario?.rol)) {
    document.querySelectorAll('.btn-abm').forEach(btn => btn.style.display = 'none');
  }
}
