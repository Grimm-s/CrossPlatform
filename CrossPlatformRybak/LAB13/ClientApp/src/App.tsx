import React from 'react';
import {Route, Routes} from 'react-router-dom';
import AppRoutes from './AppRoutes';
import {Layout} from './components/Layout';
import './App.css';
import ProtectedRoute from "./components/ProtectedRoute";

const App: React.FC = () => {
    return (
        <Layout>
            <Routes>
                {AppRoutes.map((route, index) => {
                    const {element, secure, ...rest} = route;
                    return <Route key={index} {...rest} element={secure ? <ProtectedRoute>{element}</ProtectedRoute> : element}/>;
                })}
            </Routes>
        </Layout>
    );
};

export default App;
