# 🎫 Ticket Manager (C#)

Sistema básico de gestión de tickets implementado en **C#**, utilizando conceptos fundamentales de **Programación Orientada a Objetos**, manejo de **listas**, **colas**, **pilas**, lectura/escritura de **archivos** y principios de arquitectura limpia en consola.

Este proyecto forma parte de mi ruta de práctica profesional para fortalecer **estructura**, **lógica**, **organización** y **buenas prácticas** en C#.

---

## 🚀 Funcionalidades principales

### 📌 1. Gestión de Tickets
Permite crear y administrar tickets con información como:

- **Id**
- **Cliente**
- **Descripción**
- **Fecha**
- **Estado** (Pendiente / Completado)

Cada ticket almacena un **historial de acciones**, permitiendo rastrear cambios relevantes.

---

### 📌 2. Estructuras de Datos Utilizadas

El sistema simula un gestor de soporte real usando estructuras clásicas:

- 🔹 **Queue\<Ticket>** → Manejo de tickets pendientes (FIFO)  
- 🔹 **List\<Ticket>** → Almacén de tickets completados  
- 🔹 **Stack\<Accion>** → Registro de acciones para permitir *undo*

Esto permite representar:

- Orden de atención  
- Historial de trabajo  
- Reversión de operaciones recientes  

---

### 📌 3. Registro de Acciones

Cada acción incluye:

- Descripción  
- Fecha automática  
- Tipo (opcional)

Ejemplos comunes:

- `"Ticket creado"`
- `"Ticket completado"`
- `"Undo realizado"`

Esto permite auditoría básica dentro del sistema.

---

### 📌 4. Módulo Gestor (GestorTickets)

La clase principal `GestorTickets` se encarga de:

- Agregar tickets a la cola  
- Completar tickets  
- Registrar acciones  
- Deshacer operaciones (Stack)  
- Mostrar estado general  
- **Exportar tickets completados** a un archivo `.txt`  

---

## 🧩 Estructura del Proyecto

ticket-manager-csharp/
├── Accion.cs
├── EstadoTicket.cs
├── GestorTickets.cs
├── IExportable.cs
├── Ticket.cs
├── Program.cs
└── archivos.csproj


---

## 🛠 Tecnologías utilizadas

- **C#**
- **.NET 7/8**
- Programación Orientada a Objetos
- Estructuras de datos (List, Queue, Stack)
- Manejo de archivos `.txt`
- Patrones básicos de arquitectura

---

## ▶️ Cómo ejecutar

1. **Clonar el repositorio:**

```bash
git clone https://github.com/guillermolopez-git/ticket-manager-csharp.git

Entrar al proyecto:

cd ticket-manager-csharp


Compilar y ejecutar:

dotnet run
