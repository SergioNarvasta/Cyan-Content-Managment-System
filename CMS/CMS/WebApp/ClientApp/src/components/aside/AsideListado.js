import { useEffect, useState } from "react";
import { Table, Button } from "reactstrap";
import './Style.css';

const AsideListado = () => {
  const [modelList, setmodelList] = useState([]);

  const Listar = async () => {
    const response = await fetch("/api/aside/listatodos");
    if (response.ok) {
      const data = await response.json();
      setmodelList(data);
    } else {
      console.log("Error : (api/aside/listatodos)")
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
            <th>Contenido</th>
            <th>Estado</th>
            <th>Orden</th>
            <th>Imagen</th>
            <th>Usuario Creacion</th>
            <th>Fecha Creacion</th>
            <th>Usuario Actualiza</th>
            <th>Fecha Actualiza</th>
            <th></th>
          </tr>
        </thead>
        <tbody >
          {
            (modelList.length < 1) ? (
              <tr>
                <td colSpan="8">Sin registros</td>
              </tr>
            ) : (
              modelList.map((item) => (
                <tr key={item.contentMain_Pk} >
                  <td>{item.aside_Titulo}</td>
                  <td><textarea id="item_desc">{item.aside_Descripcion}</textarea> </td>
                  <td>{item.aside_Contenido}</td>
                  <td>{item.aside_Estado == 1 ? "Activo" : "Inactivo"}</td>
                  <td>{item.aside_Orden}</td>
                  <td><img src={"data:image/jpg;base64," + item.file_Base64} /></td>
                  <td>{item.audit_UsuCre}</td>
                  <td>{item.audit_FecCre}</td>
                  <td>{item.audit_UsuAct}</td>
                  <td>{item.audit_FecAct}</td>
                  <td><Button className="btn btn-danger">Eliminar</Button></td>
                </tr>
              ))
            )
          }
        </tbody>
      </Table>
    </div>
  )
}
export default AsideListado;