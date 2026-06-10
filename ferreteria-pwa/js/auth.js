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
  if (!getUsuario()) {
    window.location.href = '/pages/login.html';
  }
}
