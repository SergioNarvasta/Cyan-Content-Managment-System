<?php 
include("auth.php");
include("conexion.php");


$c=$_SESSION["usuario"];



$sql="select * from alumno where codalumno='$c'";
$f=mysql_query($sql);

$r=mysql_fetch_array($f);




 ?>

<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title></title>
</head>
<body>




Bienvenido(a). 
<?php 

echo $r["nombre"]." ".$r["paterno"]." ". $r["materno"];

 ?>


<br><br><br>

<a href="cerrarsesion.php" target="_parent">Cerrar Sesión</a>

</body>
</html>