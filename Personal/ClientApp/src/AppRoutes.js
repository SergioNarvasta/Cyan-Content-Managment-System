
import { Home } from "./components/Home";
import ProyectosListado from "./components/ProyectosListado";
import ProyectoRegistro from "./components/ProyectoRegistro";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/proyectos',
    element: <ProyectosListado/>
  },
  {
    path: '/registro',
    element: <ProyectoRegistro />
  },

];
export default AppRoutes;
