<template>
  <div id="app">
    <Vaskeliste />
    <OpprettVask v-if="OpprettVask "/>
    <EndreVask v-if="EndreVask "/>
    <button @click="leggtilVask()">Sett opp Vask</button@click:>
    <button @click="redigerVask()">Endre Vask</button>
  </div>
</template>

<script>
  import Vaskeliste from "./components/Vaskeliste.vue"
  import EndreVask from "./components/EndreVask.vue"
  import OpprettVask from "./components/OpprettVask.vue"


  export default {
    name: 'App',
    components: {
      Vaskeliste,
      EndreVask,
      OpprettVask
    },
    data() {
      return {
        EndreVask: false,
        OpprettVask: false

      };
    },
    methods: {
      redigerVask() {
        this.EndreVask = true
      },
      leggtilVask() {
        this.OpprettVask = true
      }

    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
