# \# DatosExcel

# 

# Sistema de análisis y conciliación de pólizas contables entre archivos Excel de CONTPAQi y base de datos de empleados.

# 

# \## 📋 Descripción

# 

# Aplicación de escritorio desarrollada en \*\*VB.NET\*\* que automatiza el proceso de importación, validación y conciliación de pólizas contables. El sistema compara datos extraídos de reportes auxiliares de \*\*CONTPAQi Contabilidad\*\* (en formato Excel) contra los registros almacenados en el sistema de empleados (MariaDB/MySQL).

# 

# \### 🎯 Problema que resuelve

# 

# Cuando se registran pólizas de nómina en dos sistemas diferentes (CONTPAQi y sistema de empleados), es necesario:

# \- ✅ Identificar pólizas nuevas que deben importarse

# \- ✅ Detectar pólizas que ya existen en ambos sistemas

# \- ✅ Encontrar inconsistencias entre los dos sistemas

# \- ✅ Localizar pólizas que fueron capturadas erróneamente

# 

# Este sistema realiza todo esto de forma \*\*automática y visual\*\*.

# 

# ---

# 

# \## 🚀 Características principales

# 

# \### 1. Importación desde Excel

# \- Lee archivos `.xlsx` y `.xls` generados por CONTPAQi

# \- Procesa reportes auxiliares de movimientos contables

# \- Extrae automáticamente el período de pólizas

# 

# \### 2. Análisis inteligente

# El sistema compara pólizas usando la llave: \*\*{Fecha, Número, TipoPoliza}\*\*

# 

# Y asigna uno de 4 estados:

# 

# | Estado | Color | Significado |

# |--------|-------|-------------|

# | \*\*CONTPAQi\*\* | 🔵 Azul | Póliza nueva, lista para importar |

# | \*\*CONCILIADA\*\* | 🟢 Verde | Existe en ambos sistemas, datos coinciden |

# | \*\*REVISAR\*\* | 🟡 Amarillo | Existe en ambos, pero con diferencias |

# | \*\*EMPLEADOS\*\* | 🔴 Rojo | Solo existe en sistema de empleados (posible error) |

# 

# \### 3. Procesamiento según estado

# 

# \*\*🔵 CONTPAQi\*\*: Importa todos los movimientos desagrupados a `tbl\_cargos`

# 

# \*\*🟢 CONCILIADA\*\*: Informa que la póliza ya está sincronizada

# 

# \*\*🟡 REVISAR\*\*: Muestra las diferencias detectadas:

# ```

# Póliza: MARKET, Número: 1, Fecha: 01/04/2025

# CONTPAQi:  Registros: 3, Cargos: 610.50, Abonos: 0.00

# EMPLEADOS: Registros: 4, Cargos: 610.50, Abonos: 0.00

# ```

# 

# \*\*🔴 EMPLEADOS\*\*: Alerta sobre póliza que debe revisarse/eliminarse

# 

# \### 4. Interfaz visual intuitiva

# \- Codificación por colores automática

# \- Suma de cargos y abonos en tiempo real

# \- Navegación entre registros

# \- Búsqueda y filtrado

# 

# ---

# 

# \## 💻 Requisitos del sistema

# 

# \### Software necesario

# \- \*\*Windows 7\*\* o superior

# \- \*\*.NET Framework 4.7.2\*\* o superior

# \- \*\*Microsoft Excel\*\* (para generar archivos fuente)

# \- \*\*MariaDB 10.6+\*\* o \*\*MySQL 8.0+\*\*

# 

# \### Dependencias del proyecto

# \- `Microsoft.Office.Interop.Excel` - Lectura de archivos Excel

# \- `MySql.Data` - Conexión a base de datos MariaDB/MySQL

# 

# ---

# 

# \## 📦 Instalación

# 

# \### 1. Clonar el repositorio

# ```bash

# git clone https://github.com/elkir34/DatosExcel.git

# cd DatosExcel

# ```

# 

# \### 2. Configurar base de datos

# 

# Crear la base de datos y tablas necesarias:

# 

# ```sql

# CREATE DATABASE buzosbyp\_erp;

# USE buzosbyp\_erp;

# 

