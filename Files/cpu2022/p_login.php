<?php 
//trabajando con sesión
session_start();



include("conexion.php");

$usu=$_POST["txtusuario"];
$pass=$_POST["txtpass"];

$sql="select * from usuario where codalumno='$usu' and password='$pass'";
$fila=mysql_query($sql);
$r=mysql_fetch_array($fila);

$valor=$r["codalumno"];



if ($valor==null) {
	
	header('location:index.php');


} else {

	$_SESSION["usuario"]=$valor;

	$_SESSION["auth"]=1;

	header('location: principal.php');
}








 ?>