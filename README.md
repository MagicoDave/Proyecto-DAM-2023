# Proyecto DAM 2023 - Videojuego Tower Defense 3D en Unity

Repositorio del proyecto final para el ciclo superior de DAM. El proyecto consistirá en la elaboración de un videojuego sencillo del género Tower Defense en Unity, en 3D. La plataforma de destino será para escritorio de Windows.

## Changelog

* Anterior al 16/04: Recopilación de información, placeholders de assets y formación en Unity (ver el apartado inferior de los cursos de unity para más información).
* 16/04: Establecida la estructura fundamental mínima la pantalla principal del juego: Un nivel realizado con objetos primitivos de Unity, con un camino con un punto de spawn y un final. Se ysan placeholders como assets por el momento.
* 17/04: Lógica básica de los enemigos para recorrer el camino usando pathways y scripts.
* 22/04: Lógica fundamental para generar oleadas de enemigos, cada una más numerosa que la anterior. Se crean elementos provisionales de UI para ver la cuenta atrás hasta el comienzo de la nueva oleada.
* 23/04: Script con lógica de elección de objetivo para torretas según proximidad y rango. Si tengo tiempo, me gustaría que cada torreta tuviese su propio criterio.
* 24/04: Se asignan estadísticas provisionales de test para enemigos y torretas y se hacen pruebas de funcionalidad de disparo para las torretas. La animación no funciona correctamente aún.
* 28/04: Arreglada la animación de disparo. Las torretas giran para encarar a su objetivo. Las balas viajan correctamente de las torretas a los enemigos y desaparecen al impactar.
* 29/04: Añadida funcionalidad a las Tiles (las casillas blancas que forman una cuadrícula): Ahora tienen un color diferente en mouseOver y crean una torreta básica al hacer click sobre una.
* 30/04: Las balas crean un efecto de partículas al impactar y desaparecer. Corregido un error que evitaba que se eliminasen.
* 01/05: Ahora la cámara se puede manejar durante la partida mediante las teclas (wasd) o el ratón. La tecla Esc bloquea el movimiento de la camara.
* 05/05: Añadido el overlay de botones para la compra de torretas y añadido script para gestionar la pulsación de cada uno, pero falta por implementar la lógica.
* 06/05: Implementada lógica para los botones de la tienda.
* 06/05: Ahora hay una nueva torre: Rocket Launcher, que dispara cohetes y daña enemigos en un área, con proyectil propio y efectos de explosión incluidos.
* 07/05: Limpieza y reestructuración del código, se crean clases y métodos para tener los scripts y sus funciones mejor organizados.
* 07/05: Se implementa la economía del juego: Dinero y vidas. Las torres tienen ahora coste y los enemigos quitan vidas. Se actualiza la interfaz para que el jugador pueda ver ambos y tener mejor usabilidad.
* 08/05: Se soluciona un bug con el evento MouseEnter de los Tiles. Limpieza de interfaz, código y comentarios.

## Cursos de formación Unity

Repositorio usado para seguir el avance de la formación y las pruebas de los cursos de formación de Unity: Pulsa [aquí](https://github.com/MagicoDave/Cursos-unity).

*Actualizado a 07/05/2023. Autor: David Casalderrey Paz*