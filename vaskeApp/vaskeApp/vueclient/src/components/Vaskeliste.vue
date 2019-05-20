<template>
  <div>
    {{msg}}
    <div>
      

      <table class="vaskeTabell">
        <thead>
          <tr>
            <th>Tid/Dag</th>
            <th v-for="(dag, dagIndex) in dagArray" width="50">{{ dag }} - {{dagIndex}}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(timeObj, tidIndex) in allData">
            <td>{{ timeObj.tid }}</td>
            <td></td>
            <td v-for="room in timeObj.items" @click="velgTid(tidIndex)">{{room}}</td>
            <!--<td v-for="room in timeObj.items" @click="velgTid(tidIndex, dagIndex)">{{room}}</td>-->
          </tr>
        </tbody>
      </table>


      {{test}}

      <span style="color:transparent">{{ dummyCounter }}</span>
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
        dummyCounter: 0,
        allData: [
          { tid: '08:00', items: ['', '', '', '', '', '', ''] },
          { tid: '10:00', items: ['', '', '', '', '', '', ''] },
          { tid: '12:00', items: ['', '', '', '', '', '', ''] },
          { tid: '14:00', items: ['', '', '', '', '', '', ''] },
          { tid: '16:00', items: ['', '', '', '', '', '', ''] },
          { tid: '18:00', items: ['', '', '', '', '', '', ''] },
          { tid: '20:00', items: ['', '', '', '', '', '', ''] },
          { tid: '22:00', items: ['', '', '', '', '', '', ''] },
        ],
        dbVaskArray: [],
        dagIndexes: { Mandag: 0, Tirsdag: 1, Onsdag: 2, Torsdag: 3, Fredag: 4, Lørdag: 5, Søndag: 6 },
        date: new Date().toISOString().slice(6, 10),
        //flippedDate: null,
        dagArray: ["Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"],
        //startTidArray: ["08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"],
        testNR: "",
        isMatch: false,
        test: "Valgt dag + tid: "
      }
    },
    created() {
      //for (let time = 8; time <= 22; time += 2) {
      //  this.allData.push({ tid: (time + 100 + ':00').substr(1), items: ['','','','','','','']});
      //}
      //console.log("allData: " + JSON.stringify( this.allData));

      axios.get("/api/vask")
        .then(this.handleData)
        .catch(function (error) {
          console.log("Her gikk det galt: " + error)
        })
    },
    methods: {
      handleData(response) {
        console.log('handleData', response.data);
        for (let booking of response.data) {
          this.dbVaskArray.push(booking);
          let tidIndex = (booking.vaskStart.substr(0, 2) - 8) / 2;
          let dagIndex = this.dagIndexes[booking.dag];
          this.allData[tidIndex].items[dagIndex] = booking.leilighetsNR;
        }
        this.dummyCounter++;
        console.log("dette ligger i response: " + JSON.stringify(response.data))
        console.log("dette ligger i this.allData: ", this.allData)
      },
      velg(tid, dagIndex) {
        let valgtTid = this.startTidArray[tid]
        let valgtDag = this.dagArray[dagIndex]


        this.test = "Valgt dag + tid: " + " klokken " + valgtTid + " på " + valgtDag
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
        //med moment(isoweek)..?
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
        //let incomingVask = this.dbVaskArray[0] //prøver med én spesifik først
        //let vaskStart = incomingVask.vaskStart
        //let leilighetsNR = incomingVask.leilighetsNR
        //let dag = incomingVask.dag


        //console.log("incoming vask: " + incomingVask)
        //console.log("vask dag: " + dag)
        //this.testNR = leilighetsNR //tester å sende "inkommet" leil.Nr opp i data, og printe ut dét


        ////sjekke om tidspunktet som kommer inn finnes i tid arrayet
        //let tidFinnes = this.matchInnhold(vaskStart, this.startTidArray)
        //let dagFinnes = this.matchInnhold(dag, this.dagArray)

        //if (tidFinnes && dagFinnes) {
        //  this.isMatch = true

        // // document.getElementById("man10").innerHTML = leilighetsNR
        //  console.log("Tidspunkt fra vaskArray som matcher tidsArray: " + tidFinnes)

        //  let findFinnesIndex = this.startTidArray.indexOf(tidFinnes)
        //  let findDagIndex = this.dagArray.indexOf(dagFinnes)
        //  console.log("indexen til " + tidFinnes + " og " + dagFinnes + " i arrayet er: " + findFinnesIndex +" og " + findDagIndex)

        //  //klokkeslettet som ligger i findFinnesIndex er:
        //  let klokkeslett = this.startTidArray[findFinnesIndex];
        //  console.log("klokkeslettet på plass " + findFinnesIndex + " i arrayet er: " + klokkeslett)


        //  //bare printe ut romNR der klokkeslett+dag fra vaskArray matcher klokkeslett+dag i table(arrayene tid+dag)


        //  console.log("added to " + dag + " table @" + tidFinnes + " O' clock")
        //}
        //else { console.log("Something went wrong.") }
        //for (let booking of this.dbVaskArray) {
        //  console.log("kjører for loop")
        //  let tidIndex = (booking.vaskStart.substr(0, 2) - 8) / 2;
        //  let dagIndex = this.dagIndexes[booking.dag];
        //  this.allData[tidIndex].items[dagIndex] = booking.leilighetsNR;
        //}
        //console.log("ute av for loop" + JSON.stringify(this.allData))
      },



      pushTODB() {

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
