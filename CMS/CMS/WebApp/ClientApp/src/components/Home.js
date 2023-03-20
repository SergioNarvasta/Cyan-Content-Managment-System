import React, { Component } from 'react';
import './Home.css';
//import perfil from './assets/Perfil.jpg';

const user = {
    User_Pk: "s7632-5953.",
    User_Nombre: "SNarvasta",
    User_Direccion: "",
    User_Telefono: 980202425,
    User_Email: "sergio.jn024@gmail.com",
    User_Token: "s76325953.",
    User_Estado: 1,
    Plan_Pk: "1",
    Rol_Pk: "1",
    Audit_UsuCre: "",
    Audit_FecCre: "18/03/2023",
    Audit_UsuAct: "",
    Audit_FecAct: ""
}
const iniciarSession = (data) => {
    window.localStorage.setItem("sesion_user", JSON.stringify(data))
    console.log("se inserto " + JSON.stringify(data));
    //setUser(JSON.stringify(data))
}
const cerrarSession = () => {
    window.localStorage.removeItem("sesion_user")
    //setUser(null)
}

export class Home extends Component {
  static displayName = Home.name;
  render() {
    return (
      <div>
        <div id='perfil'>
          <div id="caja">
            <div>
                <h3>Sistema de Gestion de Contenido  CMS</h3>
                <img  height="200" width="200"></img>
            </div> <br></br>
            <div id="datos">
                <p>Descripcion</p>
                <p>General</p>
                <a>Link</a> <a>Github</a> <a>Wspp</a>
            </div>
          </div> <br/>
          <div id="desc">
            <p>Desarrollado utilizando tecnologías: C# .NET 6, Angular, React Js,<br/> 
               JQuery, Bootstrap, SQL Server, Azure, contenedorizacion y orquestación con <br/>
               Docker & Kubernetes trabajando de forma colaborativa con Git & GitHub  <br/> utilizando las metodologías ágiles. <br/>
               Implementación de Integración y despliegue continuo en Azure Devops con Infraestructura como código Terraform. <br/>
               Especialistas en Administración de Bases de Datos SQL Server
            </p>
                </div> <br></br>
                <button class="btn btn-warning ms-5" onClick={iniciarSession(user)}>Insert User</button>
                <button class="btn btn-danger ms-3" onClick={cerrarSession}>Remove User</button>
        </div>
        <br></br>
      </div>
    );
  }
}
