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
        <tr v-for="score in userScores" v-bind:key="score.name">
          <td>{{score.score}}</td>
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
      userScores: [],
      name: "",
      userScore: 0
    };
  },
  created() {
    this.name = this.savedName;
    this.userScore = this.numCorrect;
  },
  // firestore: {
  //   userScores: db.collection("userScores") //.orderBy("score")
  // },
  methods: {
    console() {
      console.log("dette ligger i name: ", this.name);
      console.log("dette ligger i userScores: ", this.userScores);
    },
    addScore() {
      let name = JSON.stringify(this.name);
      let userScore = JSON.stringify(this.userScore);
      db.collection("userScores").add({ name, userScore });
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