import React, { useContext, useState, useEffect } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { UserContext } from './context/UserProvider';

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

const NavItems = () => {
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo)

    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
    }, [])

    return (
        <ul className="navbar-nav flex-grow">
            <NavItem>
                <NavLink tag={Link} className="text-dark" to="/slider-main">SliderMain</NavLink>
            </NavItem>
            <NavItem>
                <NavLink tag={Link} className="text-dark" to="/user">Usuarios</NavLink>
            </NavItem>
            <NavItem>
                <NavLink tag={Link} className="text-dark" to="/compania">Compañia</NavLink>
            </NavItem>
            {
                (dataUser.user_Pk === "") &&
                <NavItem >
                    <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                </NavItem>

            }
            {
                (dataUser.user_Nombre !== "") &&
                <NavItem >
                    <NavLink tag={Link} className="text-dark" to="" data-toggle="collapse" data-target="#collapseUsuario">{dataUser.user_Nombre}</NavLink>

                </NavItem>

            }


        </ul>
    )
}
export default NavItems;