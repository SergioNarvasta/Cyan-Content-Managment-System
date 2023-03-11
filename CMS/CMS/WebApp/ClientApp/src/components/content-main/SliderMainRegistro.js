import { useEffect, useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import { Table } from "reactstrap";

const modelo = {
  sliderMain_Titulo: "",
  sliderMain_Pk: "",
  sliderMain_Descripcion: "",
  SliderMain_Estado : 0,
  sliderMain_Orden : 0,
  file_Nombre : "",
  file_RutaArchivo  : "",//Opcional solo si se guarta en ruta fisica
  file_RutaDrive : "",   //Opcional si carga desde google drive
  file_Base64 : "",
  file_Tamanio : "",
  file_Extension : "",
  audit_UsuCre : "",
  audit_FecCre : "",
  audit_UsuAct : "",
  audit_FecAct : ""
}

const SliderMainRegistro = () => {
  const [sliderMainList, setsliderMainList] = useState([]);
  const [sliderMainCreate, setsliderMainCreate] = useState(modelo);

  const Listar = async () => {
    const response = await fetch("/api/slidermain/lista");
    if (response.ok) {
      const data = await response.json();
      setsliderMainList(data);
    } else {
      console.log("Error al listar (/api/slidermain/lista)")
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
    let nombre = e.target.files[0].name;
    let tamanio = e.target.files[0].size;
    let next = nombre.lastIndexOf('.');
    let extension = nombre.substring(next + 1);
  
    setsliderMainCreate(
      {
        ...sliderMainCreate,
        [sliderMainCreate.file_Base64]: myB64,
        [sliderMainCreate.file_Nombre]: nombre,
        [sliderMainCreate.file_Tamanio]: tamanio,
        [sliderMainCreate.file_Extension]:extension
      }
    )
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
          <label>Imagen</label>
          <input type="file" onChange={(e) => cargarArchivo(e)} />
        </FormGroup>
        
      </Form>
      <br></br>
      
      <Table striped responsive className="table-bordered ">
            <thead className="table-warning">
                <tr>
                    <th>Pk </th>
                    <th>Titulo </th>
                    <th>Descripcion</th>
                    <th>Estado</th>  
                    <th>Orden</th>                 
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
                      <td>{item.sliderMain_Orden}</td>
                      <td>{item.sliderMain_Nombre}</td>
                      <td>{item.sliderMain_Version}</td>
                      <td id="td_sliderMain_URLDrive"><textarea id="txa_sliderMain_URLDrive">{item.sliderMain_URLDrive}</textarea></td>
                      <td id="td_sliderMain_URLImagen"><textarea id="txa_sliderMain_URLImagen">{item.sliderMain_URLImagen}</textarea></td>
                      <td><img src={item.sliderMain_URLImagen} width={200} height={80} /></td>
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