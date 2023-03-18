import { useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";

const modelo = {
     Company_Pk :"",
     Company_Nombre :"",
     Company_Direccion :"",
     Company_Telefono :0,
     Company_Email :"",
     Company_Estado :0,
     Plan_Pk :"",
     User_Pk :""
}

const CompaniaRegistro = ()=>{
    const [compania, setcompania] = useState(modelo);
    
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
        registrar(compania)
      }
      const registrar = async (compania) => {
        const response = await fetch("api/compania/registro", {
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
      return (
        <div>
      <Form id="form-registro">
        <h2 className="text-center">Gestion de Compañias</h2> <br/>   
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Nombre</label>
          <Input id="Company_Nombre" name="Company_Nombre" onChange={(e) => actualizaDato(e)}
            value={compania.Company_Nombre}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row" id="group_desc">
          <label className="me-2">Direccion</label>
          <Input id="Company_Direccion" name="Company_Direccion" onChange={(e) => actualizaDato(e)}
            value={compania.Company_Direccion}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Telefono</label>
          <Input id="Company_Telefono" name="Company_Telefono" onChange={(e) => actualizaDato(e)}
            value={compania.Company_Telefono}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Email</label>
          <Input id="Company_Email" name="Company_Email" onChange={(e) => actualizaDato(e)}
            value={compania.Company_Email}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Plan</label>
          <Input id="Plan_Pk" name="Plan_Pk" onChange={(e) => actualizaDato(e)}
            value={compania.Plan_Pk}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row ">
          <label className="me-2">Usuario</label>
          <Input id="User_Pk" name="User_Pk" onChange={(e) => actualizaDato(e)}
            value={compania.User_Pk}></Input>
        </FormGroup>
        
        <FormGroup >
          <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success ms-5">Registrar</Button>
        </FormGroup>
      </Form>
      <br></br>

    </div>
      )
}
export default CompaniaRegistro;