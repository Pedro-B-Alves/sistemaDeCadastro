import React, {Component} from "react";
import "../assets/CSS/Cabecalho.css";
import logo from "../assets/img/logo.svg"

export default class Cabecalho extends Component {
    render() {
        return(
            <div className="cabecalho">
                <div className="conteudoCabecalho">
                    <img className="imgCabecalho" src={logo} alt="intelitrader"/>
                    <div className="areaLink">
                        <a className="linkCabecalho">Cadastro</a>
                        <a className="linkCabecalho">Listagem</a>
                    </div>
                </div>
            </div>
        )
    }
}