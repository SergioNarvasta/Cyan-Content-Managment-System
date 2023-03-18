
import { Home } from "./components/Home";
import SliderMainRegistro from "./components/slider-main/SliderMainRegistro";
import Login from './components/login/Login';
import UserRegistro from './components/user/UserRegistro';
import CompaniaRegistro from './components/compania/companiaRegistro';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/slider-main',
    element: <SliderMainRegistro />
    },
    {
        path: '/login',
        element: <Login />
    },
    {
        path: '/user',
        element: <UserRegistro />
    },
    {
      path: '/compania',
      element: <CompaniaRegistro/>
    }
];

export default AppRoutes;
