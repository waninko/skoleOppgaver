<template>
  <div id="app">
    <Header 
      :numCorrect="numCorrect"
      :numTotal="numTotal"
    />
<ScoreBoard v-if="showScores"
      :numCorrect="numCorrect"
      :showScores="showScores"
      :savedName="savedName"
      :scores="scores"
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
import Header from './components/Header.vue'
import QuestionBox from './components/QuestionBox.vue'
import ScoreBoard from './components/ScoreBoard.vue'

import Firebase from 'firebase'
import VueFire from 'vuefire'

 let config = {
    apiKey: "AIzaSyACUTRWR1G95ZdvJ8AJXzcc8sAbpNFI5T4",
    authDomain: "musicquiz-3e9f4.firebaseapp.com",
    databaseURL: "https://musicquiz-3e9f4.firebaseio.com",
    projectId: "musicquiz-3e9f4",
    storageBucket: "musicquiz-3e9f4.appspot.com",
    messagingSenderId: "832892959771"
  };
  let fireApp = Firebase.initializeApp(config);
  let db = fireApp.database()
  let scoresRef = db.ref('userScores')


export default {
  name: 'app',
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
      savedName: ''
    }
  },
  firebase:{
   scores: scoresRef
 },
  methods: {
    next(){
      this.index++
    },

    incrementCheckAndGetName(isCorrect) {
      if(isCorrect){
        
        this.numCorrect++
      }
      
      this.numTotal++
      if(this.numTotal == 2){
        let promptName = prompt("Skriv inn navnet ditt")
        this.savedName = promptName
         
        this.showScores = true

    
      }
    }
  },
  mounted: function(){
    fetch('https://opentdb.com/api.php?amount=40&category=12&type=multiple', {
      method: 'get'
    })
    .then((response) => {
      return response.json()
    })
    .then((jsonData) => {
      this.questions = jsonData.results
    })
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
