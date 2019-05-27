<template>
  <div>
    {{msg}}
    <div>


      <table class="vaskeTabell">
        <thead>
          <tr>
            <th>Tid/Dag <br>Uke: {{week}} </th>
            <th v-model="currentWeekDates" v-for="(ukedag, index) in dagArray" width="50"> {{ukedag}} {{ getCurrentDates(ukedag)}}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(timeObj, tidIndex) in allData">
            <td>{{ timeObj.tid }} </td>
            <td v-for="(room, day, vaskID) in timeObj.items"
                @click="velg(timeObj.tid, day, room, timeObj.vaskID)"
               
                >{{room.booking}}</td>
          </tr>
        </tbody>
      </table>


      
      <span style="color:transparent">{{ dummyCounter }}</span>
    </div>
   
  </div>
</template>
<script>
  import axios from 'axios'
  import moment from 'moment'
  
  export default {
    name: 'Vaskeliste',
    data() {
      return {
        msg: "Vaskeliste",
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
        currentWeekDates:"",

        dagArray: ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"],
        selectedStyle: {
          background: "yellow"
        }
      }
    },
    created() {
      axios.get("/api/vask")
        .then(this.handleData)
        .catch(function (error) {
          console.log("Her gikk det galt: " + error)
        })
      //console.log("Dataarray: " + this.dbVaskArray)
      //console.log("allData: " + JSON.stringify(this.allData))
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
    methods: {
      handleData(response) {
        console.log('handleData', response.data)
        for (let booking of response.data) {
          this.dbVaskArray.push(booking)
          let tidIndex = (booking.vaskStart.substr(0, 2) - 8) / 2;
          let dagIndex = this.dagIndexes[booking.dag]
          let vaskID = booking.vaskID
          this.allData[tidIndex].items[dagIndex] = { booking: booking.leilighetsNR, bookingID: vaskID }
       
        }
        this.dummyCounter++;
      },
      velg(tid , dag, room) {
        console.log(tid, dag, room)
        this.selected = true
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
        this.valgtTid = "Valgt dag + tid: " + " klokken " + tid + " på " + dag
        var tid = tid
        var dag = dag
        var valgtVaskId = room.bookingID
        var valgtLeilighet = room.booking
        
        console.log("id..? ", valgtVaskId)
        console.log("leilighet..?", valgtLeilighet)
        this.$emit("sendTimeToParent", tid, dag, valgtLeilighet, valgtVaskId)
      },
     
      getCurrentDates(ukedag) {
        var getDate = moment().day(ukedag).year(this.year).isoWeek(this.week).toISOString()
        return getDate.slice(8, 10)
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
      onCellClick(params) {
        // params.row - row object 
        // params.column - column object
        // params.rowIndex - index of this row on the current page.
        // params.event - click event
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

  .selected {
    background-color: limegreen;
  }
</style>
