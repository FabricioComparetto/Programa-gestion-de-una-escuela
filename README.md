# Sistema de Gestión Escolar - Windows Forms C#

Sistema completo de gestión para escuelas desarrollado en **C# con Windows Forms** y base de datos **SQL Server**.

Proyecto realizado por **Fabricio Comparetto** y **Santiago Said**.

## Descripción

Aplicación de escritorio diseñada para la administración de una institución educativa. Permite gestionar alumnos, asignaturas, tipos de exámenes, ciudades, y especialmente el registro y consulta de notas de los estudiantes.

## Características Principales

### Gestión de Alumnos
- Alta, baja y modificación de alumnos
- Registro de datos personales (Matrícula, Nombre, Apellido, DNI, Código Postal, Fecha de Nacimiento)
- Búsqueda de alumnos

### Gestión de Notas
- Registro de notas por alumno y asignatura
- Soporte para **múltiples notas** por alumno en una misma asignatura
- Cálculo automático de:
  - **Nota Promedio**
  - **Nota Mínima**
  - **Nota Máxima**
- Listado general de notas
- Consulta individual de notas por alumno

### Módulos de Configuración
- **Ciudades** (Código Postal y Nombre)
- **Asignaturas** (Materias)
- **Tipos de Examen**

### Interfaz
- Menú principal con pestañas (Archivo, Alumnos, Notas, Configuración)
- Diseño sencillo y funcional
- Búsqueda y filtros en la mayoría de los formularios

## Tecnologías Utilizadas

- **Lenguaje**: C#
- **Framework**: Windows Forms (.NET Framework)
- **Base de Datos**: SQL Server
- **Acceso a datos**: ADO.NET (SqlConnection, SqlCommand, etc.)

## Estructura del Proyecto

El sistema cuenta con los siguientes formularios principales:

- **Formulario Principal** (`SistemaEscuela`)
- **Gestión de Alumnos**
- **Gestión de Notas**
- **Listado de Notas**
- **Notas de Alumno** (con cálculo de promedio, nota mínima y máxima)
- **Gestión de Asignaturas**
- **Gestión de Ciudades**
- **Gestión de Tipos de Examen**
- **Listado de Alumnos**

## Requisitos

- Windows 10 o superior
- Visual Studio 2022 (recomendado) o Visual Studio 2019
- .NET Framework 4.5 o superior
- SQL Server (LocalDB o SQL Server Express recomendado)
- Base de datos restaurada o scripts de creación de tablas

## Cómo Ejecutar el Proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/FabricioComparetto/Sistema-Gestion-Escolar.git
