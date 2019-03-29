<template>
  <div>
    <titulo texto="Cargos"/>
    <table>
      <thead>
        <th>Código</th>
        <th>Cargo</th>
        <th>Quantidade</th>
      </thead>
      <tbody v-if="Cargos.length">
        <tr v-for="(cargo, index) in Cargos" :key="index">
          <td class="colPequeno" style="text-align: center; width: 15%">{{cargo.id}}</td>
          <router-link
            v-bind:to="`/funcionarios/${cargo.id}`"
            tag="td"
            style="cursor: pointer"
          >{{cargo.cargo}} {{cargo.sobrenome}}</router-link>
          <td class="colPequeno" style="text-align: center; width: 20%">
            {{cargo.qtdFuncionarios}}
          </td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum cargo encontrado.</tfoot>
    </table>
  </div>
</template>
<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo
  },
  data() {
    return {
      Cargos: [],
      Funcionarios: []
    };
  },
  created() {
    this.$http
      .get('http://localhost:3000/funcionarios')
      .then(res => res.json())
      .then(funcionarios => {
        this.Funcionarios = funcionarios;
        this.carregarCargos();
      })
  },
  props: {
    
  },
  methods: {
    pegarQtdFuncionariosPorCargo(){
      this.Cargos.forEach((cargo, index) => {
        cargo ={
          id: cargo.id,
          cargo: cargo.cargo,
          qtdFuncionarios: this.Funcionarios.filter(funcionario => 
          funcionario.cargo.id == cargo.id).length
        }
        this.Cargos[index] = cargo;
      });
    },
    carregarCargos() {
      this.$http
      .get("http://localhost:3000/cargos")
      .then(res => res.json())
      .then(cargo => {
        this.Cargos = cargo
        this.pegarQtdFuncionariosPorCargo();
      });
    }
  },
};
</script>

<style scoped>
</style>