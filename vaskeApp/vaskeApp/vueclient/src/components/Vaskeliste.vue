<template>
  <div>
    {{msg}}
    <div>

      <table class="vaskeTabell">
        <thead>
          <tr>
            <th>Tid/Dag</th>
            <th v-for="dag in dagArray" width="50">{{ dag }} - {{date}}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(tid, tid_index) in startTidArray" :key="tid">
            <td>{{ tid }}</td>
            <td v-for="(dag, dag_index) in dagArray" @click="alert(tid_index, dag_index)">tid/dag</td>
          </tr>
        </tbody>
      </table>




      <!--<table class="testTabell">
    <p>Data fra DB:</p>
    <tr v-for="vask in vask">
      <td>{{ vask.leilighetsNR}}</td>
      <td> ..dato..</td>
      <td>{{ vask.vaskStart}}</td>
    </tr>
  </table>-->

    </div>
    <button @click="getDates()">console.log</button>
  </div>
</template>
<script>
  import axios from 'axios'

  export default {
    name: 'Vaskeliste',
    data() {
      return {
        msg: "Her kommer en liste over vask..?",
        vask: [],
        date: new Date().toISOString().slice(6, 10),
        //flippedDate: null,
        dagArray: ["Mandag" , "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"],
        startTidArray: ["08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"],
       // vaskSlutt: ["10: 00", "12: 00", "14: 00", "16: 00", "18: 00", "20: 00", "24:00"]
        testNR: "",
        isMatch: true
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
      alert(tid_index, dag_index) {
        let tid = this.startTidArray[tid_index]
        let dag = this.dagArray[dag_index]

        alert(tid + dag)
      },
      velgTid(e) {
        console.log(e)
      },
      getDates() {
        //let today = (new Date());
        //console.log("dateFromDB: " + this.vask[0].vaskStart)
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
        let incomingVask = this.vask[2] //prøver med én spesifik først
        let vaskStart = incomingVask.vaskStart
        let leilighetsNR = incomingVask.leilighetsNR
        console.log("incoming vask: " + incomingVask)
        this.testNR = leilighetsNR //tester å sende "inkommet" l.Nr opp i data, og printe ut dét



        //sjekke om tidspunktet som kommer inn finnes i arrayet
        let finnes = this.matchInnhold(vaskStart, this.startTidArray)

        if (finnes) {
          this.isMatch = true 

         // document.getElementById("man10").innerHTML = leilighetsNR
          console.log("Tidspunkt fra STRING fra db som matcher tidsARRAYet: " + finnes)

          let findFinnesIndex = this.startTidArray.indexOf(finnes)
          console.log("indexen til " + finnes + "i arrayet er: " + findFinnesIndex)
          //klokkeslettet som ligger i findFinnesIndex er:
          let klokkeslett = this.startTidArray[findFinnesIndex];
          console.log("klokkeslettet på plass " + findFinnesIndex + " i arrayet er: " + klokkeslett)

          //klokkeslettet som ligger i mandag er..? i arrayet. på hver sin index.hvordan få tak i at de ligger under id'en "mandag"?
          let mandagTider = this.
          console.log("mandag: " + mandag)
         
          //bare printe ut romNR der klokkeslett matcher klokkeslettet i mandag(fFindex sitt klokkeslett)
          



          //koble mandag-søndag's rader med tidsArrayet
          //--få tak i indexene i mandagstabellen
          
          console.log("added to Monday table @" + finnes + "O' clock")
        }
        else { console.log("Something went wrong.") }


      },



      pushTODB() {
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

  .testTabell {
    position: relative;
    top: 120px;
    float: left;
  }

  th, tr, td {
    border: 1px solid black;
  }
</style>
