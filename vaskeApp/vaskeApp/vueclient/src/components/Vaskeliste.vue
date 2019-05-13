<template>
  <div>
    {{msg}}
    <div>
      <table class="tidsTabell">
        <tr>
          <th>TIDSROM</th>
        </tr>
        <tr>08:00 - 10:00</tr>
        <tr>10:00 - 12:00</tr>
        <tr>12:00 - 14:00</tr>
        <tr>14:00 - 16:00</tr>
        <tr>16:00 - 18:00</tr>
        <tr>18:00 - 20:00</tr>
        <tr>20:00 - 22:00</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>
            MANDAG {{date}}</th>
        <tr>LEDIG</tr>
        <tr id="man10"></tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>TIRSDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>ONSDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>TORSDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>FREDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>LØRDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>SØNDAG</th>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
        <tr>LEDIG</tr>
      </table>
      <table class="testTabell">
        <p>Data fra DB:</p>
        <tr v-for="vask in vask">
          <td>{{ vask.leilighetsNR}}</td>
          <td> ..dato..</td>
          <td>{{ vask.vaskStart}}</td>
        </tr>
      </table>

    </div>
    <button @click="getDates()">console.log</button>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'Vaskeliste',
  data () {
    return {
      msg: "Her kommer en liste over vask..?",
      vask: [],
      date: new Date().toISOString().slice(6, 10),
      flippedDate: null,
      ukedagArray: [{
        dag: 'mandag',
        dato:this.date,
        leilighet: 'C304',
        tid:'14:00-16:00'
      }],
      tidsromArray: [],
      
      
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
      getDates() {
        //let today = (new Date());
        console.log("dateFromDB: " + this.vask[0].vaskStart)
        this.dataFromDBtoTable()
        //let tomorrow = (new Date()).add(1, 'days');
        
      },
      getCurrentWeek() {
        //med moment(isoweek)..? dytte dager i et array etter uke#
      },
      setDateTime() {
        //et array per dag+dato, indexene koblet til klokkeslett
        //--dagen som trykkes på skal få data om tid / dag fra to forskjellige arrays

      },
      dataFromDBtoTable() {
        let testDate = "2019-03-03T10:00:00"
        let firstDate = this.vask[0].vaskStart
        let includesWord = firstDate.includes("10:00")
        if (firstDate == testDate && includesWord == true) {
          document.getElementById("man10").innerHTML = this.vask[0].leilighetsNR
          console.log("added to table @ 10 O' clock")
        }
        else {console.log("Something went wrong.")}

        
      },
      pushTODB(){
        //slå sammen dato+tid før push - i riktig format YYYY-MM-DD + time HH.MM.SS
      }


      
   }
}
</script>

<style scoped>

  .tidsTabell {
    float: left;
    border: 1px solid black;
    display: inline-block;
  }
  .vaskeTabell {
    text-align: center;
    border: 1px solid black;
    display: inline-block;
    float: left;
  }
  .testTabell{
    position: relative;
    top: 120px;
    float: left;
  }
  th, tr, td {
    border: 1px solid black;
  }

</style>
