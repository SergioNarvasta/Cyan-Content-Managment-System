import React, { useState, useEffect } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { GrDocumentConfig } from "react-icons/gr";
import { RxComponent1 } from "react-icons/rx";
import { MdManageAccounts } from "react-icons/md";
import { VscDebugBreakpointData } from "react-icons/vsc";
import { FcManager } from "react-icons/fc";
import './NavBar.css';

const modelo = {
    user_Pk: "",
    user_Nombre: "",
    user_Direccion: "",
    user_Telefono: 0,
    user_Email: "",
    user_Token: "",
    user_Estado: 0,
    plan_Pk: "",
    rol_Pk: "",
    audit_UsuCre: "",
    audit_FecCre: "",
    audit_UsuAct: "",
    audit_FecAct: ""
}
const NavBar = () => {
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo)
    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
        hideComponents()
        hideAdministration()
        hideUser()
        hideConfiguration()
    }, [])

    const oculta = () => {
        var accordionSidebar = document.getElementById('accordionSidebar');
        accordionSidebar.style.display = 'none';
    }
    const cerrarSession = () => {
        window.localStorage.removeItem("sesion_user");
        window.location = "/";
    }
    const showComponents = () => {
        document.getElementById('box_components').style.display = 'block';
    }
    const hideComponents = () => {
        document.getElementById('box_components').style.display = 'none';
    }
    const showAdministration = () => {
        document.getElementById('box_administration').style.display = 'block';
    }
    const hideAdministration = () => {
        document.getElementById('box_administration').style.display = 'none';
    }
    const showUser = () => {
        document.getElementById('box_user').style.display = 'block';
    }
    const hideUser = () => {
        document.getElementById('box_user').style.display = 'none';
    }
    const showConfiguration = () => {
        document.getElementById('box_configuration').style.display = 'block';
    }
    const hideConfiguration = () => {
        document.getElementById('box_configuration').style.display = 'none';
    }

    return (
        <div>
            <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
                <Link className="sidebar-brand d-flex align-items-center justify-content-center item" to="/">
                    <div className="sidebar-brand-icon">
                    </div>
                    <div className="sidebar-brand-text mx-3" id='titleMain'><p>Sistema de Gestion de Contenido - CMS</p></div>
                </Link>
                <div id='sidebar_options'>
                    {
                        (dataUser === null) &&
                        <NavLink tag={Link} className="item" to="/login">Inicie Sesion</NavLink>
                    }
                    {
                        (dataUser !== null) &&
                        <div>
                            <a tag={Link} className=" item" onClick={showUser} >
                                <FcManager style={{ fontSize: '23px', marginRight: '5px' }} /> {dataUser.user_Nombre}
                            </a><br />
                            <div id='box_user' onMouseLeave={hideUser} >
                                <NavLink tag={Link} className="item" to="/perfil" ><VscDebugBreakpointData />Perfil</NavLink><br />
                                <NavLink tag={Link} className="item" to="/" onClick={cerrarSession}><VscDebugBreakpointData />Cerrar Sesion</NavLink>
                            </div>
                        </div>
                    }
                    <hr className="sidebar-divider" />
                    {
                        (dataUser !== null) &&
                        <div>
                            <a className='item' onClick={showAdministration} >Administracion
                                <MdManageAccounts style={{ fontsize: '40px', color: 'white' }} />
                            </a><br />
                            <div id='box_administration' onMouseLeave={hideAdministration}>
                                <NavLink to="/companies" className="collapse-item item"><VscDebugBreakpointData />Compañia</NavLink><br />
                                {
                                    (dataUser.rol_Pk === "1") &&
                                    <NavLink to="/user" className="collapse-item item"><VscDebugBreakpointData />Usuarios</NavLink>
                                }

                            </div>
                        </div>
                    }
                    {
                        (dataUser !== null) &&
                        <div className=" py-2 collapse-inner rounded" >
                            <a className='item' onClick={showComponents} >Componentes
                                <RxComponent1 style={{ color: 'white' }} />
                            </a> <br />
                            <div id='box_components' onMouseLeave={hideComponents}>
                                <NavLink className="item" to="/slidermain"><VscDebugBreakpointData />SliderMain</NavLink><br />
                                <NavLink className="item" to="/contentmain"><VscDebugBreakpointData />ContentMain</NavLink><br />
                                <NavLink className="item" to="/aside"><VscDebugBreakpointData />Aside</NavLink><br />
                                <NavLink className="item" to="/content-sec"><VscDebugBreakpointData />ContentSec</NavLink>
                            </div>
                        </div>
                    }
                    {
                        (dataUser !== null) &&
                        <div>
                            <a className='item' onClick={showConfiguration} > Configuracion
                                <GrDocumentConfig style={{ color: 'white' }} />
                            </a><br />
                            <div id='box_configuration' onMouseLeave={hideConfiguration}>
                                <NavLink to="/" className="item"><VscDebugBreakpointData />Menu opciones</NavLink><br />
                                <NavLink to="/" className="item"><VscDebugBreakpointData />Titulos Componentes</NavLink><br />
                                <NavLink to="/" className="item"><VscDebugBreakpointData />Partners</NavLink><br />
                                <NavLink to="/" className="item"><VscDebugBreakpointData />Footer</NavLink>
                            </div>
                        </div>
                    }
                </div>
            </ul>
            <a id='btnocultaSlide' onClick={oculta} className="btn btn-warning">zz</a>
        </div>
    )
}

export default NavBar;