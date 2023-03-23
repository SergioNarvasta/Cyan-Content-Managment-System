import React, { useState,useEffect } from 'react';
import { Link, NavLink } from 'react-router-dom';
import './NavBar.css';

const modelo = {
    User_Pk: "",
    User_Nombre: "",
    User_Direccion: "",
    User_Telefono: 0,
    User_Email: "",
    User_Token: "",
    User_Estado: 0,
    Plan_Pk: "",
    Rol_Pk: "",
    Audit_UsuCre: "",
    Audit_FecCre: "",
    Audit_UsuAct: "",
    Audit_FecAct: ""
}
const NavBar = () => {
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo)

    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
    }, [])
    return (
        
        <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <Link className="sidebar-brand d-flex align-items-center justify-content-center" to="/">
                <div className="sidebar-brand-icon">
                <img src={"./imagen/pantalla-curva.png"} />
                </div>
                <div className="sidebar-brand-text mx-3">Sistema de Gestion de Contenido - CMS</div>
            </Link>
            {
                (dataUser === null) &&
                
                    <NavLink tag={Link} className="text-dark" to="/login">Inicie Sesion</NavLink>
                
            }
            {
                (dataUser.user_Nombre !== null) &&
               
                    <NavLink tag={Link} className="text-dark" to="" >{dataUser.user_Nombre}</NavLink>
            }

            
            <hr className="sidebar-divider my-0" />

            {
                (dataUser.user_Nombre !== null) &&
                <li className="nav-item">
                    <NavLink to="/dashboard" className="nav-link" >
                        <i className="fas fa-fw fa-tachometer-alt"></i>
                        <span>Dashboard</span>
                    </NavLink>
                </li>
            }
           
            <hr className="sidebar-divider" />
            {
                (dataUser.user_Nombre !== null) &&
                <li className="nav-item">
                    <a className="nav-link collapsed" data-toggle="collapse" data-target="#collapseUsuario"
                        aria-expanded="true" aria-controls="collapseUsuario">
                        <i className="fas fa-fw fa-cog"></i>
                        <span>Administracion</span>
                    </a>
                    <div id="collapseUsuario" className="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            <NavLink to="/user" className="collapse-item">Usuarios</NavLink>
                            <NavLink to="/compania" className="collapse-item">Compañia</NavLink>
                           
                        </div>
                    </div>
                    
                </li>
            }
            
            {
                (dataUser.user_Nombre !== null) &&
                <li className="nav-item">
                    <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseInventario"
                        aria-expanded="true" aria-controls="collapseInventario">
                        <i className="fas fa-fw fa-box"></i>
                        <span>Componentes</span>
                    </a>
                    <div id="collapseInventario" className="collapse" aria-labelledby="headingUtilities"
                        data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            
                            <NavLink className="collapse-item" to="/slider-main">SliderMain</NavLink>
                        </div>
                    </div>
                </li>
            }
           

            <li className="nav-item">
                <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseVenta"
                    aria-expanded="true" aria-controls="collapseVenta">
                    <i className="fas fa-fw fa-tag"></i>
                    <span>Ventas</span>
                </a>
                <div id="collapseVenta" className="collapse" aria-labelledby="headingUtilities"
                    data-parent="#accordionSidebar">
                    <div className="bg-white py-2 collapse-inner rounded">
                        <NavLink to="/venta" className="collapse-item">Nueva Venta</NavLink>
                        <NavLink to="/historialventa" className="collapse-item">Historial Venta</NavLink>
                    </div>
                </div>
            </li>


            {(dataUser.user_Nombre !== null) &&
                <li className="nav-item">
                    <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseReporte"
                        aria-expanded="true" aria-controls="collapseReporte">
                        <i className="fas fa-fw fa-chart-area"></i>
                        <span>Reportes</span>
                    </a>
                    <div id="collapseReporte" className="collapse" aria-labelledby="headingUtilities"
                        data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            <NavLink to="/reporteventa" className="collapse-item">Reporte Venta</NavLink>
                        </div>
                    </div>
                </li>
            }

            {(dataUser.user_Nombre !== null) &&
                <li className="nav-item">
                    <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseLogo"
                        aria-expanded="true" aria-controls="collapseLogo">
                        <i className="fas fa-fw fa-chart-area"></i>
                        <span>Archivos</span>
                    </a>
                    <div id="collapseLogo" className="collapse" aria-labelledby="headingUtilities"
                        data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            <NavLink to="/archivo" className="collapse-item">Logo</NavLink>
                        </div>
                    </div>
                </li>
            }
            
            <hr className="sidebar-divider d-none d-md-block" />

            <div className="text-center d-none d-md-inline">
                <button className="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
        )
}

export default NavBar;