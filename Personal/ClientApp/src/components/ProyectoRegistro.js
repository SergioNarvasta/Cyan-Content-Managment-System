import { useState } from "react";
import { Button, Form, FormGroup,Input } from "reactstrap";

const modeloProject = {  
    id : 0,
    name :"",
    description :"",
    link:"",
}

const ProyectoRegistro = () =>{
   const [project,setProject]= useState(modeloProject);
        
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
    <Form>
        <h2 className="text-center">Registra Proyecto</h2> <hr/>
          
        <Button id="btn_gen" onClick={enviarDatos}>Registrar</Button>
  
                <FormGroup className="d-flex flex-row fg-tit">
                  <label>Nombre de Proyeco</label>
                  <Input id="form-titulo" name="name" onChange={(e) => actualizaDato(e) } value={project.name}></Input>
               </FormGroup>
                <div className="d-flex flex-row fg-box2">
                   <FormGroup className="d-flex flex-row">
                     <label>Description</label>
                     <Input id="form-nroDoc" name="description" onChange={(e) => actualizaDato(e) } value={project.description}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <label>Link</label>
                     <Input id="form-tipodoc" name="link" onChange={(e) => actualizaDato(e) } value={project.link}></Input>
                   </FormGroup>                  
                </div>
    </Form>
   )
}

export default ProyectoRegistro;