# -- Tabla de cargos/movimientos

# CREATE TABLE tbl\_cargos (

# &nbsp;   idCargo INT AUTO\_INCREMENT PRIMARY KEY,

# &nbsp;   Fecha DATE NOT NULL,

# &nbsp;   Poliza INT NOT NULL,

# &nbsp;   idTipoPoliza INT NOT NULL,

# &nbsp;   Concepto VARCHAR(255),

# &nbsp;   Referencia VARCHAR(100),

# &nbsp;   Cargo DECIMAL(15,2) DEFAULT 0,

# &nbsp;   Abono DECIMAL(15,2) DEFAULT 0,

# &nbsp;   -- Agrega más campos según tu estructura

# &nbsp;   INDEX idx\_poliza (Fecha, Poliza, idTipoPoliza)

# );

# 

# -- Tabla catálogo de tipos de póliza

# CREATE TABLE ctg\_tipopoliza (

# &nbsp;   idTipoPoliza INT AUTO\_INCREMENT PRIMARY KEY,

# &nbsp;   TipoPoliza VARCHAR(50) NOT NULL

# );

# ```

# 

# \### 3. Configurar conexión

# 

# Edita la cadena de conexión en `FrmAnalizarNomina.vb` (línea 26):

# 

# ```vb

# Dim sqlConexion As New MySqlConnection("server=localhost; User Id=tu\_usuario; password=tu\_password; database=buzosbyp\_erp")

# ```

# 

# \### 4. Compilar proyecto

# 

# Abre `DatosExcel.sln` en \*\*Visual Studio\*\* y compila (F6).

# 

# ---

# 

# \## 🎯 Uso del sistema

# 

# \### Flujo de trabajo

# 

# ```

# ┌─────────────────┐

# │ FrmMenuInicio   │ ← Pantalla principal

# └────────┬────────┘

# &nbsp;        │ Clic en "Compaqi"

# &nbsp;        ▼

# ┌──────────────────────┐

# │ FrmImportarDatos     │ ← Importar archivo Excel

# ├──────────────────────┤

# │ 1. Abrir archivo     │

# │ 2. Cargar datos      │

# │ 3. Ver movimientos   │

# └────────┬─────────────┘

# &nbsp;        │ Clic en "Analizar"

# &nbsp;        ▼

# ┌────────────────────────┐

# │ FrmAnalizarNomina      │ ← Análisis y conciliación

# ├────────────────────────┤

# │ • Compara pólizas      │

# │ • Muestra estados      │

# │ • Procesa acciones     │

# └────────────────────────┘

# ```

# 

# \### Paso 1: Generar reporte en CONTPAQi

# 

# 1\. Abre \*\*CONTPAQi Contabilidad\*\*

# 2\. Ve a \*\*Reportes\*\* → \*\*Auxiliar de Movimientos\*\*

# 3\. Selecciona:

# &nbsp;  - \*\*Período\*\*: Fechas a analizar

# &nbsp;  - \*\*Cuentas\*\*: Rango de trabajadores (ej: 1101-001 a 1101-999)

# 4\. Exporta a \*\*Excel\*\* (.xlsx)

# 

# \### Paso 2: Importar en DatosExcel

# 

# 1\. Inicia la aplicación

# 2\. Clic en \*\*"Compaqi"\*\*

# 3\. Clic en \*\*"Abrir Archivo"\*\*

# 4\. Selecciona el Excel exportado

# 5\. Espera a que cargue (verás barra de progreso)

# 

# \### Paso 3: Analizar pólizas

# 

# 1\. Clic en \*\*"Analizar"\*\*

# 2\. El sistema mostrará las pólizas agrupadas con colores:

# &nbsp;  - 🔵 Azul = Nueva

# &nbsp;  - 🟢 Verde = Conciliada

# &nbsp;  - 🟡 Amarillo = Con diferencias

# &nbsp;  - 🔴 Rojo = Solo en empleados

# 

# \### Paso 4: Procesar

# 

# 1\. Selecciona una póliza

# 2\. Clic en \*\*"Procesar"\*\*

# 3\. Sigue las instrucciones según el estado

# 

# ---

# 

# \## 📁 Estructura del proyecto

# 

# ```

