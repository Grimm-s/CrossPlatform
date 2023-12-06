import React, { FC, PropsWithChildren} from 'react';
import { Container } from 'reactstrap';
import  NavMenu  from './NavMenu';

export const Layout: FC<PropsWithChildren> = (props) => {
    return (
        <div>
            <NavMenu />
            <Container tag="main">
                {props.children}
            </Container>
        </div>
    )
}