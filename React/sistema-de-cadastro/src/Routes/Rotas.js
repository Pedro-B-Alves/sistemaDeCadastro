import React from "react";
import { Routes,Route, BrowserRouter } from "react-router-dom";

import Cadastro from "../pages/cadastro/Cadastro";
import Listagem from "../pages/listagem/Listagem";

const Rotas = () => {
   return(
       <BrowserRouter>
           <Routes>
            <Route element = { <Cadastro/> }  path="/" exact />
            <Route element = { <Listagem/> }  path="/listagem" />
           </Routes>
       </BrowserRouter>
   )
}

export default Rotas;