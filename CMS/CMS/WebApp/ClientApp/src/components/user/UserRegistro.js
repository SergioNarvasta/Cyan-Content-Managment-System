import { useState,useEffect } from "react";
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
const modelo_user = {
  user_Pk: "",
  user_Nombre: "",
  user_Direccion: "",
  user_Telefono: 0,
  user_Email: "",
  user_Token: "",
  user_Estado: 0,
  plan_Pk: "",
  rol_Pk: "",
  audit_UsuCre: "",
  audit_FecCre: "",
  audit_UsuAct: "",
  audit_FecAct: ""
}
const UserRegistro = () => {
  const [user, setuser] = useState(modelo);
  const [sesion_user] = useState(window.localStorage.getItem("sesion_user"))
  const [dataUser, setDataUser] = useState(modelo_user)

  useEffect(() => {
    let dt = JSON.parse(sesion_user)
    setDataUser(dt)
  }, [])
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
    user.audit_UsuCre = dataUser.user_Nombre
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
      <Form id="form-registro"><br />
        <h3>Gestion de Usuarios</h3> <br />
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row ">
            <label className="me-2">Nombre</label>
            <Input id="txt_titulo" name="user_Nombre" onChange={(e) => actualizaDato(e)}
              value={user.user_Nombre}></Input>           
          </FormGroup>
          <FormGroup className="d-flex flex-row ms-5" id="group_desc">
              <label className="me-2">Direccion</label>
              <Input id="User_Direccion" name="user_Direccion" onChange={(e) => actualizaDato(e)}
                value={user.user_Direccion}></Input>
            </FormGroup>
        </div>
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row ">
            <label className="me-2">Telefono</label>
            <Input id="User_Telefono" name="user_Telefono" onChange={(e) => actualizaDato(e)}
              value={user.user_Telefono}></Input>
          </FormGroup>
          <FormGroup className="d-flex flex-row ms-5">
            <label className="me-2">Email</label>
            <Input id="User_Email" name="user_Email" onChange={(e) => actualizaDato(e)}
              value={user.user_Email}></Input>
          </FormGroup>
        </div>
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row">
            <label className="me-2">Token</label>
            <Input id="User_Token" name="user_Token" onChange={(e) => actualizaDato(e)}
              value={user.user_Token}></Input>
          </FormGroup>
          <FormGroup className="d-flex flex-row ms-5">
            <label className="me-2">Plan</label>
            <Input id="Plan_Pk" name="plan_Pk" onChange={(e) => actualizaDato(e)}
              value={user.plan_Pk}></Input>
          </FormGroup>
        </div>
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row me-4">
            <label className="me-5">Rol</label>
            <select id="Rol_Pk" name="rol_Pk" onChange={(e) => actualizaDato(e)}
              value={user.rol_Pk} className="form-control" >
              <option>Rol 1</option>
              <option>Rol 2</option>
            </select>
          </FormGroup>
          <FormGroup >
            <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success ms-5">Registrar</Button>
          </FormGroup>
        </div>
      </Form>
      <br></br>
      <UserListado />
    </div>
  )
}

export default UserRegistro;