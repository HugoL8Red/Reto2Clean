# Reto2

Descripción general de la arquitectura.

Se crearón 4 capas para separar las responsabilidades en diferentes proyectos
Se utilizo database in memory para guardar registros en memoria y poder porbar la aplicacion
Se utilizaron los patrones de repositorio y dependency inyection

o  Explicación de las capas.
API 
    Contiene los controles y los metodos expuestos, los metodos de crear orden, obtener por Id y obtener todas las ordenes. Se utiliza el modelo de la capa domain
    
Application
    Contiene los diferentes servicios a utilizar para la conexion entre infraestructura y api. Se utiliza el modelo de la capa domain
    
Domain
    Contiene las entidades para usar dentro de toda la aplicacion y crear las tabals en base de datos
    
Infrastructure
    Contiene la conexión a base de datos y el patron de repositorio, la base de datos se crea mediante el DB context. Se utiliza el modelo de la capa domain

o  Patrones utilizados y justificación.
Repository
  Se usa para realizar la logica de obtener e insertar información a la base de datos
  
Dependency Inyection
  Se utiliza para reducir la dependencia entre las capas, clases y objetos

o  Decisiones arquitectónicas relevantes.
Database in memory para probar la api
Se utilizo .net core para microsericios
Se crearon los metodos de crear orden, obtener por id y obtener todas las ordenes
No se incluyeron en la api los metodos de delete y update, tampoco se agregaron validaciones de ordenes duplicadas en este momento, se haran en la siguiente implementacion.

Fuentes de investigación
https://medium.com/@danceforrasputin/-411a365022f4
https://medium.com/@martintrujillo/crear-una-api-en-net-core-con-clean-architecture-cqrs-y-dapper-desde-cero-011bdddb337c
