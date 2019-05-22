<template>
  <div>
    {{msg}}
    <div>
      

      <table class="vaskeTabell">
        <thead>
          <tr>
            <th>Tid/Dag <br>Uke: {{week}}</th>
            <th v-for="(ukedag, index) in dagArray" width="50"> {{ukedag}} {{day  }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(timeObj, tidIndex) in allData">
            <td>{{ timeObj.tid }} </td>
            <td v-for="(room, day) in timeObj.items" @click="velg(timeObj.tid, day)">{{room}}</td>
          </tr>
        </tbody>
      </table>


      {{valgt}}

      <span style="color:transparent">{{ dummyCounter }}</span>
    </div>
    <button @click="consoleLog()">console.log</button>
  </div>
</template>
<script>
  import axios from 'axios'
  import moment from 'moment'
  import VueMoment from 'vue-moment'
  import datejs from 'datejs'
  
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
        
        dateContext: moment(),
       // getDate: ,

        dagArray: ["Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag"],
        testNR: "",
        isMatch: false,
        valgt: "Valgt dag + tid: "
      }
    },
    created() {
      axios.get("/api/vask")
        .then(this.handleData)
        .catch(function (error) {
          console.log("Her gikk det galt: " + error)
        })
    },
    computed: {
      day() {
        var t = this
        return t.dateContext.format('DD/MM')
      },
      week() {
        var t = this
        return t.dateContext.format('WW')
      },
      year() {
        var t = this
        return t.dateContext.format('YYYY')
      }
    },
    watch: {
     
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
      velg(tid , dag) {
        console.log(tid, dag)
        switch (dag) {
          case 0:
            dag = "Mandag";
            break;
          case 1:
            dag = "Tirsdag";
            break;
          case 2:
            dag = "Onsdag";
            break;
          case 3:
            dag = "Torsdag";
            break;
          case 4:
            dag = "Fredag";
            break;
          case 5:
            dag = "Lørdag";
            break;
          case 6:
            dag = "Søndag";
            
        }
        this.valgt = "Valgt dag + tid: " + " klokken " + tid + " på " + dag
       
      },
      consoleLog() {
        var getDate = moment().day('monday').year(this.year).week(this.week).toDate()
        //finne en måte å bytte ut .day(ukedag.dagArray?) etthvert som det "bartes ut" i v-for'en!
        console.log(getDate)
        
        //let tomorrow = (new Date()).add(1, 'days');

      },
      getCurrentDays() {
        //med moment(isoweek)..?
        let todaysDate = new Date().toISOString()
        var tomorrow = new Date()
        tomorrow.setDate(tomorrow.getDate() + 1)
        this.date = tomorrow
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
