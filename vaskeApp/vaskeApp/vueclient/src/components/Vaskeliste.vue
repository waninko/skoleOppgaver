<template>
  <div>
    {{msg}}
    <div>
      <table class="vaskeTabell">
        <tr>
          <th> TID </th>
          <th>MANDAG (dato)</th>
          <th>TIRSDAG (dato)</th>
          <th>ONSDAG (dato)</th>
          <th>TORSDAG (dato)</th>
          <th>FREDAG (dato)</th>
          <th>LØRDAG (dato)</th>
          <th>SØNDAG (dato)</th>
        </tr>
        <tr>
          <td>08:00 - 10:00</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
          <td>(leilighets NR)</td>
        </tr>
        <tr>
          <td>10:00 - 12:00</td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
      </table>
      <table>
        <tr v-for="vask in vask">

          <td>{{ vask.leilighetsNR}}</td>
          <td> ..dato..</td>
          <td>{{ vask.vaskStart}}</td>
        </tr>
      </table>

    </div>
    <button @click="separateDateTime()">console.log</button>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'Vaskeliste',
  data () {
    return {
      msg: "Her kommer en liste over vask..?",
      vask:[]
    }
    },
    created() {
      const self = this;

      axios.get("/api/vask")
        .then(function (response) {
          for (let vask of response.data) {
            self.vask.push(vask)
          } console.log("dette ligger i response: " + JSON.stringify(response.data))
        })

        .catch(function (error) {
          console.log("Her gikk det galt: " + error)
        })
      
    },
    methods: {
      separateDateTime() {
        //dele opp vask.vaskStart i hver sin var: en til dato en til tidspunkt
        //først: få ut vaskStart dataene fra obj i vask arrayet.
        console.log("separate date & time : " + JSON.stringify(this.vask.vaskStart))

        const startTimeArray = [];
        for (let i=0, l=this.vask.length; i < l; i++) {
          if (this.vask.length[i][vaskStart] !== "") {
            startTimeArray.push(this.vask.length[i])
          }
        }
        console.log("nytt array: " + startTimeArray)
      }
   }
}
</script>

<style scoped>
  .vaskeTabell{
    text-align: center;
    border: 1px solid black;
    display: inline-block;
  }

  th,tr, td{
    border: 1px solid black;
  }

</style>
