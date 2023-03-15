import { useEffect, useState } from "react";
import {Table} from "reactstrap";

const SliderMainListado = () => {
  const [sliderMainList, setsliderMainList] = useState([]);

  const Listar = async () => {
    const response = await fetch("/api/slidermain/listatodos");
    if (response.ok) {
      const data = await response.json();
        setsliderMainList(data);
        
    } else {
        console.log("Error : (/api/slidermain/listatodos)")
    }
  }
  useEffect(() => {
    Listar()
  }, [])
  const vistaPreviaImagen = () => { 

    var filebase64 = "";
  for (var i = 0; i < 3; i++) {
      switch (i) {
          case 1: filebase64 = sliderMainList.file_Base64F;
              break;
          case 2: filebase64 = sliderMainList.file_Base64S;
              break;
          case 3: filebase64 = sliderMainList.file_Base64T;
              break;
      }

      if (filebase64.value != "") {
          var imagen = document.getElementById('imagen_v' + i);
          console.log(imagen);
          imagen.setAttribute('src', "data:image/jpg;base64," + filebase64);
      }
  }
}
  return (

    <Table striped responsive className="table-bordered ">
            <thead className="table-warning">
                <tr>
                    <th>Pk</th>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Estado</th>                 
                    <th>File_Nombre First</th>
                    <th>File_Base64 First</th>
                    <th>File_Tamanio First</th> 
                    <th>Vista previa </th>                   
                    <th>File_Nombre Second</th>
                    <th>File_Base64 Second</th>
                    <th>File_Tamanio Second</th> 
                    <th>Vista previa </th>
                    <th>File_Nombre Thrid</th>
                    <th>File_Base64 Thrid</th>
                    <th>File_Tamanio Thrid</th> 
                    <th>Vista previa </th>
                    <th>Usuario Creacion</th>
                    <th>Fecha Creacion</th>
                    <th>Usuario Actualiza</th>  
                    <th>Fecha Actualiza</th>                      
                </tr>
            </thead>
            <tbody >
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
                      <td>{item.file_NombreF}</td>
                          <td ><textarea id="td_file1" defaultValue={item.file_Base64F}></textarea></td>
                      <td>{item.file_TamanioF}</td>
                      <td><img id="imagen_v1" /></td>

                      <td>{item.file_NombreS}</td>
                          <td ><textarea id="td_file2" defaultValue={item.file_Base64S} ></textarea></td>
                      <td>{item.file_TamanioS}</td>
                      <td><img id="imagen_v2" /></td>

                      <td>{item.file_NombreT}</td>
                          <td ><textarea id="td_file3" defaultValue={item.file_Base64T} ></textarea></td>
                      <td>{item.file_TamanioT}</td>
                      <td><img id="imagen_v3" /></td>
                      
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

  )
}
export default SliderMainListado;