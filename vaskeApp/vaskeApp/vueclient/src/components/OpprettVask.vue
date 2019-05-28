<template>
  <div>
    
    valgt tid:{{valgtTid}}
    <br />
    valgt dag:{{valgtDag}}
    <br />
    skriv inn leilighetsNR: <input type="text" id="leilighetInput" v-model="leilighetInput"/> <button @click="saveData()">Lagre</button>
    {{msg}}
  </div>
</template>

<script>
  import axios from 'axios'

export default {
    name: 'OpprettVask',
    props: ['valgtTid', 'valgtDag'],
  data () {
    return {
      msg: "",
      leilighetInput: "",
    }
    },
    methods: {
      console() {
        console.log(" valgt tid/dag: " + this.valgtTid, this.valgtDag)
      },
      saveData() {
        var vaskObj = {
          LeilighetsNR : this.leilighetInput,
          VaskStart : this.valgtTid,
          Dag: this.valgtDag,
          Varighet: 120
        }
        if (this.valgtTid && this.valgtDag == "" ) {
          axios.post('/api/vask', vaskObj)
            .then(function (response) {
              console.log('lagret ny vask: ', response)
            })
            .catch(function (error) {
              console.log(error)
            })
        }
        else {
          this.msg ="Vennligest velg en ledig time for vask."
        }
       
        
      }
    }
}
</script>
