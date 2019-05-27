<template>
  <div>
    
    valgt tid:{{valgtTid}}
    <br />
    valgt dag:{{valgtDag}}
    <br />
    skriv inn leilighetsNR: <input type="text" id="leilighetInput" v-model="leilighetInput"/> <button @click="saveData()">Lagre</button>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
    name: 'OpprettVask',
    props: ['valgtTid', 'valgtDag'],
  data () {
    return {
      msg: "Her kan man opprette/skrive seg opp på vask om det er ledig tid..?",
      leilighetInput: "",
    }
    },
    methods: {
      saveData() {
        var vaskObj = {
          LeilighetsNR : this.leilighetInput,
          VaskStart : this.valgtTid,
          Dag: this.valgtDag,
          Varighet: 120
        }
        
        axios.post('/api/vask',  vaskObj)
          .then(function (response) {
            console.log('lagret ny vask: ', response);
          })
          .catch(function (error) {
            console.log(error);
          });
        
      }
    }
}
</script>
