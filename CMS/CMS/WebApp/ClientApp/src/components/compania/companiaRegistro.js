import { useState, useEffect } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import CompanyListado from './companiaListado';
import './Style.css';
const modelo = {
  company_Pk: "",
  company_Nombre: "",
  company_Direccion: "",
  company_Telefono: 0,
  company_Email: "",
  company_Estado: 0,
  plan_Pk: "",
  user_Pk: "",
  file_Nombre: "",
  file_Base64: "",
  file_Tamanio: "",
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
const CompaniaRegistro = () => {
  const [compania, setcompania] = useState(modelo);
  const [user] = useState(window.localStorage.getItem("sesion_user"))
  const [dataUser, setDataUser] = useState(modelo_user)

  useEffect(() => {
    let dt = JSON.parse(user)
    setDataUser(dt)
  }, [])

  const actualizaDato = (e) => {
    console.log(e.target.name + " : " + e.target.value);
    setcompania(
      {
        ...compania,
        [e.target.name]: e.target.value
      }
    )
  }
  const enviarDatos = () => {
    compania.user_Pk = dataUser.user_Pk   //Asigno el usuario
    compania.company_Pk = "sebg-sd"
    compania.audit_UsuCre = dataUser.user_Nombre
    registrar(compania)
  }
  const registrar = async (compania) => {
    const response = await fetch("api/company/registro", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(compania)
    })
    if (response.ok) {
      window.location.reload();
    }
  }
  async function cargarArchivo(e) {
    let index = 0;
    let nombre = e.target.files[index].name;
    if (nombre.length > 1) {
      let tamanio = e.target.files[index].size.toString();
      if (tamanio > 1) {
        if (tamanio < 5120000) {
          let next = nombre.lastIndexOf('.');
          let extension = nombre.substring(next + 1);
          if (extension === "jpg" || extension === "png" || extension === "jpeg" || extension === "gif") {
            console.log('Convirtiendo blob -> ' + index);
            const myBlob = e.target.files[index];
            const myB64 = await blobToBase64(myBlob);
            compania.file_Base64 = myB64;
            compania.file_Nombre = nombre;
            compania.file_Tamanio = tamanio;
            console.log("Object :");
            console.log(compania);
          } else { alert("Archivo Invalido!. No tiene formato de imagen solicitado"); }
        } else { alert("Archivo Invalido!. Supera el limite 5MB"); }
      } else { alert("Archivo Invalido!. No tiene contenido"); }
    } else { alert("Archivo Invalido!. No tiene nombre"); }
  }
  const blobToBase64 = (blob) => {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(blob);
      reader.onloadend = () => {
        resolve(reader.result.split(',')[1]);
      };
    });
  }
  return (
    <div id="comp_compania">
      <Form id="form-registro"><br />
        <h3>Gestion de Compañias</h3> <br />
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row ">
            <label className="me-2">Nombre</label>
            <Input id="company_Nombre" name="company_Nombre" onChange={(e) => actualizaDato(e)}
              value={compania.company_Nombre}></Input>
          </FormGroup>
          <FormGroup className="d-flex flex-row ms-5">
            <label className="me-2">Telefono</label>
            <Input id="company_Telefono" name="company_Telefono" onChange={(e) => actualizaDato(e)}
              value={compania.company_Telefono}></Input>
          </FormGroup>
        </div>
        <div className="d-flex flex-row ">
          <FormGroup className="d-flex flex-row ">
            <label className="me-2">Email</label>
            <Input id="company_Email" name="company_Email" onChange={(e) => actualizaDato(e)}
              value={compania.company_Email}></Input>
          </FormGroup>
          <FormGroup className="d-flex flex-row ms-5">
            <label className="me-2">Plan</label>
            <Input id="plan_Pk" name="plan_Pk" onChange={(e) => actualizaDato(e)}
              value={compania.plan_Pk}></Input>
          </FormGroup>
        </div>
        <FormGroup className="d-flex flex-row">
          <label className="me-2">Direccion</label>
          <Input id="company_Direccion" name="company_Direccion" onChange={(e) => actualizaDato(e)}
            value={compania.company_Direccion}></Input>
        </FormGroup>
        <div className="d-flex flex-row">
          <FormGroup className="d-flex flex-row">
            <label className="me-5">Archivo</label>
            <input type="file" accept=".jpg,.png,.gif" onChange={(e) => cargarArchivo(e)} />
          </FormGroup>
          <FormGroup >
            <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success ms-5">Registrar</Button>
          </FormGroup>
        </div>
      </Form>
      <br/>
      <CompanyListado/>
    </div>
  )
}
export default CompaniaRegistro;