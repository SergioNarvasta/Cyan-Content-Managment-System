import { useEffect, useState } from "react";
import RegistrosInCard from './RegistrosInCard';
import './Style.css';

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
    const [company,     setCompany]     = useState([]);
    const [companybyid, setCompanybyid] = useState([]);
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo_user)
    const userPk = user && user.user_Pk;
    const Listar = async () => {
        const response = await fetch("/api/company/listatodos");
        if (response.ok) {
            const data = await response.json();
            setCompany(data);
        } else {
            console.log("Error : api/company/listatodos")
        }
    }
    const ListarById = async () => {
        if (dataUser.user_Pk !== "") {
          const response = await fetch("api/company/listbyid", {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ user_Pk: dataUser.user_Pk })
          });      
          if (response.ok) {
            const data = await response.json();
            setCompanybyid(data);
          } else {
            console.log("Error : api/company/listbyid" + dataUser.user_Pk);
          }
        } else {
          console.log("dataUser.user_Pk is empty");
        }
      }

    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
        setDataUser(dataUser => ({
            ...dataUser,
            user_Pk :userPk
        }))
        Listar()
        ListarById()
    }, [])

    return (
        <div>
            {
                (dataUser.rol_Pk === "2") &&
                <RegistrosInCard data={companybyid}></RegistrosInCard>
            }
            {
                (dataUser.rol_Pk === "1") &&
                <RegistrosInCard data={company}></RegistrosInCard>
            }
        </div>
    )
}
export default CompanyListado;