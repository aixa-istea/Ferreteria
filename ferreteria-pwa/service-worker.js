const CACHE_NAME = 'ferreteria-v1';
const ASSETS = [
  '/',
  '/index.html',
  '/css/styles.css',
  '/js/api.js',
  '/js/auth.js',
  '/pages/login.html',
  '/pages/productos.html',
  '/pages/clientes.html',
  '/pages/ventas.html',
  '/pages/proveedores.html',
  '/pages/usuarios.html',
  '/pages/bajo-stock.html'
];

self.addEventListener('install', e => {
  e.waitUntil(
    caches.open(CACHE_NAME).then(cache => cache.addAll(ASSETS))
  );
});

self.addEventListener('fetch', e => {
  e.respondWith(
    caches.match(e.request).then(cached => cached || fetch(e.request))
  );
});
