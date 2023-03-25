import { useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import UserListado from './UserListado';
import './Style.css';

const modelo = {
  user_Pk: "",
  user_Nombre: "",
  user_Direccion: "",
  user_Telefono: 0,
  user_Email: "",
  user_Token: "",
  user_Estado: 1,
  plan_Pk: "",
  rol_Pk: "",
  audit_UsuCre: "",
  audit_FecCre: "",
  audit_UsuAct: "",
  audit_FecAct: ""
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
    <div id="comp_user">
      <Form id="form-registro"><br/>
        <h3>Gestion de Usuarios</h3> <br/>   
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
          <select id="Rol_Pk" name="Rol_Pk" onChange={(e) => actualizaDato(e)}
            value={user.Rol_Pk}>
            <option>Rol 1</option>
            <option>Rol 2</option>
          </select>
         
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