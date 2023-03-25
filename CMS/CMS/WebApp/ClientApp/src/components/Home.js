import React, { Component } from 'react';
import './Home.css';
//import perfil from './assets/Perfil.jpg';

const cerrarSession = () => {
    window.localStorage.removeItem("sesion_user")
    //setUser(null)
}

export class Home extends Component {
  static displayName = Home.name;
  render() {
    return (
      <div id='comp_home'>
        <div id='perfil'>
          <div id="caja">
            <div> <br/><br/>
                <h3>Sistema de Gestion de Contenido  CMS</h3>
                <img  height="200" width="200"></img>
            </div> <br/>
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
            
                <button className="btn btn-danger ms-3" onClick={cerrarSession}>Remove User</button>
        </div>
        <br></br>
      </div>
    );
  }
}
