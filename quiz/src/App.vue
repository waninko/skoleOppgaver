<template>
  <div id="app">
    <Header :numCorrect="numCorrect" :numTotal="numTotal"/>
    <ScoreBoard
      v-if="showScores"
      :numCorrect="numCorrect"
      :savedName="savedName"
    />
    <b-container class="bv-example-row">
      <b-row>
        <b-col sm="6" offset="3">
          <QuestionBox
            v-if="questions.length && !showScores"
            :currentQuestion="questions[index]"
            :next="next"
            :incrementCheckAndGetName="incrementCheckAndGetName"
          />
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import QuestionBox from "./components/QuestionBox.vue";
import ScoreBoard from "./components/ScoreBoard.vue";

export default {
  name: "app",
  components: {
    Header,
    QuestionBox,
    ScoreBoard
  },
  data() {
    return {
      questions: [],
      index: 0,
      numCorrect: 0,
      numTotal: 0,
      showScores: false,
      savedName: "",
      scores: null
    };
  },
  methods: {
    next() {
      this.index++;
    },

    incrementCheckAndGetName(isCorrect) {
      if (isCorrect) {
        this.numCorrect++;
      }

      this.numTotal++;
      if (this.numTotal == 2) {
        let promptName = prompt("Skriv inn navnet ditt");
        this.savedName = promptName;

        this.showScores = true;
      }
    }
  },
  mounted: function() {
    fetch("https://opentdb.com/api.php?amount=40&category=12&type=multiple", {
      method: "get"
    })
      .then(response => {
        return response.json();
      })
      .then(jsonData => {
        this.questions = jsonData.results;
      });
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
