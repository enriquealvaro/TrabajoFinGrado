// Variable para almacenar los productos del carrito
var carrito = [];

// Función para agregar un producto al carrito
function agregarProducto(id, nombre, precio) {
    var producto = {
        id: id,
        nombre: nombre,
        precio: precio
    };
    carrito.push(producto);
}

// Función para eliminar un producto del carrito por su ID
function eliminarProducto(id) {
    carrito = carrito.filter(function (producto) {
        return producto.id !== id;
    });
}

// Función para obtener la lista de productos del carrito
function obtenerProductos() {
    return carrito;
}
