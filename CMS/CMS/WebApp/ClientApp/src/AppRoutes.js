
import { Home } from "./components/Home";
import  SliderMainRegistro  from "./components/content-main/SliderMainRegistro";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/slider-main',
    element: <SliderMainRegistro />
  }
];

export default AppRoutes;
