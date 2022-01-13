import "../../assets/CSS/Listagem.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState, useEffect } from 'react';
import { api } from "../../services/api";
import lixo from "../../assets/img/lixo.svg";
import anotacao from "../../assets/img/anotacao.svg"
import moment from "moment";

export default function Listagem() {
    const [ listagem, setListagem ] = useState( [] );
    const [ data, setData]  = useState( new Date() );
    const [ usuario, setUsuario] = useState( [] );
    const [show, setShow] = useState(false);

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

    const excluirUsuario = async () => {
        try{
            const { status } = await api.delete(`/api/Usuarios/${usuario.id}`)
            if (status === 204) {
                console.log("O usuário foi excluido com sucesso");
                listarUsuarios();
            }else{
                console.log("Não foi possivel excluir o usuário");
            }
        }catch{
            console.log("Não foi possivel excluir o usuário");
        }
    };
    
    const handleModalClose = (e) => {
        const currentClass = e.target.className;

        if (currentClass === 'modal-card') {
            return;
        }

        setShow(false);
    }

    const handleModalOpen = () => {
        setShow(true);
    }

    useEffect(() => {
        listarUsuarios();
    }, []);

    const excluirClick = (itensListagem) => {
        handleModalOpen();
        setUsuario(itensListagem);
    };

    return (
        <div className="tela">
            <Cabecalho/>
            <section>
                <div hidden={!show}>
                    <div className="modal-background" onClick={handleModalClose}>
                        <div className="modal-card">
                            <h1 className="tituloExcluir">Deseja deletar esse usuário?</h1>
                            <div>
                                <div className="areaAtributos">
                                    <p className="atributoExcluir">Nome: </p>
                                    <p className="dadosExcluir">{usuario.nome}</p>
                                </div>
                                <div className="areaAtributos">
                                    <p className="atributoExcluir">Data de Nascimento: </p>
                                    <p className="dadosExcluir">{moment(usuario.idade).format('DD/MM/YYYY')}</p>
                                </div>
                                <div className="areaAtributos">
                                    <p className="atributoExcluir">Sexo: </p>
                                    <p className="dadosExcluir">{usuario.sexo}</p>
                                </div>
                            </div>
                            <div className="areaBt">
                                <button className="btNao" onClick={handleModalClose}>Não</button>
                                <button className="btSim" onClick={() => excluirUsuario()}>Sim</button>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </section>
            <section>
                <div className="conteudo">
                <h1 className="tituloListagem">Listagem</h1>
                    <table className="tabelaListagem">
                        <thead>
                            <tr>
                                <th className="nomeAtribu">Nome</th>
                                <th className="nomeAtribu">Idade</th>
                                <th className="nomeAtribu">Sexo</th>
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
                                            <img src={lixo} alt="excluir" onClick={() => excluirClick(itensListagem)}/></td>
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