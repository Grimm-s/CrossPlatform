import 'bootstrap/dist/css/bootstrap.css';
import {createRoot} from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
import App from "./App";
import {Auth0Provider} from "@auth0/auth0-react";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

if (rootElement && baseUrl) {
    const root = createRoot(rootElement);

    root.render(
        <Auth0Provider
            domain="dev-vlaq6be2w7jh5elj.us.auth0.com"
            clientId="OELCkCndfitlGZOVPE6itthOLECtpBbU"
            authorizationParams={{
                redirect_uri: window.location.origin,
                audience: "https:/localhost:7054",
            }}
        >
            <BrowserRouter basename={baseUrl}>
                <App/>
            </BrowserRouter>
        </Auth0Provider>);
}



