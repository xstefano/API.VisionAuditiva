<div align="center">

# VisionAuditiva Web API

![VisionAuditiva Logo](https://visionauditiva.azurewebsites.net/Image/logo)

</div>


Esta es una Web API desarrollada con .NET 7 que ofrece servicios de análisis de imágenes y chat utilizando [**Cognitive Services de Azure**](https://azure.microsoft.com/en-us/products/cognitive-services/). La API permite realizar operaciones como analizar imágenes, obtener descripciones de imágenes, leer texto de imágenes y mantener una conversación a través de un chat. Además, utiliza JWT (JSON Web Tokens) para autenticación y autorización de usuarios.

La documentación de la API se encuentra disponible en [https://visionauditiva.azurewebsites.net/swagger/index.html](https://visionauditiva.azurewebsites.net/swagger/index.html) utilizando Swagger.

## Requisitos previos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

## Configuración

Antes de ejecutar la API, asegúrate de configurar los siguientes servicios:

- [**Cognitive Services:**](https://azure.microsoft.com/en-us/products/cognitive-services/)
  - OpenAI de Cognitive Services de Azure.
  - Computer Vision de Cognitive Services de Azure.
  - Translator de Cognitive Services de Azure.

- [**AzureBlobStorage:**](https://azure.microsoft.com/en-us/products/storage/blobs/)
  - Configura el almacenamiento de blobs de Azure para almacenar las imágenes.

- [**JWT (JSON Web Tokens):**](https://jwt.io/)
  - Configura la autenticación y autorización JWT para los usuarios.

## Controladores

A continuación se detallan los controladores disponibles en la API:

### AuthenticateController

- `POST /api/authenticate/Login`: Permite a los usuarios iniciar sesión. Requiere un objeto `Login` con el nombre de usuario y la contraseña.

- `POST /api/authenticate/Register-Admin`: Permite a los administradores registrar nuevos usuarios. Requiere un objeto `Register` con la información de registro.

### CognitiveChatController

- `GET /api/cognitivechat/getResponse`: Permite a los administradores obtener una respuesta del servicio de chat cognitivo. Requiere un parámetro de consulta `request` que especifica la solicitud de chat.

### CognitiveVisionController

- `GET /api/cognitivevision/analyze`: Permite a los administradores analizar una imagen a través del servicio de visión cognitiva. Requiere un parámetro de consulta `imageUrl` que especifica la URL de la imagen.

- `GET /api/cognitivevision/describe`: Permite a los administradores obtener una descripción de una imagen a través del servicio de visión cognitiva. Requiere un parámetro de consulta `imageUrl` que especifica la URL de la imagen.

- `GET /api/cognitivevision/read`: Permite a los administradores leer el texto de una imagen a través del servicio de visión cognitiva. Requiere un parámetro de consulta `imageUrl` que especifica la URL de la imagen.

- `GET /api/cognitivevision/detectObjects`: Permite a los administradores detectar objetos en una imagen a través del servicio de visión cognitiva. Requiere un parámetro de consulta `imageUrl` que especifica la URL de la imagen.

### ImageController

- `POST /api/image`: Permite a los administradores guardar una imagen en el servicio AzureBlobStorage. Requiere un objeto `Image` con la imagen codificada en base64 y el nombre del archivo.

- `GET /api/image/GetImageBase64/{filename}`: Permite obtener la representación base64 de una imagen almacenada en AzureBlobStorage. Requiere el nombre del archivo como parámetro de ruta.

- `GET /api/image/{filename}`: Permite obtener una imagen almacenada en AzureBlobStorage. Requiere el nombre del archivo como parámetro de ruta.

## Contribución

Si deseas contribuir a este proyecto, sigue los siguientes pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu contribución: `git checkout -b nombre-de-la-rama`.
3. Realiza los cambios y las mejoras necesarias.
4. Realiza un commit de tus cambios: `git commit -m "Descripción de los cambios"`.
5. Envía tus cambios al repositorio remoto: `git push origin nombre-de-la-rama`.
6. Crea una Pull Request en GitHub describiendo tus cambios.

## Licencia

Este proyecto está bajo la Licencia GNU v3.0 - consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Si tienes alguna pregunta o comentario sobre el proyecto, no dudes en contactarme a través de N00245955@upn.pe.

---

© 2023 xstefano | [Link al repositorio](https://github.com/xstefano/API.VisionAuditiva)
