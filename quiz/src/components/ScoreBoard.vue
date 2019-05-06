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
    let userScores = this.uniqueNames(this.userScores)  
    let ordered = _.orderBy(userScores, function (o) { 
                   return new Number(o.userScore); }, ['desc'])
    return ordered.slice(0,10)
  }
  
  },

  methods: {
    console() {
      // console.log("dette ligger i name: ", this.name)
      // console.log("dette ligger i userScore: ", this.userScore)
      // console.log("dette ligger i userScores: ", this.userScores)

      console.log("uniqueNames: " + JSON.stringify(this.uniqueNames(this.userScores))) 
     
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
    
    uniqueNames(arrayName){
      let uniqueNames = []
      arrayName.map(user => {
        if(!uniqueNames.find(i => i.name === user.name) > 0){
          uniqueNames.push(user)
        }
      })
      return uniqueNames
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