# DatosExcel/

# ├── DatosExcel/

# │   ├── FrmMenuInicio.vb              # Menú principal

# │   ├── FrmImportarDatos.vb           # Importación de Excel

# │   ├── FrmAnalizarNomina.vb          # Análisis y conciliación ⭐

# │   │

# │   ├── FrmAnalizar.vb                # (Ejemplo/práctica)

# │   ├── FrmConcilia.vb                # (Ejemplo/práctica)

# │   ├── FrmNomipaqDatos.vb            # (Ejemplo/práctica)

# │   ├── FrmNomiPaqAnaliza.vb          # (Ejemplo/práctica)

# │   │

# │   └── My Project/                   # Configuración del proyecto

# │

# ├── DatosExcel.sln                    # Solución de Visual Studio

# └── README.md                         # Este archivo

# ```

# 

# \### Archivos funcionales ✅

# 

# \- \*\*FrmMenuInicio\*\*: Punto de entrada de la aplicación

# \- \*\*FrmImportarDatos\*\*: Lee archivos Excel de CONTPAQi

# \- \*\*FrmAnalizarNomina\*\*: Motor principal de análisis

# 

# \### Archivos de práctica 📚

# 

# Los demás formularios fueron utilizados para aprender sobre:

# \- Uso de diccionarios en VB.NET

# \- Extracción de datos desde Excel

# \- Agrupación de datos

# \- Comparación de tablas

# 

# ---

# 

# \## 🔍 Formato del archivo Excel

# 

# El archivo de CONTPAQi debe contener las siguientes columnas:

# 

# | Columna | Descripción | Ejemplo |

# |---------|-------------|---------|

# | Cuenta | Cuenta contable | 1101-001 |

# | TipoTrabajador | Clasificación | Empleado |

# | Nombre | Nombre completo | Juan Pérez |

# | Fecha | Fecha de póliza | 01/04/2025 |

# | TipoPoliza | Tipo | MARKET |

# | Numero | Número de póliza | 1 |

# | Concepto | Descripción | Nómina quincenal |

# | Referencia | Referencia opcional | REF-001 |

# | Cargos | Importe cargo | 610.50 |

# | Abonos | Importe abono | 0.00 |

# 

# ---

# 

# \## 🛠️ Tecnologías utilizadas

# 

# | Tecnología | Versión | Uso |

# |------------|---------|-----|

# | Visual Basic .NET | 2019+ | Lenguaje principal |

# | .NET Framework | 4.7.2+ | Framework de desarrollo |

# | MariaDB | 10.6.24 | Base de datos |

# | MySQL Connector | 8.0+ | Driver de conexión BD |

# | Excel Interop | Office 2016+ | Lectura de archivos Excel |

# 

# ---

# 

# \## 🎨 Capturas de pantalla

# 

# \### Pantalla de importación

# ```

# \[Aquí irían capturas del formulario FrmImportarDatos]

# \- Vista del DataGrid con datos cargados

# \- Botones de navegación y análisis

# ```

# 

# \### Pantalla de análisis

# ```

# \[Aquí irían capturas del formulario FrmAnalizarNomina]

# \- Pólizas con código de colores

# \- Totales de cargos y abonos

# \- Estados de conciliación

# ```

# 

# ---

# 

# \## ⚙️ Configuración avanzada

# 

# \### Ajustar cadena de conexión

# 

# Para conexiones remotas (ej: servidor GoDaddy):

# 

# ```vb

# Dim sqlConexion As New MySqlConnection(

# &nbsp;   "server=tu-servidor.com;" \&

# &nbsp;   "port=3306;" \&

# &nbsp;   "User Id=usuario;" \&

# &nbsp;   "password=contraseña;" \&

# &nbsp;   "database=buzosbyp\_erp;" \&

# &nbsp;   "SslMode=Required"

# )

# ```

# 

# \### Optimización de rendimiento

# 

# Para archivos Excel grandes (>5000 registros):

# 

# ```vb

# ' En FrmImportarDatos.vb

# BackgroundWorker1.WorkerReportsProgress = True

# ' Esto evita que la UI se congele durante la carga

# ```

# 

# ---

# 

# \## 🐛 Solución de problemas

