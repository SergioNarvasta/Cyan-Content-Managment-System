<?php 

include("conexion.php");

$archivo=$_FILES["archivo"]["tmp_name"];

$opcion=$_POST["lstpractica"];

$fila=file($archivo);

for ($i=0; $i <count($fila) ; $i++) { 
	

	list($codigo, $nota)=explode(";",$fila[$i]);

		$sql="update nota
		set nota$opcion=$nota
		where codalumno=$codigo";

		mysql_query($sql);

}

header('location:cargaevaluacion.php');





 ?>