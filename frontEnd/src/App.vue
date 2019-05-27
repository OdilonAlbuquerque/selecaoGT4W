<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">Processo de Seleção</b-navbar-brand>
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
  </b-navbar>
  <br>
    
    <div class="contain">
    <div class="row col-md-10 offset-md-1">
      <div class="col-md-3">
        <b-form v-if="show" @submit.prevent="salvar">
        <b-form-group id="input-group-nome" label="Nome:" label-for="input-nome">
          <b-form-input
            id="input-nome"
            v-model="cliente.ClienteNome"
            required
            placeholder="Nome"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-cpf" label="CPF:" label-for="input-cpf">
          <b-form-input
            id="input-cpf"
            v-model="cliente.ClienteCPF"
            required
            placeholder="CPF"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-nascimento" label="Data de Nascimento:" label-for="input-nascimento">
          <b-form-input
            id="input-nascimento"
            v-model="cliente.ClienteNascimento"
            type="date"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-peso" label="Peso: (Kg)" label-for="input-peso">
          <b-form-input
            id="input-peso"
            v-model="cliente.ClientePeso"
            type="number" min="0" value="0" step="any"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-uf" label="UF:" label-for="input-uf">
          <select v-model="cliente.ClienteUF" class="custom-select" required>
            <option v-for="uf in ufs" v-bind:value="uf.id">
              {{ uf.nome }}
            </option>
          </select>
        </b-form-group>

        <b-button type="submit" variant="primary">Salvar</b-button>
      </b-form>
      </div>

       <div class="col-md-9">
        <b-table striped hover :items="items"></b-table> 

        <table aria-busy="false" aria-colcount="3" class="table b-table table-striped table-hover">

        <thead>

          <tr>
            <th>NOME</th>
            <th>CPF</th>
            <th>DATA DE NASCIMENTO</th>
            <th>PESO</th>
            <th>UF</th>
          </tr>

        </thead>

        <tbody>

          <tr v-for="cliente of clientes" :key="cliente.ClienteID">

            <td>{{ cliente.ClienteNome }}</td>
            <td>{{ cliente.ClienteCPF }}</td>
            <td>{{ cliente.ClienteNascimento }}</td>
            <td>{{ cliente.ClientePeso }}</td>
            <td>{{ cliente.ClienteUF }}</td>
            <!--
            <td>
              <button class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
              <button class="waves-effect btn-small red darken-1"><i class="material-icons">delete</i></button>
            </td>
            -->
          </tr>

        </tbody>
      
      </table>
      </div> 
    </div>
    </div>

  </div>
</template>

<script>

  import Clientes from './services/clientes'
  import Ufs from './services/ufs'

  export default {
    data() {
      return {
        cliente: {
          ClienteNome: '',
          ClienteCPF: '',
          ClienteNascimento: '',
          ClientePeso: '',
          ClienteUF: ''
        },
        clientes: [],
        ufs: [],

        
        form: {
          email: '',
          name: '',
          food: null,
          checked: []
        },
        show: true
      }
    },

    mounted(){
      this.listarClientes(),
      this.listarUfs()
    },

    methods: {/*
      onSubmit(evt) {
        evt.preventDefault()
        //alert(JSON.stringify(this.cliente))
      },*/
      frontEndDateFormat: function(date) {
      	return moment(date, 'YYYY-MM-DD').format('DD/MM/YYYY');
      },
      backEndDateFormat: function(date) {
      	return moment(date, 'DD/MM/YYYY').format('YYYY-MM-DD');
      },
      salvar(){
        //alert(this.cliente.ClienteNome)
        Clientes.salvar(this.cliente).then(resposta => {
          alert(resposta.status),
          this.cliente = {},
          alert('Salvo com sucesso!'),
          this.listarClientes()
        }).catch(e => {
          //console.log(e.response.status)
          if(e.response.status == '409') {
            alert("CPF já cadastrado!")
          }
        })
      },
      listarClientes() {
        Clientes.listar().then(resposta => {
        //console.log(resposta.data)
        this.clientes = resposta.data
        })
      },
      listarUfs() {
        Ufs.listar().then(resposta => {
        //console.log(resposta.data)
        this.ufs = resposta.data
        })
      }
    }
  }

  $("#input-cpf").mask("000.000.000-00");
</script>