# 

# \### Error: "No se puede abrir el archivo Excel"

# \*\*Causa\*\*: Excel no instalado o archivo abierto en otro programa  

# \*\*Solución\*\*: 

# \- Cierra el archivo Excel

# \- Verifica que Microsoft Excel esté instalado

# \- Ejecuta la aplicación como administrador

# 

# \### Error: "No se puede conectar a la base de datos"

# \*\*Causa\*\*: Credenciales incorrectas o servidor no accesible  

# \*\*Solución\*\*:

# \- Verifica que MariaDB esté ejecutándose

# \- Comprueba usuario, contraseña y nombre de BD

# \- Prueba la conexión con HeidiSQL o MySQL Workbench

# 

# \### Pólizas marcadas como "REVISAR" cuando deberían estar conciliadas

# \*\*Causa\*\*: Diferencias de redondeo en decimales  

# \*\*Solución\*\*: El sistema usa tolerancia de 0.01 (línea 159-160):

# ```vb

# Dim cargosIguales As Boolean = Math.Abs(CDbl(row("SumaCargos")) - CDbl(rowSistema("SumaCargos"))) < 0.01

# ```

# 

# \### Las pólizas aparecen duplicadas

# \*\*Causa\*\*: Mismo número de póliza con diferente tipo  

# \*\*Solución\*\*: Verifica que el \*\*TipoPoliza\*\* sea parte de la llave única

# 

# ---

# 

# \## 🔄 Próximas mejoras

# 

# \- \[ ] Implementar importación real a `tbl\_cargos` (actualmente solo muestra mensaje)

# \- \[ ] Crear formulario `FrmRevisarPoliza` para ver detalles de diferencias

# \- \[ ] Renombrar `FrmAnalizarNomina` → `FrmAnalizarContabilidad`

# \- \[ ] Agregar exportación de resultados a Excel

# \- \[ ] Implementar log de auditoría de importaciones

# \- \[ ] Versión web con ASP.NET Core / Blazor

# \- \[ ] API REST para integración con otros sistemas

# 

# ---

# 

# \## 📝 Notas de versión

# 

# \### v1.0 - Versión actual

# \- ✅ Importación de archivos Excel de CONTPAQi

# \- ✅ Análisis y comparación de pólizas

# \- ✅ Detección automática de estados (4 tipos)

# \- ✅ Codificación visual por colores

# \- ✅ Comparación con sistema de empleados

# \- ⏳ Importación a BD (pendiente de implementar)

# \- ⏳ Formulario de revisión detallada (pendiente)

# 

# ---

# 

# \## 📄 Licencia

# 

# Este proyecto es de uso interno. Todos los derechos reservados.

# 

# ---

# 

# \## 👤 Autor

# 

# \*\*elkir34\*\*

# \- GitHub: \[@elkir34](https://github.com/elkir34)

# \- Proyecto: \[DatosExcel](https://github.com/elkir34/DatosExcel)

# 

# ---

# 

# \## 🤝 Contribuciones

# 

# Actualmente este es un proyecto personal. Si deseas colaborar:

# 

# 1\. Haz fork del proyecto

# 2\. Crea una rama (`git checkout -b feature/mejora`)

# 3\. Commit tus cambios (`git commit -am 'Agrega nueva funcionalidad'`)

# 4\. Push a la rama (`git push origin feature/mejora`)

# 5\. Abre un Pull Request

# 

# ---

# 

# \## 💡 Recursos adicionales

# 

# \### Documentación oficial

# \- \[CONTPAQi Contabilidad](https://www.contpaqi.com/)

# \- \[MariaDB Documentation](https://mariadb.com/kb/en/)

# \- \[VB.NET Language Reference](https://docs.microsoft.com/en-us/dotnet/visual-basic/)

# 

# \### Herramientas recomendadas

# \- \*\*HeidiSQL\*\*: Cliente SQL para MariaDB/MySQL

# \- \*\*Visual Studio 2022\*\*: IDE para desarrollo VB.NET

# \- \*\*Git\*\*: Control de versiones

# 

# ---

# 

# \*\*Desarrollado con ❤️ para automatizar procesos contables y evitar errores de captura manual\*\*

