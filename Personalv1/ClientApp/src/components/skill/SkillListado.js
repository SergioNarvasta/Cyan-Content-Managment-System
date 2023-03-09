import { useEffect, useState } from "react";

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

    <div>
      <h5>Tecnologías</h5>
      <div className="d-flex flex-row">
        {skills.map((item) => (
          <div key={item.skill_Id}>
            <img src={item.skill_URLImagen} width={150} height={100} />
          </div>
        ))
        }
      </div>
    </div>



  )
}
export default SkillListado;