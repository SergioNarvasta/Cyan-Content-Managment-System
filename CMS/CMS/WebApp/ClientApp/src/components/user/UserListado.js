import { useEffect, useState } from "react";
import { Table  } from "reactstrap";
import Swal from 'sweetalert2'
import './Style.css';

const UserListado = () => {
  const [user, setUser] = useState([]);

  const Listar = async () => {
    const response = await fetch("/api/user/listatodos");
    if (response.ok) {
      const data = await response.json();
      setUser(data);    
    } else {
        console.log("Error : (api/user/listatodos)")
      }
    }
  useEffect(() => {
    Listar()
  }, [])

 const eliminar = async (id) => {
        Swal.fire({
            title: 'Esta seguro?',
            text: "Desea eliminar el registro",
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, continuar',
            cancelButtonText: 'No, volver'
        }).then((result) => {
            if (result.isConfirmed) {
                const response = fetch("api/slidermain/elimina", {
                    method: "DELETE",
                    headers: {
                        'Content-Type': 'application/json'
                    }, body: id })
                .then(response => {
                    if (response.ok) {
                        window.location.reload();
                        Swal.fire(
                            'El registro fue eliminado.',
                            'success'
                        )
                    }
                })
            }
        })
    }

 return (
 <div>
       <h3>Listado de Registros</h3>
    <Table responsive className="table-bordered table-hover">
        <thead className="table-warning">
                <tr>
                    <th>Nombre</th>
                    <th>Direccion</th>
                    <th>Telefono</th>                 
                    <th>Email</th>
                    <th>Estado</th>
                    <th>Plan</th>
                    <th>Rol</th>
                    <th>Usuario Creacion</th>
                    <th>Fecha Creacion</th>
                    <th>Usuario Actualiza</th>  
                    <th>Fecha Actualiza</th>    
                    <th></th>
                </tr>
            </thead>
        <tbody >
          {
           (user.length < 1) ?(
               <tr>
                   <td colSpan="8">Sin registros</td>
               </tr>
           ):(
            user.map((item) => (
             <tr key={item.user_Pk} >
                 
                 <td>{item.user_Nombre}</td>
                 <td>{item.user_Direccion}</td>
                 <td>{item.user_Telefono }</td>                    
                 <td>{item.user_Email}</td>               
                 <td>{item.user_Estado = 1 ? "Activo" : "Inactivo"}</td>
                 <td>{item.plan_Pk}</td>
                 <td>{item.rol_Pk}</td>
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
export default UserListado;