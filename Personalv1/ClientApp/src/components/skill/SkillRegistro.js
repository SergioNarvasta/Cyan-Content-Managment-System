import { useEffect,useState } from "react";
import { Form, FormGroup,Input,Button } from "reactstrap";
import ProyectosTabla from "./ProyectosEnTabla";
import ArchivoOld from "../archivo/ArchivoOld";
import './Proyectos.css';

const modeloSkill = {  
  skill_Nombre :"",
  skill_Version :"",
  skill_URLImagen:"",
  skill_URLDrive : "",
  aud_UsuCre : "",
  aud_FecCre : "",
  aud_UsuAct : "",
  aud_FecAct : ""
}

const ProyectoRegistro = () =>{
   const [skillList,setSkillList]= useState([]);
   const [skillCreate,setSkillCreate] = useState(modeloSkill);
  
   const ListarSkills = async () => {
     const response = await fetch("/api/skill");
     if(response.ok){
       const data = await response.json();
       setSkillList(data);
     }else{
       console.log("Error al listar (/api/skill)")
     }
   }
   useEffect(()=>{
    ListarSkills()
  },[])
   const actualizaDato = (e) => {
     console.log(e.target.name+" : "+ e.target.value);
     setSkillCreate(
        {
            ...skillCreate,
            [e.target.name] : e.target.value
        }
     )
   }
   const enviarDatos = () => {
        guardarProject(skillCreate)
    
   }
   const guardarProject = async (skillCreate) =>{
       const response = await fetch("api/skill/createSkill",{
      method:'POST',
      headers: {
         'Content-Type':'application/json'
      },
      body:JSON.stringify(skillCreate)
    })
    if(response.ok){
        console.log("Registrado con exito");
        //document.getElementById("LnList").click();
    }
   }
   return(   
    <div>
    <Form id="form-registro">
        <h2 className="text-center">Gestion de Skills</h2> <hr/>    
        <Button id="btn_gen" onClick={enviarDatos} >Registrar</Button> <hr/> 
        <FormGroup className="d-flex flex-row ">
          <label>Nombre de Proyecto</label>
          <Input id="form-name" name="name" onChange={(e) => actualizaDato(e) } value={project.name}></Input>
        </FormGroup>            
        <FormGroup className="d-flex flex-row">
          <label>Descripcion</label>
          <Input id="form-desc" name="description" onChange={(e) => actualizaDato(e) } value={project.description}></Input>
        </FormGroup>
        <FormGroup className="d-flex flex-row">
          <label>Link del Proyecto</label>
          <Input id="form-link" name="link" onChange={(e) => actualizaDato(e) } value={project.link}></Input>
        </FormGroup>
        <Input type="file" name="files"  multiple 
            onChange={(e)=>subirArchivos(e)} > </Input> 
        
    </Form>
    <ArchivoOld/>
    <ProyectosTabla data={proyectos}></ProyectosTabla>
    </div>
   )
}

export default ProyectoRegistro;