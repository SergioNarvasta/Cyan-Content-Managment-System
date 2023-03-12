import { useEffect, useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import { Table } from "reactstrap";

const modelo = {
  sliderMain_Pk: "",
  sliderMain_Titulo: "",
  sliderMain_Descripcion: "",
  sliderMain_Estado : 0,
  sliderMain_Orden: 0,
  SliderMain_UsuarioPk: "",
  file_Nombre : "",
  file_Base64 : "",
  file_Tamanio : "",
  file_Extension: "",
  audit_UsuCre : "",
  audit_FecCre : "",
  audit_UsuAct : "",
  audit_FecAct : ""
}

const SliderMainRegistro = () => {
  const [sliderMainList, setsliderMainList] = useState([]);
  const [sliderMainCreate, setsliderMainCreate] = useState(modelo);

  const Listar = async () => {
    const response = await fetch("/api/slidermain/listatodos");
    if (response.ok) {
      const data = await response.json();
      setsliderMainList(data);
    } else {
        console.log("Error al listar (/api/slidermain/listatodos)")
    }
  }
  useEffect(() => {
    Listar()
  }, [])
  const actualizaDato = (e) => {
    console.log(e.target.name + " : " + e.target.value);
    setsliderMainCreate(
      {
        ...sliderMainCreate,
        [e.target.name]: e.target.value
      }
    )
  }
  const enviarDatos = () => {
    guardarsliderMain(sliderMainCreate)
  }
  const guardarsliderMain = async (sliderMainCreate) => {
    const response = await fetch("api/slidermain/registro", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(sliderMainCreate)
    })
    if (response.ok) {
      console.log("Registrado con exito");
      window.location.href = window.location.href;
      //document.getElementById("LnList").click();
    } 
  }
  async function cargarArchivo(e) {
    console.log('Convirtiendo mi blob');
    const myBlob = e.target.files[0];
    const myB64 = await blobToBase64(myBlob);
    console.log(myB64);
    let nombre = e.target.files[0].name;
    let tamanio = e.target.files[0].size.toString();
    let next = nombre.lastIndexOf('.');
    let extension = nombre.substring(next + 1);
    
      console.log(nombre + " tamaño: " + tamanio + " extension: " + extension);
      document.getElementById('file_Base64').value = myB64;
      document.getElementById('file_Nombre').value = nombre;
      document.getElementById('file_Tamanio').value = tamanio;
      document.getElementById('file_Extension').value = extension;

    console.log(sliderMainCreate);
  }
  const blobToBase64 = (blob) => {
    return new Promise( (resolve, reject) =>{
        const reader = new FileReader();
        reader.readAsDataURL(blob);
        reader.onloadend = () => {
            resolve(reader.result.split(',')[1]);
        };
    });
};

  return (
    <div>
      <Form id="form-registro">
        <h2 className="text-center">Gestion de SliderMain</h2> <hr />
        <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success">Registrar</Button> <hr />
        <FormGroup className="d-flex flex-row ">
          <label>Titulo</label>
          <Input id="form-input" name="sliderMain_Titulo" onChange={(e) => actualizaDato(e)}
            value={sliderMainCreate.sliderMain_Titulo}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>Descripcion</label>
          <Input id="form-input" name="sliderMain_Descripcion" onChange={(e) => actualizaDato(e)}
            value={sliderMainCreate.sliderMain_Descripcion}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>Orden</label>
          <Input id="form-input" name="sliderMain_Orden" onChange={(e) => actualizaDato(e)}
            value={sliderMainCreate.sliderMain_Orden}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
            <label>Base 64</label>
                  <Input id="file_Base64" name="file_Base64" onChange={(e) => actualizaDato(e)}
                value={sliderMainCreate.file_Base64}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
            <label>Nombre Archivo</label>
                  <Input id="file_Nombre" name="file_Nombre" onChange={(e) => actualizaDato(e)}
                value={sliderMainCreate.file_Nombre}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
            <label>Tamaño Archivo</label>
                  <Input id="file_Tamanio" name="file_Tamanio" onChange={(e) => actualizaDato(e)}
                value={sliderMainCreate.file_Tamanio}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
            <label>Extension Archivo</label>
                  <Input id="file_Extension" name="file_Extension" onChange={(e) => actualizaDato(e)}
                value={sliderMainCreate.file_Extension}></Input>
        </FormGroup>

        <FormGroup className="d-flex flex-row">
          <label>Imagen</label>
          <input type="file" onChange={(e) => cargarArchivo(e)} />
        </FormGroup>
        
      </Form>
      <br></br>
      <Table striped responsive className="table-bordered ">
            <thead className="table-warning">
                <tr>
                    <th>Pk</th>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Estado</th>  
                    <th>Orden</th>
                    <th>File_Nombre</th>
                    <th>File_Base64</th>
                    <th>File_Tamanio</th>  
                    <th>File_Extension</th>
                    <th>Audit_UsuCre</th>
                    <th>Audit_FecCre</th>
                    <th>Audit_UsuAct</th>  
                    <th>Audit_FecAct</th>                      
                </tr>
            </thead>
            <tbody>
               {
                (sliderMainList.length < 1) ?(
                    <tr>
                        <td colSpan="8">Sin registros</td>
                    </tr>
                ):(
                  sliderMainList.map((item) => (
                    <tr key={item.sliderMain_Id}>
                      <td>{item.sliderMain_Pk}</td>
                      <td>{item.sliderMain_Titulo}</td>
                      <td>{item.sliderMain_Descripcion}</td>
                      <td>{item.sliderMain_Estado = 1 ? "Activo" : "No disponible"}</td>                    
                      <td>{item.sliderMain_Orden}</td>
                      <td>{item.file_Nombre}</td>
                      <td id="td_file_Base64"><textarea >{item.file_Base64}</textarea></td>
                      <td>{item.file_Tamanio}</td>
                      <td>{item.file_Extension}</td>
                      <td>{item.audit_UsuCre}</td>
                      <td>{item.audit_FecCre}</td>
                      <td>{item.audit_UsuAct}</td>
                      <td>{item.audit_FecAct}</td>
                    </tr>
                    ))
                )
               }
            </tbody>
        </Table>     
    </div>
  )
}

export default SliderMainRegistro;