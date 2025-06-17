# 📘 Aplicaciones Web Servidor – Parcial 2

### 🧑‍💻 Autor
**Alejandro Novelli** – Legajo 80040

---

### 📝 Descripción general

Este repositorio contiene el desarrollo completo del **parcial 2** de la materia *Aplicaciones Web Servidor*.  
Se implementó una **Web API** en .NET 8 con arquitectura en capas, integrando:

- Repositorio de usuarios (`IUserRepository`) y su implementación.
- Controlador `UserController` con endpoints funcionales para operaciones CRUD.
- Modelo de entidad `User` y vista simplificada `UserViewModel`.

---

### 📂 Estructura del proyecto

- `Controllers/`: contiene los controladores de la API.
- `EF/`: modelo de datos principal (`User`).
- `Interfaces/`: contratos del repositorio.
- `Repositories/`: implementación concreta del repositorio.
- `Models/`: contiene `UserViewModel`.
- `WebAppClase08.Tests/`: proyecto de tests unitarios con `xUnit` y `Moq`.

---

### ✅ Funcionalidades implementadas

- `GET /User/GetAllUsers`
- `GET /User/GetUserById/{id}`
- `POST /User/AddUser`
- `PUT /User/UpdateUser/{id}`
- `DELETE /User/DeleteUser/{id}`

---

### 🧪 Tests incluidos (xUnit + Moq)

Se incluyeron **9 pruebas unitarias** para garantizar el correcto funcionamiento de los endpoints:

- ✅ `UpdateUser` retorna `Ok` o `NotFound` según el caso.
- ✅ `AddUser` retorna `BadRequest` si el usuario es `null`.
- ✅ `GetAllUsers` retorna `Ok` con una lista vacía o poblada.
- ✅ `GetUserById` y `DeleteUser` cubren escenarios de éxito y error.

---

### 💡 Notas importantes

- Se respetó la arquitectura por capas.
- Se utilizó inyección de dependencias en el controlador.
- Se simuló el comportamiento del repositorio real con Moq.
- Se validaron los métodos `async` con `.Result` para simplificar los asserts.
- ✅ Todos los endpoints fueron verificados manualmente usando **Swagger**.

---

### 🔄 Cómo ejecutar

1. Clonar el proyecto
2. Ejecutar la solución en **Visual Studio**
3. Abrir Swagger en `https://localhost:{puerto}/swagger/index.html`
4. Verificar los tests en el Explorador de pruebas

