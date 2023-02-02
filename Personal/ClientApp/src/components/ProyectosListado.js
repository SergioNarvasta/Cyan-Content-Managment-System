import { useEffect, useState } from "react";
import { Card, CardBody, CardHeader, Col, Container, Row} from "reactstrap";
import ProyectosInfo from "./ProyectosInfo";

const ProyectosListado = () =>{
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

const IrGestion = () =>{
  if(document.getElementById("psd").value == '0024.'){
    document.getElementById("LnReg").click();
  }
}
 
  return (
    <Container>
      <Row className="mt-5">
        <Col>
        <Card>
          <CardHeader>
            <h5>Proyectos Realizados</h5>
            <p>Descripcion</p>
          </CardHeader>
          <CardBody>
            <hr/><hr/>
            <ProyectosInfo data={proyectos}></ProyectosInfo>
            <hr></hr>
            <input  id="psd" type="text"></input>
            <button id="btn_new" onClick={IrGestion}> Nuevo Proyecto</button>
          </CardBody>
        </Card>
        </Col>
      </Row>
    </Container>
  )
}

export default ProyectosListado;