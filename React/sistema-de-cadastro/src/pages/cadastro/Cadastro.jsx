import "../../assets/CSS/Cadastro.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"

export default function Cadastro() {

    return (
        <div className="tela">
            <Cabecalho/>
            <section className="conteudoCadastro">
                <form className="formCadastro">
                    <h1 className="tituloCadastro">Cadastro</h1>
                    <div>
                        <p className="nomeAtributo">Nome</p>
                        <input className="input" type="text"></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Data de Nascimento</p>
                        <input className="input" type="date"></input>
                    </div>
                    <div>
                        <p className="nomeAtributo">Sexo</p>
                        <select className="input">
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Outros">Outros</option>
                        </select>
                    </div>
                    <button className="botaoCadastro">Cadastrar</button>
                </form>
            </section>
            <Rodape/>
        </div>
    )
}