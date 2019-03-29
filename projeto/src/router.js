import Vue from 'vue';
import Router from 'vue-router'
import Funcionarios from './components/Funcionario/Funcionarios'
import FuncionarioDetalhe from './components/Funcionario/FuncionarioDetalhe'
import Cargos from './components/Cargo/Cargos'

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/cargos',
            nome: 'cargos',
            component: Cargos
        },
        {
            path: '/funcionarios/:cargo_id',
            nome: 'Funcionarios',
            component: Funcionarios
        },
        {
            path: '/todosFuncionarios',
            nome: 'Funcionarios',
            component: Funcionarios
        },
        {
            path: '/funcionarioDetalhe/:id',
            nome: 'FuncionarioDetalhe',
            component: FuncionarioDetalhe
        }
    ]
})