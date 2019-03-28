<template>
  <div >
    <titulo texto="Funcionários"/>
    <div>
      <input type="text" placeholder="Nome do Funcionário" v-model="nome" @keyup.enter="addFuncionario()">
      <button class="btn btnInput" @click="addFuncionario()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="funcionarios.length">
        <tr v-for="(funcionario, index) in funcionarios" :key="index">
          <td>{{funcionario.id}}</td>
          <td>{{funcionario.nome}} {{funcionario.sobrenome}}</td>
          <td>
            <button class="btn btn_Danger" @click="remover(funcionario)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum funcionário encontrado.
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components:{
    Titulo
  },
  data(){
    return{
    nome: '',
    funcionarios: []
    }
  },
  created() {
    this.$http
      .get('http://localhost:3000/funcinarios')
      .then(res => res.json())
      .then(funcionarios => this.funcionarios = funcionarios)
  },
  props: {
    
  },
  methods: {
    addFuncionario() {
      let _funcionario = {
        nome: this.nome,
        sobrenome: ""
      }
      this.$http
        .post('http://localhost:3000/funcinarios', _funcionario)
        .then(res => res.json())
        .then(funcionario => {
          this.funcionarios.push(funcionario);
          this.nome = '';
        })
    },
    remover(funcionario){
      this.$http
        .delete(`http://localhost:3000/funcinarios/${funcionario.id}`)
        .then(() => {
          let indice = this.funcionarios.indexOf(funcionario);
          this.funcionarios.splice(indice, 1);
        }) 
    }
  },
}
</script>

<style scoped>
input {
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput{
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 155);
  display: inline;
}
.btnInput:hover{
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
