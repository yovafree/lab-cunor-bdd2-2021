# Analisis de la Base de  datos : Northwind

## Instalación
 - Usar el siguiente contenedor:

   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Str0ngP@ssw0rd"   -p 5480:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2019-latest

 - En Microsoft  sql Managemet Studio iniciar sesión como administrador 
 - En bases de datos dar  click derecho y Restaurar base de datos [Northwind](https://github.com/FaiberAbril/NorthWind/blob/master/Northwind.bak "Northwind") 
 - El modelo de la base de datos 
 
![](https://github.com/FaiberAbril/NorthWind/blob/master/Modelo-Relacional-Northwind.png "Modelo")

## Modelado dimensional
- Creación de base de datos data werehouse Northwind 
- Modelo dimensional 
![](https://github.com/FaiberAbril/NorthWind/blob/master/Modelo-Dimensional-Northwind.png)

- En bases de datos dar  click derecho y Restaurar base de datos [Data WareHouse Northwind](https://github.com/FaiberAbril/NorthWind/blob/master/dh_northwind "Data Were House Northwind")(datos ya poblados)


##  ETL
- Se creo visual studio 2019 tener instalado la extensión de sql server integration services
- Descargar proyecto [ProyectoEtl](https://github.com/FaiberAbril/NorthWind/tree/master/Etl_Nortwind "ProyectoEtl") y Ejecutar.
- Configurar conexion del proyecto 
- Ejecutar para poblar la base de datos del data were house.


##  Crear cubo multidimensional
- En Microsoft  sql Managemet Studio iniciar sesión como administrador en el modulo Analysis Services 
- Descargar proyecto [Dimensionalidades](https://github.com/FaiberAbril/NorthWind/tree/master/NorthWindAnalisis "Dimensionalidades") y Ejecutar
-Configurar la conexion al servidor de Analysis Services
- Procesar para Crear el cubo OLAP

##  Analisis de Cubo OLAP POWER BI Y EXCEL 2016 
