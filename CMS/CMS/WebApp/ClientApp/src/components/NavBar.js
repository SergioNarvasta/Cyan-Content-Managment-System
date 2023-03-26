﻿import React, { useState, useEffect } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { FaUserAlt } from "react-icons/fa";
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
    return (
        <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
            <Link className="sidebar-brand d-flex align-items-center justify-content-center item" to="/">
                <div className="sidebar-brand-icon">
                </div>
                <div className="sidebar-brand-text mx-3" id='titleMain'><p>Sistema de Gestion de Contenido - CMS</p></div>
            </Link>
            <div id='sidebar_options'>
                {
                    (dataUser === null) &&
                    <NavLink tag={Link} className="text-dark item" to="/login">Inicie Sesion</NavLink>
                }
                {
                    (dataUser !== null) &&
                    <NavLink tag={Link} className=" item" to="" ><FaUserAlt style={{ fontSize: '25px',marginRight:'5px'}}/> {dataUser.user_Nombre}</NavLink>
                }

                <hr className="sidebar-divider my-0" />


                <hr className="sidebar-divider" />
                {
                    (dataUser !== null) &&
                    <div className=" py-2 collapse-inner rounded">
                        <p className='item'>Administracion</p>
                        <NavLink to="/companies" className="collapse-item item">Compañia</NavLink><br/>
                        {
                            (dataUser.rol_Pk === "2") &&
                            <NavLink to="/user" className="collapse-item item">Usuarios</NavLink>
                        }                   
                       

                    </div>
                }

                {
                    (dataUser !== null) &&
                    <div className=" py-2 collapse-inner rounded">
                    <p className='item'>Componentes</p>
                        <NavLink className="collapse-item item" to="/slider-main">SliderMain</NavLink>
                    </div>
                }

                <hr className="sidebar-divider d-none d-md-block" />

                <div className="text-center d-none d-md-inline">
                    <button className="rounded-circle border-0" id="sidebarToggle"></button>
                </div>

            </div>


        </ul>
    )
}

export default NavBar;