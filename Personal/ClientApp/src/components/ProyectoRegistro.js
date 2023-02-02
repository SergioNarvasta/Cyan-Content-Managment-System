import { useEffect,useState } from "react";
import { Form, FormGroup,Input,Button } from "reactstrap";
import ProyectosTabla from "./ProyectosEnTabla";
import './Proyectos.css';

const modeloProject = {  
    name :"",
    description :"",
    link:"",
}

const ProyectoRegistro = () =>{
   const [project,setProject]= useState(modeloProject);
   const [proyectos,setProyectos] = useState([]);
  
   const ListarProyectos = async () => {
     const response = await fetch("/api/project");
 
     if(response.ok){
       const data = await response.json();
       setProyectos(data);
       //console.log(data);
     }else{
       console.log("Error al listar (/api/recibos)")
     }
   }
   useEffect(()=>{
    ListarProyectos()
  },[])

  //********** REGISTRO  ************* */

   const actualizaDato = (e) => {
     console.log(e.target.name+" : "+ e.target.value);
     setProject(
        {
            ...project,
            [e.target.name] : e.target.value
        }
     )
   }
   const enviarDatos = () => {
        guardarProject(project)
    
   }
   const guardarProject = async (project) =>{
    const response = await fetch("api/project",{
      method:'POST',
      headers: {
         'Content-Type':'application/json;charset=utf-8'
      },
      body:JSON.stringify(project)
    })
    if(response.ok){
        console.log("Registrado con exito");
        document.getElementById("LnList").click();
    }
   }
   
   return(   
    <div>
    <Form id="form-registro">
        <h2 className="text-center">Gestion de Proyectos Registrados</h2> <hr/>    
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
    </Form>
    <ProyectosTabla data={proyectos}></ProyectosTabla>
    </div>
   )
}

export default ProyectoRegistro;