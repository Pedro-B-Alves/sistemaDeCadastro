import "../../assets/CSS/Cadastro.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState } from 'react';
import moment from "moment";
import { api } from "../../services/api";

export default function Cadastro() {
    const [ nome, setNome ] = useState( '' );
    const [ dataNasc, setDataNasc ] = useState( new Date() );
    const [ sexo, setSexo ] = useState( '' );
    const [ mensagem, setMesagem ] = useState(2);
    const [show, setShow] = useState(false);

    const cadastrarUsuario = async () => {
        console.log(nome);
        console.log(dataNasc);
        console.log(sexo);
        
        try{
            const { status } = await api.post('/api/Usuarios', {
                nome : nome,
                idade : dataNasc,
                sexo : sexo
            })
            if (status === 201) {
                console.log("Usuário foi cadastrado");
                setMesagem(1);
            }else{
                console.log("Usuário não foi cadastrado");
                setMesagem(0);
            }
        }catch{
            console.log("Usuário não foi cadastrado");
            setMesagem(0);
        }
    };

    const handleModalClose = (e) => {
        const currentClass = e.target.className;

        if (currentClass === 'modalCard') {
            return;
        }
        else if (currentClass === 'titulo') {
            return;
        }
        else if (currentClass === 'atributoCadastro') {
            return;
        }
        else if (currentClass === 'dadosCadastro') {
            return;
        }

        setShow(false);
    }

    const handleModalOpen = (e) => {
        e.preventDefault();
        setShow(true);
    }

    return (
        <div className="tela">
            <Cabecalho/>
            <section>
                <div hidden={!show}>
                    <div className="modalBackground" onClick={handleModalClose}>
                        <div className="modalCard">
                            <h1 className="titulo">Os dados estão corretos?</h1>
                            <div>
                                <div className="areaDosAtributos">
                                    <p className="atributoCadastro">Nome: </p>
                                    <p className="dadosCadastro">{nome}</p>
                                </div>
                                <div className="areaDosAtributos">
                                    <p className="atributoCadastro">Data de Nascimento: </p>
                                    <p className="dadosCadastro">{moment(dataNasc).format('DD/MM/YYYY')}</p>
                                </div>
                                <div className="areaDosAtributos">
                                    <p className="atributoCadastro">Sexo: </p>
                                    <p className="dadosCadastro">{sexo}</p>
                                </div>
                            </div>
                            <div className="areaBotao">
                                <button className="botaoNao" onClick={handleModalClose}>Não</button>
                                <button className="botaoSim" onClick={() => cadastrarUsuario()}>Sim</button>
                            </div>   
                        </div>
                    </div>
                </div>
            </section>
            <section>
                <form className="formCadastro" id="form" onSubmit={handleModalOpen}>
                    <h1 className="tituloCadastro">Cadastro</h1>
                    <div>
                        <p className="nomeAtributo">Nome</p>
                        <input className="input"  type="text" name="Nome" required value={nome} onChange={(event) => setNome(event.target.value)}></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Data de Nascimento</p>
                        <input className="input" type="date" name="Data" required value={dataNasc} onChange={(event) => setDataNasc(event.target.value)}></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Sexo</p>
                        <select className="input" name="Sexo" required value={sexo} onChange={(event) => setSexo(event.target.value)}>
                            <option value="" defaultValue>Selecione um valor</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Outros">Outros</option>
                        </select>
                    </div>
                    {
                        mensagem === 1 &&
                        <p className="sucesso">O usuário foi cadastrado com sucesso</p>
                    }
                    {
                        mensagem === 0 &&
                        <p className="falha">O usuário não foi cadastrado</p>
                    }
                    <button className="botaoCadastro" type="submit">Cadastrar</button>
                </form>
            </section>
            <Rodape/>
        </div>
    )
}