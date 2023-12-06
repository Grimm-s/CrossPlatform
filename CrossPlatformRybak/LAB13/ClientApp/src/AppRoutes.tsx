import Lab1 from "./components/Lab1";
import Lab2 from "./components/Lab2";
import Lab3 from "./components/Lab3";
import Home from "./components/Home";

const AppRoutes = [
    {
        index: true,
        path: '/',
        element: <Home/>,
        secure: false
    },
    {
        path: '/profile',
        element: <Home/>,
        secure: true
    },
    {
        path: '/lab1',
        element: <Lab1/>,
        secure: true
    },
    {
        path: '/lab2',
        element: <Lab2/>,
        secure: true
    },
    {
        path: '/lab3',
        element: <Lab3/>,
        secure: true
    },

];

export default AppRoutes;
