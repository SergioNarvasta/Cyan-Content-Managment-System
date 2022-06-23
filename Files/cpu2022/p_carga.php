<?php 

include("conexion.php");

$archivo=$_FILES["archivo"]["tmp_name"];


$fila=file($archivo);

for ($i=0; $i <count($fila) ; $i++) { 



list($id,$n,$p,$m,$e,$a)=explode(";",$fila[$i]);


$insertdatos="insert into datos(codalumno,estado) values('$id',0)";
mysql_query($insertdatos,$cn);

/*
$pass=obtenerpassword();

//echo $id." ".$n." ".$p." ".$m." ".$e." ".$a." ".$pass."<br>";

$insertalumno="insert into alumno values('$id','$n','$p','$m','$e','$a')";
$insertusuario="insert into usuario values('$id','$pass')";
$insertnota="insert into nota(codalumno) values ('$id')";

mysql_query($insertalumno,$cn);
mysql_query($insertusuario,$cn);
mysql_query($insertnota,$cn);

*/
}



function obtenerpassword(){

//substr(cadena,posicion,cantcaracteres)
//rand(limi,lims)

$plantilla="1234567890qwertyuiopasdfghjklzxcvbnm";

$password="";


	for ($i=1; $i <=8 ; $i++) { 


		$password=$password.substr($plantilla,rand(1,36),1);


		
	}


return $password;

}







 ?>