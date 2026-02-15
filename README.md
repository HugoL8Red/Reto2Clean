# Reto2

Descripción general de la arquitectura.

Se crearón 4 capas para separar las responsabilidades en diferentes proyectos
Se utilizo database in memory para guardar registros en memoria
Se utilizaron los patrones de repositorio y dependency inyection

o  Explicación de las capas.
API 
    Contiene los controles y los metodos expuestos, los metodos CRUD
    
Application
    Contiene los diferentes servicios a utilizar para la conexion entre infraestructura y api
    
Domain
    Contiene las entidades para usar dentro de toda la aplicacion y crear las tabals en base de datos
    
Infrastructure
    Contiene la conexión a base de datos y el patron de repositorio, la base de datos se crea mediante el DB context

o  Patrones utilizados y justificación.
Repository
  Se usa para realizar la logica de obtener e insertar información a la base de datos
  
Dependency Inyection
  Se utiliza para reducir la dependencia entre las capas, clases y objetos

o  Decisiones arquitectónicas relevantes.
Database in memory para probar la api
Se utilizo .net core para microsericios
