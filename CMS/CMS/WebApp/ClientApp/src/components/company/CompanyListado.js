import { useEffect, useState } from "react";
import './Style.css';
import RegistrosInCard from './RegistrosInCard';

const modelo_user = {
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
const CompanyListado = () => {
    const [company, setCompany] = useState([]);
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo_user)

    const Listar = async () => {
        const response = await fetch("/api/company/listatodos");
        if (response.ok) {
            const data = await response.json();
            setCompany(data);
        } else {
            console.log("Error : (api/company/listatodos)")
        }
    }
    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
        Listar()
    }, [])

    return (
        <div>
            {
                (dataUser.rol_Pk === "1") &&
                <RegistrosInCard data={company}></RegistrosInCard>
            }
        </div>


    )
}
export default CompanyListado;