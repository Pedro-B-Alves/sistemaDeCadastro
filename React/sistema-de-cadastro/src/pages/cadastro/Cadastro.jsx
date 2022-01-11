import "../../assets/CSS/Cadastro.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState } from 'react';
import { toast } from "react-toastify";
import { api } from "../../services/api";

export default function Cadastro() {
    const [ nome, setNome ] = useState( '' );
    const [ dataNasc, setDataNasc ] = useState( new Date() );
    const [ sexo, setSexo ] = useState( '' );
    const [ mensagem, setMesagem ] = (2);

    const cadastrarUsuario = async (e) => {
        e.preventDefault();
        console.log(nome);
        console.log(dataNasc);
        console.log(sexo);
        
        const { status } = await api.post('/api/Usuarios', {
            nome : nome,
            idade : dataNasc,
            sexo : sexo
        })
        if (status === 201) {
            console.log("Usuário foi cadastrado");
        }else{
            console.log("Usuário não foi cadastrado")
        }
    };

    return (
        <div className="tela">
            <Cabecalho/>
            <section>
                <form className="formCadastro" id="form" onSubmit={cadastrarUsuario}>
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
                            <option value="" selected>Selecione um valor</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Outros">Outros</option>
                        </select>
                    </div>
                    <button className="botaoCadastro" type="submit">Cadastrar</button>
                </form>
            </section>
            <Rodape/>
        </div>
    )
}