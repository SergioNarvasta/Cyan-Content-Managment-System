import { Table } from "reactstrap";

const ProyectosInfo = ({data}) =>{
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>NroDoc      </th>
                    <th>Titulo      </th>
                    <th>Descripcion </th>
                    <th>Moneda      </th>
                    
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
                        <td>{item.nroDoc}</td>
                        <td>{item.titulo     }</td>
                        <td>{item.descripcion}</td>
            
                    </tr>                    
                    ))
                )
               }
            </tbody>
        </Table>
    )
}
export default ProyectosInfo;