import { useEffect, useState } from "react";
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css';

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
    <Swiper
      spaceBetween={50}
      slidesPerView={3}
      onSlideChange={() => console.log('slide change')}
      onSwiper={(swiper) => console.log(swiper)}
    >
      {skills.map((item) => (
        <SwiperSlide key={item.skill_Id}>  
          <img src={item.skill_URLImagen} width={180} height={170} />
        </SwiperSlide>
      ))
      }

    </Swiper>

  )
}
export default SkillListado;