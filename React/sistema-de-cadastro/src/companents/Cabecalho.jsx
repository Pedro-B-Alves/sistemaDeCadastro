import React, {Component} from "react";
import "../assets/CSS/Cabecalho.css";
import logo from "../assets/img/logo.svg";
import { Link } from 'react-router-dom';

export default class Cabecalho extends Component {
    render() {
        return(
            <div className="cabecalho">
                <div className="conteudoCabecalho">
                    <img className="imgCabecalho" src={logo} alt="intelitrader"/>
                    <div className="areaLink">
                        <Link className="linkCabecalho" to="/">Cadastro</Link>
                        <Link className="linkCabecalho" to="/Listagem">Listagem</Link>
                    </div>
                </div>
            </div>
        )
    }
}