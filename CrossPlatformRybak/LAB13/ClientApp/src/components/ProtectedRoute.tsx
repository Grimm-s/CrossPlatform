import React, {FC, PropsWithChildren} from 'react';
import {Navigate} from 'react-router-dom';
import {useAuth0} from "@auth0/auth0-react";


const ProtectedRoute: FC<PropsWithChildren> = (props) => {
    const {isAuthenticated} = useAuth0();
    return <>{isAuthenticated ? props.children : <Navigate to="/" replace/>}</>;
}

export default ProtectedRoute;
