<template>
  <div>
    <titulo texto="Cargos"/>
    <table>
      <thead>
        <th>Código</th>
        <th>Função</th>
        <th>Quantidade</th>
      </thead>
      <tbody v-if="Cargos.length">
        <tr v-for="(cargo, index) in Cargos" :key="index">
          <td class="colPequeno" style="text-align: center; width: 15%">{{cargo.id}}</td>
          <router-link
            v-bind:to="`/funcionarios/${cargo.id}`"
            tag="td"
            style="cursor: pointer"
          >{{cargo.nome}} {{cargo.sobrenome}}</router-link>
          <td class="colPequeno" style="text-align: center; width: 20%">{{cargo.qtdFuncionarios}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Cargo Encontrado</h5>
          </td>
        </tr>
      </tfoot>
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
      .get("http://localhost:5000/api/funcionario")
      .then(res => res.json())
      .then(funcionarios => {
        this.Funcionarios = funcionarios;
        this.carregarCargos();
      });
  },
  props: {},
  methods: {
    pegarQtdFuncionariosPorCargo() {
      this.Cargos.forEach((cargo, index) => {
        cargo = {
          id: cargo.id,
          nome: cargo.nome,
          qtdFuncionarios: this.Funcionarios.filter(
            funcionario => funcionario.cargo.id == cargo.id
          ).length
        };
        this.Cargos[index] = cargo;
      });
    },
    carregarCargos() {
      this.$http
        .get("http://localhost:5000/api/cargo")
        .then(res => res.json())
        .then(cargo => {
          this.Cargos = cargo;
          this.pegarQtdFuncionariosPorCargo();
        });
    }
  }
};
</script>

<style scoped>
</style>