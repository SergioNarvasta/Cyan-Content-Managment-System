import { useEffect, useState } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import { Table } from "reactstrap";
import './Skill.css';

const modeloSkill = {
  skill_Nombre: "",
  skill_Version: "",
  skill_URLImagen: "",
  skill_URLDrive: "",
  skill_Orden :0,
  skill_Estado :0,
  aud_UsuCre: "",
  aud_FecCre: "",
  aud_UsuAct: "",
  aud_FecAct: ""
}

const SkillRegistro = () => {
  const [skillList, setSkillList] = useState([]);
  const [skillCreate, setSkillCreate] = useState(modeloSkill);

  const ListarSkills = async () => {
    const response = await fetch("/api/skill");
    if (response.ok) {
      const data = await response.json();
      setSkillList(data);
    } else {
      console.log("Error al listar (/api/skill)")
    }
  }
  useEffect(() => {
    ListarSkills()
  }, [])
  const actualizaDato = (e) => {
    console.log(e.target.name + " : " + e.target.value);
    setSkillCreate(
      {
        ...skillCreate,
        [e.target.name]: e.target.value
      }
    )
  }
  const enviarDatos = () => {
    guardarSkill(skillCreate)

  }
  const guardarSkill = async (skillCreate) => {
    const response = await fetch("api/skill", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(skillCreate)
    })
    if (response.ok) {
      console.log("Registrado con exito");
      window.location.href = window.location.href;
      //document.getElementById("LnList").click();
    } 
  }
  const generaURLImage = ()=> {
    var userLogin = "SNarvasta";
    var URL_Drive = document.getElementById('form-urldrive').value;
    var URL_Imagen = URL_Drive.substring(32,65);
    var UrlBase = "http://drive.google.com/uc?export=view&id=";
    document.getElementById('form-urlimage').value = UrlBase+ URL_Imagen;
    setSkillCreate({
      ...skillCreate,
       skill_URLImagen:UrlBase+ URL_Imagen,
       aud_UsuCre : userLogin,
      });
    //alert(URL_Drive +'/n '+ " len : "+len +'/n '+ " URL_Imagen : "+URL_Imagen);
  }
  function UrlBase (){
    var UrlBase = "http://drive.google.com/uc?export=view&id=";
    return UrlBase;
  }
  function UrlDocumentId (){
    var UrlDocumentId = "1Jqedty_wEe_Z9Zk93ZdDZofymk-jraIz";
    return UrlDocumentId;
  }
  return (
    <div>
      <Form id="form-registro">
        <h2 className="text-center">Gestion de Skills</h2> <hr />
        <Button id="btnRegistraSkill" onClick={enviarDatos} className="btn btn-success">Registrar</Button> <hr />
        <FormGroup className="d-flex flex-row ">
          <label>Nombre Skill</label>
          <Input id="form-name" name="skill_Nombre" onChange={(e) => actualizaDato(e)}
            value={skillCreate.skill_Nombre}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>Version</label>
          <Input id="form-version" name="skill_Version" onChange={(e) => actualizaDato(e)}
            value={skillCreate.skill_Version}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>Orden</label>
          <Input id="form-version" name="skill_Orden" onChange={(e) => actualizaDato(e)}
            value={skillCreate.skill_Orden}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>URL de Imagen</label>
          <Input id="form-urlimage" name="skill_URLImagen" onChange={(e) => actualizaDato(e)}
            value={skillCreate.skill_URLImagen}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>URL de Drive Compartido</label>
          <Input id="form-urldrive" name="skill_URLDrive" onChange={(e) => actualizaDato(e)}
            value={skillCreate.skill_URLDrive}></Input>
        </FormGroup>
        <Button id="btnProcesaURL" onClick={generaURLImage} className="btn btn-primary">Procesa URL</Button>
      </Form>
      <br></br>
      <Table striped responsive className="table-bordered ">
            <thead className="table-warning">
                <tr>
                    <th>Orden </th>
                    <th>Nombre </th>
                    <th>Version</th>
                    <th>URL Drive</th>
                    <th>URL Imagen</th>  
                    <th>Vista Previa</th>                 
                </tr>
            </thead>
            <tbody>
               {
                (skillList.length < 1) ?(
                    <tr>
                        <td colSpan="8">Sin registros</td>
                    </tr>
                ):(
                  skillList.map((item) => (
                    <tr key={item.skill_Id}>
                      <td>{item.skill_Orden}</td>
                      <td>{item.skill_Nombre}</td>
                      <td>{item.skill_Version}</td>
                      <td id="td_skill_URLDrive"><textarea id="txa_skill_URLDrive">{item.skill_URLDrive}</textarea></td>
                      <td id="td_skill_URLImagen"><textarea id="txa_skill_URLImagen">{item.skill_URLImagen}</textarea></td>
                      <td><img src={item.skill_URLImagen} width={200} height={80} /></td>
                    </tr>
                    ))
                )
               }
            </tbody>
        </Table>     
    </div>
  )
}

export default SkillRegistro;