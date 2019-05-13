<template>
  <div>
    {{msg}}
    <div>
      <table class="tidsTabell">
        <tr>
          <th>TIDSROM</th>


        <tr v-for="tid in startTidArray" >
        {{tid}} - </tr>
       
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>
            MANDAG {{date}}</th>
        <tr v-for="tid in startTidArray">*</tr>
        <tr id="man10"></tr>
       
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>TIRSDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>ONSDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>TORSDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>FREDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>LØRDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
      </table>
      <table class="vaskeTabell">
        <tr>
          <th>SØNDAG</th>
        <tr v-for="tid in startTidArray">*</tr>
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
      startTidArray: ["08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"],
      vaskSlutt: [ "10: 00", "12: 00", "14: 00", "16: 00", "18: 00", "20: 00", "24:00"]
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
      matchInnhold(str, arr) {
       for (var i = 0; i != arr.length; i++) {
      var match = arr[i];
      if (str.indexOf(match) != - 1) {
        return match;
      }
    }
    return null;
  },
      dataFromDBtoTable() {
        let firstDate = this.vask[2].vaskStart
        //sjekke om tidspunktet som kommer inn finnes i arrayet
        let finnes = this.matchInnhold(firstDate, this.startTidArray)
        
        if (finnes) {
          document.getElementById("man10").innerHTML = this.vask[0].leilighetsNR
          console.log("array testing: " + finnes)

          //koble mandag-søndag's rader med tidsArrayet

          console.log("added to Monday table @" + finnes +  "O' clock")
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
