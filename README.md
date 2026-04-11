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

trade-off
Se utilizaron las siguientes fuentes de investigación como ejemplo y se utilizaron los patrones de repository e inyeccion de dependencias para el desarrollo de esta api sencilla. Tambien se uso una base de datos en momeria para poder probar el codigo sin un motor de base de datos

Fuentes de investigación
https://medium.com/@danceforrasputin/-411a365022f4
https://medium.com/@martintrujillo/crear-una-api-en-net-core-con-clean-architecture-cqrs-y-dapper-desde-cero-011bdddb337c

# Reto 3
Se creo otro servicio llamado pagos para relaizar la comuniocacion entre 2 contenedores.
Se crearón dos docker files, uno por cada servicio (ordenes y pagos).

Por cada servicio se creo un archivo de development y service
El archivo docker-compose tiene las dos implementaciones de las imagenes de los dos servicios.
Se crearon 3 pods por cada imagen.

Se agrego un nuevo repositorio en la api de ordenes (PagoRepository) para realizar la llamada a la api de pagos
Se llama a la clase HttpClient para poder realizar el llamado, el metodo creado en el nuevo repositorio se creo de forma asincrona para poder realizar la llamada

Se utilizan la creación de imagenes y contenedores para tener copias disponibles de la misma aplicacion y tener mas atención a la demanda de los servicios
Los pods sirven para atender mas peticiones al mismo tiempo y no hacer esperar a los cliente que invocan los end points

El archivo dockerfile se utiliza para crear una imagen del codigo compilado, compilando el codigo, copiando los archivos de los diferentes proyectos, restaurando el proyecto principal y generando la dll del proyecto. 

# Reto4
Se crearon dos nuevos servicios, apigateway y worker service.
Gateway es la puerta de enlace para conectarse alos servicios de ordener y worker. Se utilizo la libreria de Yarp revers proxy para poder lograr el gateway.
Se agrego una funcionalidad al servicio de ordenes, mandar una peticion a RabbitMq para crear un mensaje, se utilizo la libreria de RabbitMq para .net.
El servicio worker obtiene los mensaje que se crearon en Rabbitmq y los lee.

Se creo una imagen de Rabbitmq en docker para poder tener acceso a rabbitq de manera local y poder probar el funcionamiento de la aplicación.
Se agregaron los servicios de api gateway, worker y rabbitMq en el archivo de docker-compose.

Para poder acceder a rabbitmq de manera local se utiliza la siguiente url http://localhost:15672/ con el usuario y password guest.


