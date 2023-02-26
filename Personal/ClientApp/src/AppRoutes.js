
import { Home } from "./components/Home";
import ProyectosListado from "./components/proyecto/ProyectosListado";
import ProyectoRegistro from "./components/proyecto/ProyectoRegistro";
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
];

export default AppRoutes;
