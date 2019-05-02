<template>
  <div class="yourScore">
    <p>{{savedName}} - DU FIKK EN SCORE PÅ: {{ numCorrect }}</p>
    <button @click="addScore()">SUBMIT SCORE</button>
    <button @click="showScores()">SHOWSCOREs</button>
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
  },
  // firestore: {
  //   userScores: db.collection("userScores") //.orderBy("score")
  // },
  computed: {
  orderedScores() {
    return _.orderBy(this.userScores, 'userScore')
  }
},
  methods: {
    console() {
      console.log("dette ligger i name: ", this.name)
      console.log("dette ligger i userScore: ", this.userScore)
      console.log("dette ligger i userScores: ", this.userScores)
    },
    addScore() {
      let name = JSON.stringify(this.name)
      let userScore = JSON.stringify(this.userScore)
      db.collection("userScores").add({ name, userScore })
    },
    showScores() {
     db.collection("userScores")
     .get()
     .then((querySnapshot) => {
            querySnapshot.forEach((doc) => {
        console.log( "name: " + `${doc.data().name}` + "   |  score: " + ` ${doc.data().userScore}`)
        
              let name = `${doc.data().name}` 
              let userScore =  `${doc.data().userScore}`
              let dbScore = {
                name: name,
                userScore: userScore
              }
              this.userScores.push(dbScore)
            });
        })
      .catch((error)  => {
        console.log("Error getting documents: ", error);
});
    },
    sortScores(){
      this.userScores.orderBy("userScore")
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