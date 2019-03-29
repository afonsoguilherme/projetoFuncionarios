<template>
  <div >
    <titulo :texto="cargoid != undefined ? 'Cargo: ' + cargo.cargo : 'Todos os Funcionários'"/>
    <div v-if="cargoid != undefined">
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
          <td class="colPequeno" style="text-align: center; width: 15%">{{funcionario.id}}</td>
          <router-link :to="`/funcionarioDetalhe/${funcionario.id}`" tag="td" style="cursor: pointer">
            {{funcionario.nome}} {{funcionario.sobrenome}}
          </router-link>
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
    cargoid: this.$route.params.cargo_id,
    cargo: {},
    nome: '',
    funcionarios: []
    }
  },
  created() {
    if(this.cargoid){
      this.carregarCargos();
      this.$http
      .get("http://localhost:3000/funcionarios?cargo.id=" + this.cargoid)
      .then(res => res.json())
      .then(funcionarios => this.funcionarios = funcionarios)
    }else{
      this.$http
      .get("http://localhost:3000/funcionarios")
      .then(res => res.json())
      .then(funcionarios => this.funcionarios = funcionarios)
    }
  },
  props: {
    
  },
  methods: {
    addFuncionario() {
      let _funcionario = {
        nome: this.nome,
        sobrenome: "",
        cargo:{
          id: this.cargo.id,
          cargo: this.cargo.cargo
        }
      }
      this.$http
        .post("http://localhost:3000/funcionarios", _funcionario)
        .then(res => res.json())
        .then(funcionario => {
          this.funcionarios.push(funcionario);
          this.nome = '';
        })
    },
    remover(funcionario){
      this.$http
        .delete(`http://localhost:3000/funcionarios/${funcionario.id}`)
        .then(() => {
          let indice = this.funcionarios.indexOf(funcionario);
          this.funcionarios.splice(indice, 1);
        }) 
    },
    carregarCargos() {
      this.$http
      .get("http://localhost:3000/cargos/" + this.cargoid)
      .then(res => res.json())
      .then(cargo => {
        this.cargo = cargo
      });
    }
  },
}
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput{
  width: 150px;
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
