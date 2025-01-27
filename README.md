# MillionPrueba
Notas :
1. Configurar y reemplazar los valores de la cadena para la BD
"ConnectionStrings": {
  "DefaultConnection": "Server=;Database=PruebaMillion;TrustServerCertificate=True;Trusted_Connection=True;"
},
2. en la consola del adm de paquetes nuGet colocar
Add-Migration InitialCreate
Update-Database

Luego de seguir los pasos correr la app :


-- Autenticarse primero
{
  "username": "test",
  "password": "pass"
}

-- después de autenticarse poner el bearer token que arroja en Available authorizations
--una vez autenticado seguir

--Método principal    
{
     "name": "Casa de Campo",
     "address": "Calle Falsa 123",
     "price": 250000,
     "codeInternal": "CC123",
     "year": 2023,
     "idOwner": 3,
     "owner": {
       "name": "Juan Pérez",
       "address": "Avenida Siempre Viva 742",
       "photo": "juanperez.jpg",
       "birthday": "1985-04-12",
       "properties": []
     },
     "propertyImages": [
       {
         "file": "casa_campo_1.jpg",
         "enabled": true,
         "property": {
           "name": "Casa de Campo",
           "address": "Calle Falsa 123",
           "price": 250000,
           "codeInternal": "CC123",
           "year": 2023,
           "idOwner": 3,
           "owner": {
             "name": "Juan Pérez",
             "address": "Avenida Siempre Viva 742",
             "photo": "juanperez.jpg",
             "birthday": "1985-04-12",
             "properties": []
           },
           "propertyImages": [],
           "propertyTraces": []
         }
       }
     ],
     "propertyTraces": [
       {
         "dateSale": "2023-05-15T10:30:00.000Z",
         "name": "Venta Inicial",
         "value": 250000,
         "tax": 5000,
         "property": {
           "name": "Casa de Campo",
           "address": "Calle Falsa 123",
           "price": 250000,
           "codeInternal": "CC123",
           "year": 2023,
           "idOwner": 3,
           "owner": {
             "name": "Juan Pérez",
             "address": "Avenida Siempre Viva 742",
             "photo": "juanperez.jpg",
             "birthday": "1985-04-12",
             "properties": []
           },
           "propertyImages": [],
           "propertyTraces": []
         }
       }
     ]
   }
   

-- Add imagen

   {
     "idProperty": 4,
     "file": "casa_campo2.jpg",
     "enabled": true
   }
   
--Modificar property
   {
     "idProperty": 4,
     "name": "Casa de Campo Modif",
     "address": "Calle Falsa 123",
     "price": 260000,
     "codeInternal": "CC123",
     "year": 2023,
     "idOwner": 3,
     "owner": {
       "idOwner": 3,
       "name": "Juan Pérez",
       "address": "Avenida Siempre Viva 742",
       "photo": "juanperez.jpg",
       "birthday": "1985-04-12",
       "properties": []
     },
     "propertyImages": [],
     "propertyTraces": []
   }
   


