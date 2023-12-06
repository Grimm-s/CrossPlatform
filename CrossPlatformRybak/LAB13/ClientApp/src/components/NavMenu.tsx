import React, {useState, useCallback} from 'react';
import {Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Button} from 'reactstrap';
import {Link} from 'react-router-dom';
import './NavMenu.css';
import {useAuth0} from "@auth0/auth0-react";

const NavMenu: React.FC = () => {
    const {loginWithRedirect, logout, isLoading, isAuthenticated} = useAuth0();
    const [collapsed, setCollapsed] = useState(true);

    const toggleNavbar = useCallback(() => {
        setCollapsed(!collapsed);
    }, [collapsed]);

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container
                    light>
                <NavbarBrand tag={Link} to="/">LAB13 Rybak</NavbarBrand>
                <NavbarToggler onClick={toggleNavbar} className="mr-2"/>
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                        </NavItem>
                        {
                            isAuthenticated && !isLoading ? (
                                <>
                                <NavItem>
                                    <NavLink className="text-dark">Profile</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/lab1">Lab 1</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/lab2">Lab 2</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/lab3">Lab 3</NavLink>
                                </NavItem>
                                <NavItem>
                                    <Button color="danger" onClick={() => logout()}>Logout</Button>
                                </NavItem>
                                </>
                            ) : (
                                <NavItem>
                                    <Button color="primary" onClick={() => loginWithRedirect()}>Login</Button>
                                </NavItem>
                            )
                        }
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
};

export default NavMenu;
