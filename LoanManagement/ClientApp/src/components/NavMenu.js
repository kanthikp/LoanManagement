import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
    <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
            <Navbar.Brand>
                <Link to={'/'}>LoanManagement</Link>
            </Navbar.Brand>
            <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
            <Nav>
                <LinkContainer to={'/'} exact>
                    <NavItem>
                        <Glyphicon glyph='home' /> Home
                    </NavItem>
                </LinkContainer>
               
                <LinkContainer to={'/users/1/loans'}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> User1 Loans
                    </NavItem>
                </LinkContainer>
                <LinkContainer to={'/users/2/loans'}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> User2 Loans
                    </NavItem>
                </LinkContainer>
                <LinkContainer to={'/users/3/loans'}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> User3 Loans
                    </NavItem>
                </LinkContainer>
                <LinkContainer to={'/users/4/loans'}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> User4 Loans
                    </NavItem>
                </LinkContainer>
            </Nav>
        </Navbar.Collapse>
    </Navbar>
);
