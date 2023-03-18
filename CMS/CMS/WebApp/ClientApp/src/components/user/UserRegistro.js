import { useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import UserListado from './UserListado';
import './Style.css';

const modelo = {
  User_Pk: "",
  User_Nombre: "",
  User_Direccion: "",
  User_Telefono: 0,
  User_Email: "",
  User_Token: "",
  User_Estado: 1,
  Plan_Pk: "",
  Rol_Pk: "",
  Audit_UsuCre: "",
  Audit_FecCre: "",
  Audit_UsuAct: "",
  Audit_FecAct: ""
}

const UserRegistro = () => {

  const [user, setuser] = useState(modelo);

  const actualizaDato = (e) => {
    console.log(e.target.name + " : " + e.target.value);
    setuser(
      {
        ...user,
        [e.target.name]: e.target.value
      }
    )
  }
  const enviarDatos = () => {
    registrar(user)
  }
  const registrar = async (user) => {
    const response = await fetch("api/user/registro", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user)
    })
    if (response.ok) {
      window.location.reload();
    }
  }

  return (
    <div>
      <Form id="form-registro">
        <h2 className="text-center">Gestion de Usuarios</h2> <br/>   
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Nombre</label>
          <Input id="txt_titulo" name="User_Nombre" onChange={(e) => actualizaDato(e)}
            value={user.User_Nombre}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row" id="group_desc">
          <label className="me-2">Direccion</label>
          <Input id="User_Direccion" name="User_Direccion" onChange={(e) => actualizaDato(e)}
            value={user.User_Direccion}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Telefono</label>
          <Input id="User_Telefono" name="User_Telefono" onChange={(e) => actualizaDato(e)}
            value={user.User_Telefono}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Email</label>
          <Input id="User_Email" name="User_Email" onChange={(e) => actualizaDato(e)}
            value={user.User_Email}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Token</label>
          <Input id="User_Token" name="User_Token" onChange={(e) => actualizaDato(e)}
            value={user.User_Token}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Plan</label>
          <Input id="Plan_Pk" name="Plan_Pk" onChange={(e) => actualizaDato(e)}
            value={user.Plan_Pk}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Rol</label>
          <Input id="Rol_Pk" name="Rol_Pk" onChange={(e) => actualizaDato(e)}
            value={user.Rol_Pk}></Input>
        </FormGroup>
        <FormGroup >
          <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success ms-5">Registrar</Button>
        </FormGroup>
      </Form>
      <br></br>
      <UserListado/>
    </div>
  )
}

export default UserRegistro;