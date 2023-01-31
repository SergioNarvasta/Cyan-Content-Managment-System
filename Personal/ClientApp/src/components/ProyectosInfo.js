import { Table } from "reactstrap";

const ProyectosInfo = ({data}) =>{
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombre      </th>
                    <th>Descripcion      </th>
                    <th>link </th>
                    
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
                        <td>{item.description     }</td>
                        <td>{item.link}</td>
            
                    </tr>                    
                    ))
                )
               }
            </tbody>
        </Table>
    )
}
export default ProyectosInfo;