import { useState } from "react";
import { Button, Form, FormGroup,Input } from "reactstrap";

const modeloRecibo = {  
    id : 0,
    name :"",
    description :"",
    link:"",
}

const ProyectoRegistro = () =>{
   const [recibo,setrecibo]= useState(modeloRecibo);
        
   const actualizaDato = (e) => {
     console.log(e.target.name+" : "+ e.target.value);
     setrecibo(
        {
            ...recibo,
            [e.target.name] : e.target.value
        }
     )
   }
   const enviarDatos = () => {
        guardarRecibo(recibo)
    
   }
   const guardarRecibo = async (recibo) =>{
    const response = await fetch("api/project",{
      method:'POST',
      headers: {
         'Content-Type':'application/json;charset=utf-8'
      },
      body:JSON.stringify(recibo)
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
                  <Input id="form-titulo" name="titulo" onChange={(e) => actualizaDato(e) } value={recibo.name}></Input>
               </FormGroup>
                <div className="d-flex flex-row fg-box2">
                   <FormGroup className="d-flex flex-row">
                     <label>Description</label>
                     <Input id="form-nroDoc" name="nroDoc" onChange={(e) => actualizaDato(e) } value={recibo.description}></Input>
                   </FormGroup>
                   <FormGroup className="d-flex flex-row">
                     <label>Link</label>
                     <Input id="form-tipodoc" name="tipoDoc" onChange={(e) => actualizaDato(e) } value={recibo.link}></Input>
                   </FormGroup>                  
                </div>
    </Form>
   )
}

export default ProyectoRegistro;