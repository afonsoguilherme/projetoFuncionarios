<template>
  <div v-if="!loading">
    <titulo :texto="`Funcionário: ${funcionario.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{funcionario.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{funcionario.nome}}</label>
            <input v-else v-model="funcionario.nome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{funcionario.sobrenome}}</label>
            <input v-else v-model="funcionario.sobrenome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizando">{{funcionario.dataNasc}}</label>
            <input v-else v-model="funcionario.dataNasc" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Cargo:</td>
          <td>
            <label v-if="visualizando">{{funcionario.cargo.nome}}</label>
            <select v-else v-model="funcionario.cargo.id">
              <option
                v-for="(cargo, index) in cargos"
                :key="index"
                v-bind:value="cargo.id"
              >{{cargo.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(funcionario)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
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
      cargos: [],
      funcionario: {},
      id: this.$route.params.id,
      visualizando: true,
      loading: true
    };
  },
  created() {
    this.carregarCargo();
  },
  methods: {
    carregarCargo() {
      this.$http
        .get("http://localhost:5000/api/cargo")
        .then(res => res.json())
        .then(cargo => {
          this.cargos = cargo;
          this.carregarFuncionario();
        });
    },
    carregarFuncionario() {
      this.$http
        .get(`http://localhost:5000/api/funcionario/${this.id}`)
        .then(res => res.json())
        .then(funcionario => {
          this.funcionario = funcionario;
          this.loading = false;
        });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(_funcionario) {
      let _funcionarioEditar = {
        id: _funcionario.id,
        nome: _funcionario.nome,
        sobrenome: _funcionario.sobrenome,
        dataNasc: _funcionario.dataNasc,
        cargoid: _funcionario.cargo.id
      };
      this.$http
        .put(
          `http://localhost:5000/api/funcionario/${_funcionarioEditar.id}`,
          _funcionarioEditar
        )
        .then(res => res.json())
        .then(funcionario => (this.funcionario = funcionario))
        .then(() => (this.visualizando = true));
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    }
  }
};
</script>
<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
.colPequeno {
  width: 20%;
}
input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  background-color: rgb(245, 245, 245);
  width: 95%;
}
select {
  height: 38px;
  width: 100%;
}
</style>