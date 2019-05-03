<template>
  <div class="yourScore">
    <p>{{savedName}} - DU FIKK EN SCORE PÅ: {{ numCorrect }}</p>
    <button @click="addScore()">SUBMIT SCORE</button>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Score</th>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="score in orderedScores" v-bind:key="score.id">
          <td>{{score.userScore}}</td>
          <td>{{score.name}}</td>
        </tr>
      </tbody>
    </table>
    <button @click="console()">console.log</button>
  </div>
</template>

<script>
import { db } from "../main";
import _ from 'lodash'
import underscore from 'underscore'
console.log("ScoreBoard " + new Date().toLocaleTimeString(), db);

export default {
  props: ["numCorrect", "savedName"],
  data() {
    return {
      userScores: [{
        name: '',
        userScore: ''
        }],
      name: "",
      userScore: 0
    };
  },
  created() {
    this.name = this.savedName
    this.userScore = this.numCorrect
    this.showScores()
    
    
    
  },
  computed: {
  orderedScores() {
    return _.orderBy(this.userScores, 'userScore' ,['desc'])
  }
},
  methods: {
    console() {
      // console.log("dette ligger i name: ", this.name)
      // console.log("dette ligger i userScore: ", this.userScore)
      // console.log("dette ligger i userScores: ", this.userScores)
      this.uniqueUsers()
    },

    addScore() {
      let name = JSON.stringify(this.name)
      let userScore = JSON.stringify(this.userScore)
      //loading start anim på knapp her (buttonloader)
      db.collection("userScores").add({ name, userScore }).then(() => {
        console.log("Added score") //legg til loading stopp her
      })
       
    },

    showScores() {
      db.collection("userScores").onSnapshot(res => {
        const changes = res.docChanges()

        changes.forEach(change => {
          if(change.type === 'added'){
            this.userScores.push({
              ...change.doc.data()
            })
          }
          
          //this.userScores.push(doc.data())
           
        })
      }) 
      
    },
    sortScores(){
      this.userScores.orderBy("userScore")
    },
    uniqueUsers(){
      /*const result = []
      const map = new Map()
      for( const score of this.userScores){
        if(!map.has(score.name)){
            map.set(score.name, true)
            result.push({
              name: score.name,
              userScore: score.userScore
            })
        }
      }
      //[...new Set(this.userScores.map(x=> x.name))]
      console.log("unikt? " + result.score)*/
      console.log("userscores: "+ this.userScores)
      //var newArray = [...new Set(this.userScores)]
//       var out = Object.values(
//       this.userScores.reduce( (c, e) => {
//       if (!c[e.name]) c[e.name] = e;
//       return c;
//   }, {})
// );
// var res = this.userScores.reduce((acc, obj)=>{
//    var exist = acc.find(({userScore, name}) => obj.userScore === userScore && obj.name === name);
//    if(!exist){
//     acc.push(obj);
//    }
//    return acc;
// },[]);

      console.log("newArray " + res)
    }
  }
};
</script>

<style scoped>
.yourScore {
  color: red;
  font-size: 20px;
}
</style>