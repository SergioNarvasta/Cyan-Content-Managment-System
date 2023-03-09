import { useEffect, useState } from "react";
import { Container } from "reactstrap";

const SkillListado = () => {
    const [skills, setSkills] = useState([]);

  const ListarSkills = async () => {
      const response = await fetch("/api/skill");
    if (response.ok) {
      const data = await response.json();
        setSkills(data);
    } else {
      console.log("Error al listar (/api/skill)")
    }
  }
  useEffect(() => {
      ListarSkills()
  }, [])

  return (
      <Container>
          <div id="ListSkills" className="d-flex flex-row">
              {skills.map((item) => (
                <div key={item.skill_Id} id="item"> <br></br>
                    <img src={item.skill_URLImagen} width={30} height={30}/>
                </div>
                ))
              }
          </div>
    </Container>
  )
}
export default SkillListado;