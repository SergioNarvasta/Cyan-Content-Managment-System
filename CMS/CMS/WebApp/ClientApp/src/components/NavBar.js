import React, { useState, useEffect } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { FaUserAlt } from "react-icons/fa";
import { AiOutlineArrowDown } from "react-icons/ai";
import { FcDataConfiguration } from "react-icons/fc";
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
                            <NavLink tag={Link} className=" item" to="/" >
                                <FaUserAlt style={{ fontSize: '23px', marginRight: '5px' }} /> {dataUser.user_Nombre}
                            </NavLink><br />
                            <NavLink tag={Link} className="item" to="/perfil" >Perfil</NavLink><br />
                            <NavLink tag={Link} className="item" to="/" onClick={cerrarSession}>Cerrar Sesion</NavLink>
                        </div>
                    }
                    <hr className="sidebar-divider" />
                    {
                        (dataUser !== null) &&
                        <div className=" py-2 collapse-inner rounded">
                            <a className='item'>Administracion <FcDataConfiguration style={{ fontsize: '35px',color: 'white' }}/> </a><br />
                            <NavLink to="/companies" className="collapse-item item">Compañia</NavLink><br />

                            {
                                (dataUser.rol_Pk === "1") &&
                                <NavLink to="/user" className="collapse-item item">Usuarios</NavLink>
                            }
                        </div>
                    }
                    {
                        (dataUser !== null) &&
                        <div className=" py-2 collapse-inner rounded" >
                            <a className='item' onClick={showComponents} >Componentes
                                <AiOutlineArrowDown style={{ color: 'white' }} />
                            </a> <br />
                            <div id='box_components' onMouseOut={hideComponents}>
                                <NavLink className="collapse-item item" to="/slidermain">SliderMain</NavLink><br />
                                <NavLink className="collapse-item item" to="/contentmain">ContentMain</NavLink><br />
                                <NavLink className="collapse-item item" to="/aside">Aside</NavLink><br />
                                <NavLink className="collapse-item item" to="/content-sec">ContentSec</NavLink>
                            </div>
                        </div>
                    }
                    {
                        (dataUser !== null) &&
                        <div className=" py-2 collapse-inner rounded">
                            <p className='item'>Configuracion</p>
                            <NavLink to="/" className="collapse-item item">Menu opciones</NavLink><br />
                            <NavLink to="/" className="collapse-item item">Titulos Componentes</NavLink><br />
                            <NavLink to="/" className="collapse-item item">Partners</NavLink><br />
                            <NavLink to="/" className="collapse-item item">Footer</NavLink>
                        </div>
                    }

                </div>
            </ul>
            <a id='btnocultaSlide' onClick={oculta} className="btn btn-warning">zz</a>
        </div>
    )
}

export default NavBar;