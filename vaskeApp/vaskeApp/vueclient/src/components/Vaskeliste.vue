<template>
  <div>
    {{msg}}
    <div>
      

      <table class="vaskeTabell">
        <thead>
          <tr>
            <th>Tid/Dag</th>
            <th v-for="(dag, index) in dagArray" width="50"> {{dag}}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(timeObj, tidIndex) in allData">
            <td>{{ timeObj.tid }} </td>
            
            <td v-for="(room, day) in timeObj.items" @click="velgTid(timeObj.tid, day)">{{room}}</td>

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
        dagArray: ["Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"],
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
        //let valgtTid = this.startTidArray[tid]
        //let valgtDag = this.dagArray[dagIndex]


        //this.test = "Valgt dag + tid: " + " klokken " + valgtTid + " på " + valgtDag
      },
      velgTid(e , f) {
        console.log(e, f)
        switch (f) {
          case 0:
            f = "Mandag";
            break;
          case 1:
            f = "Tirsdag";
            break;
          case 2:
            f = "Onsdag";
            break;
          case 3:
            f = "Torsdag";
            break;
          case 4:
            f = "Fredag";
            break;
          case 5:
            f = "Lørdag";
            break;
          case 6:
            f = "Søndag";
            
        }
        this.test = "Valgt dag + tid: " + " klokken " + e + " på " + f
       
      },
      getDates() {
        //let today = (new Date());
        //console.log("dateFromDB: " + this.vask[0].vaskStart)
        this.dataFromDBtoTable()
        console.log(JSON.stringify(this.dbVaskArray) + " dbVaskArray")
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
