import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import NavItems from './NavItems';

export class NavMenu extends Component {

  static displayName = NavMenu.name;

  constructor(props) {
    super(props);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }
  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">CMS</NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse center " isOpen={!this.state.collapsed} navbar>
            <NavItems/>
          </Collapse>
        </Navbar>
      </header>
    );
  }
}
