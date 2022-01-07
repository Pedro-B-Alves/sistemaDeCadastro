import "../../assets/CSS/Cadastro.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState } from 'react';
import axios from 'axios';

export default function Cadastro() {
    const [ nome, setNome ] = useState( '' );
    const [ dataNasc, setDataNasc ] = useState( new Date() );
    const [ sexo, setSexo ] = useState( '' );

    function cadastrarUsuario(event){
        event.preventDefault();
        console.log(nome);
        console.log(dataNasc);
        console.log(sexo);

        axios.post('http://localhost:5000/api/Usuarios', {
            nome : nome,
            idade : dataNasc,
            sexo : sexo
        })
        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Usuário cadastrado!');
            }
        })

        .catch(erro => console.log(erro));
    };

    return (
        <div className="tela">
            <Cabecalho/>
            <section className="conteudoCadastro">
                <form className="formCadastro" id="form" onSubmit={cadastrarUsuario}>
                    <h1 className="tituloCadastro">Cadastro</h1>
                    <div>
                        <p className="nomeAtributo">Nome</p>
                        <input className="input"  type="text" name="nome" required value={nome} onChange={(event) => setNome(event.target.value)}></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Data de Nascimento</p>
                        <input className="input" type="date" name="data de nascimento" required value={dataNasc} onChange={(event) => setDataNasc(event.target.value)}></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Sexo</p>
                        <select className="input" name="sexo" required value={sexo} onChange={(event) => setSexo(event.target.value)}>
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