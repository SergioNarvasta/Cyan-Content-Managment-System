import { useEffect, useState } from "react";
import { Table,  } from "reactstrap";
import './Style.css';

const ContentMainListado = () => {
  const [sliderMainList, setsliderMainList] = useState([]);

  const Listar = async () => {
    const response = await fetch("/api/contentmain/listatodos");
    if (response.ok) {
      const data = await response.json();
        setsliderMainList(data);      
    } else {
        console.log("Error : (api/contentmain/listatodos)")
    }
    }
  useEffect(() => {
    Listar()
  }, [])

 return (
 <div>
    <Table responsive className="table-bordered table-hover">
        <thead className="table-warning">
                <tr>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Estado</th>                 
                    <th>Nombre Archivo</th>
                    <th>Vista previa </th>                   
                    <th>Nombre Archivo</th>
                    <th>Vista previa </th>
                    <th>Nombre Archivo</th>
                    <th>Vista previa </th>
                    <th>Usuario Creacion</th>
                    <th>Fecha Creacion</th>
                    <th>Usuario Actualiza</th>  
                    <th>Fecha Actualiza</th>    
                    <th></th>
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
             <tr key={item.sliderMain_Pk} >
                 
                 <td>{item.sliderMain_Titulo}</td>
                 <td>{item.sliderMain_Descripcion}</td>
                 <td>{item.sliderMain_Estado = 1 ? "Activo" : "No disponible"}</td>                    
                 <td>{item.file_NombreF}</td>               
                
                 <td><img src={"data:image/jpg;base64," + item.file_Base64F} /></td>
                 <td>{item.file_NombreS}</td>
                 
                 <td><img src={"data:image/jpg;base64," + item.file_Base64S} /></td>        
                 <td>{item.file_NombreT}</td>                
                 
                 <td><img src={"data:image/jpg;base64," + item.file_Base64T} /></td>                
                 <td>{item.audit_UsuCre}</td>
                 <td>{item.audit_FecCre}</td>
                 <td>{item.audit_UsuAct}</td>
                 <td>{item.audit_FecAct}</td>
                     <td><button onClick={() => eliminar(item.sliderMain_Id)} className="btn btn-danger">Eliminar</button></td>
               </tr>
            ))
           )
          }
        </tbody>
    </Table> 

  </div>
  )
}
export default ContentMainListado;