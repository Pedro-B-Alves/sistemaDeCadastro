import "../../assets/CSS/Listagem.css"
import Cabecalho from "../../companents/Cabecalho"
import Rodape from "../../companents/Rodape"
import React, { useState } from 'react';
import axios from 'axios';

export default function Listagem() {
    const [ nome, setNome ] = useState( '' );
    const [ dataNasc, setDataNasc ] = useState( new Date() );
    const [ sexo, setSexo ] = useState( '' );


    return (
        <div className="tela">
            <Cabecalho/>
            <section>
                
            </section>
            <Rodape/>
        </div>
    )
}