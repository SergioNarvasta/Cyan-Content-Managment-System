import { Button,Table } from "reactstrap";
import './Proyectos.css';

const ProyectosTabla = ({data}) =>{
    return (
      <Table striped responsive className="table-bordered ">
            <thead className="table-warning">
                <tr>
                    <th>Nombre de Proyecto</th>
                    <th>Descripcion</th>
                    <th>Link</th>
                    <th>Acciones</th>                
                </tr>
            </thead>
            <tbody>
               {
                (data.length < 1) ?(
                    <tr>
                        <td colSpan="8">Sin registros</td>
                    </tr>
                ):(
                    data.map((item) =>(
                    <tr key={item.id} >
                        <td>{item.name}</td>
                        <td id="table-desc">{item.description     }</td>
                        <td>{item.link}</td>               
                        <td> 
                            <Button className="me-2" color="warning">Editar</Button>
                            <Button color="danger">Eliminar</Button>
                        </td>
                    </tr>                    
                    ))
                )
               }
            </tbody>
        </Table>
        
    )
}
export default ProyectosTabla;