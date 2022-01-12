import "../../assets/CSS/Listagem.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState, useEffect } from 'react';
import { api } from "../../services/api";
import lixo from "../../assets/img/lixo.svg";
import anotacao from "../../assets/img/anotacao.svg"

export default function Listagem() {
    const [ listagem, setListagem ] = useState( [] );
    const [ data, setData]  = useState( new Date() );

    const listarUsuarios = async () => {
        
        try{
            const { data, status } = await api.get('/api/Usuarios')
            if (status === 200) {
                console.log("Listagem concluida com sucesso");
                setData(new Date());
                setListagem(data);
            }else{
                console.log("Não foi possivel fazer a listagem");
            }
        }catch{
            console.log("Não foi possivel fazer a listagem");
        }
    };

    useEffect(() => {
        listarUsuarios();
    }, []);

    return (
        <div className="tela">
            <Cabecalho/>
            <section>
                <div className="conteudo">
                <h1 className="tituloListagem">Listagem</h1>
                    <table className="tabelaListagem">
                        <thead>
                            <tr>
                                <th className="nomeAtributo">Nome</th>
                                <th className="nomeAtributo">Idade</th>
                                <th className="nomeAtributo">Sexo</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                               listagem.map( (itensListagem) => {
                                    return (
                                        <tr key={itensListagem.id}>
                                            <td className="colunaAtributo">{itensListagem.nome}</td>
                                            <td className="colunaAtributo">{parseInt((data-new Date(itensListagem.idade))/(1000*3600*24)/365.25)}</td>
                                            <td className="colunaAtributo">{itensListagem.sexo}</td>
                                            <td><img src={anotacao} alt="alterar"/>
                                            <img src={lixo} alt="excluir"/></td>
                                        </tr>
                                    );
                               })
                            }
                        </tbody>
                    </table>    
                </div>
            </section>
            <Rodape/>
        </div>
    )
}