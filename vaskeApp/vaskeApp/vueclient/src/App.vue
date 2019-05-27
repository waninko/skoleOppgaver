<template>
  <div id="app">
    <Vaskeliste
    :valgtTid ="valgtTid"
    v-on:sendTimeToParent="getTime"
                />

    <OpprettVask v-if="OpprettVask && !EndreVask"
     :valgtTid ="valgtTid"
     :valgtDag = "valgtDag"
                 />


    <EndreVask v-if="EndreVask "
      :valgtTid ="valgtTid"
      :valgtDag = "valgtDag"
      :valgtLeilighet = "valgtLeilighet"
      :valgtVaskId = "valgtVaskId"
               />

    
    <button v-if="!OpprettVask" @click="leggtilVask()">Sett opp Ny Vask</button>
    <button v-if="!EndreVask" @click="redigerVask()">Endre Vask</button>

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
        OpprettVask: false,
        valgtTid: "testTid",
        valgtDag: "",
        valgtLeilighet: "",
        valgtVaskId: ""

      };
    },
    methods: {
      redigerVask() {
        this.EndreVask = true
      },
      leggtilVask() {
        this.OpprettVask = true
      },
      getTime(tid, dag, valgtLeilighet, valgtVaskId) {
        this.valgtTid = tid
        this.valgtDag = dag
        this.valgtLeilighet = valgtLeilighet
        this.valgtVaskId = valgtVaskId
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
