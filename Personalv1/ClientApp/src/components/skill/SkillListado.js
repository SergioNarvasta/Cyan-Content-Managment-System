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
      {skills.map((item) => (
        <div key={item.skill_Id}> 
        
          <img src={item.skill_URLImagen} width={200} height={170} />
       
        </div>
      ))
      }
      </div>

   

  )
}
export default SkillListado;