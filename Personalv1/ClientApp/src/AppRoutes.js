
import { Home } from "./components/Home";
import ProyectosListado from "./components/proyecto/ProyectosListado";
import ProyectoRegistro from "./components/proyecto/ProyectoRegistro";
import SkillRegistro from './components/skill/SkillRegistro';
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/proyectos',
    element: <ProyectosListado />
  },
  {
    path: '/registro',
    element: <ProyectoRegistro />
  },
  {
    path: '/skill',
    element: <SkillRegistro />
  }
];

export default AppRoutes;
