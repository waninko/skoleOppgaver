<template>
  <div class="yourScore">
    <p>{{savedName}} - DU FIKK EN SCORE PÅ: {{ numCorrect }} - og TidsPoeng på {{timePoints}}</p>
    <p>SAMLET: {{numCorrect + timePoints}}</p>
    <button @click="addScore()">SUBMIT SCORE</button>
    <table class="table table-striped">
      <thead class="thead-light">
        <tr>
          <th>Place</th>
          <th>Score</th>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(score, index) in orderedScores" v-bind:key="score.id">
          <td v-if="score.userScore">{{startPlacingAtOne(index)}}</td>
          <td>{{score.userScore}}</td>
          <td>{{score.name}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { db } from "../main";
import _ from "lodash";

export default {
  props: ["numCorrect", "savedName", "timePoints"],
  data() {
    return {
      userScores: [
        {
          name: "",
          userScore: ""
        }
      ],
      name: "",
      userScore: 0
    };
  },
  created() {
    this.name = this.savedName;
    this.userScore = this.numCorrect;
    this.showScores();
  },
  computed: {
    orderedScores() {
      let userScores = this.uniqueNames(this.userScores);
      let ordered = _.orderBy(
        userScores,
        function(o) {
          return new Number(o.userScore);
        },
        ["desc"]
      );
      return ordered.slice(0, 10);
    }
  },

  methods: {
    addScore() {
      let name = JSON.stringify(this.name);
      let calculatedScore = this.userScore + this.timePoints;
      let userScore = JSON.stringify(calculatedScore);
      //loading start anim på knapp her (buttonloader)

      db.collection("userScores")
        .add({ name, userScore })
        .then(() => {
          console.log("Added score"); //legg til loading stopp her
        });
    },

    showScores() {
      db.collection("userScores").onSnapshot(res => {
        const changes = res.docChanges();

        changes.forEach(change => {
          if (change.type === "added") {
            this.userScores.push({
              ...change.doc.data()
            });
          }
        });
      });
    },

    uniqueNames(arrayName) {
      let uniqueNames = [];
      arrayName.map(user => {
        if (!uniqueNames.find(i => i.name === user.name) > 0) {
          uniqueNames.push(user);
        }
      });
      return uniqueNames;
    },
    startPlacingAtOne(index) {
      return index + 1;
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