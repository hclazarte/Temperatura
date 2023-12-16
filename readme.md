# Back End de Proyecto de COMPUTER STRUCTURES (CSE611)

# Arquitectura

![Arquitectura](/medios/arquitectura.png "Arquitectura")

* **Base de Datos.-** Como RDBMS podemos utilizar ORACLE

* **Entidades de Negocio.-** Se prevé el mapeo a objetos ORM, estas se constituyen en
las únicas entidades comunes a todas las capas. Solo contienen datos y son
mapeadas a entidades proxy en la capa de presentación.

* **Acceso a Datos.-** Esta capa se encarga de la persistencia de la información, traduce
los cambios en las entidades de negocios a comandos de manipulación de las
bases de datos y/o archivos y/o almacenamiento web.

* **Capa de negocio.-** Aquí se programa las reglas de negocio en general, por ejemplo
el nivel de acceso a las funciones según usuarios y perfiles. Aquí se codifican los
mecanismos de interacción entre los usuarios, niveles y sistema.

* **Servicios.-** También llamada capa de transporte transforma los objetos y métodos
en funciones web visibles y utilizables en Internet.
