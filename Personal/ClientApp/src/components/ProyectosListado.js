import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardHeader, Col, Container, Row} from "reactstrap";
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

const IrRegistro = () =>{
  document.getElementById("LnReg").click();
}
 
  return (
    <Container>
      <Row className="mt-5">
        <Col>
        <Card>
          <CardHeader>
            <h5>Proyectos Realizados</h5>
          </CardHeader>
          <CardBody>
            <Button id="btn_new" onClick={IrRegistro}> Nuevo Recibo</Button>
            <hr/><hr/>
            <ProyectosInfo data={proyectos}></ProyectosInfo>
          </CardBody>
        </Card>
        </Col>
      </Row>
    </Container>
  )
}

export default ProyectosListado;