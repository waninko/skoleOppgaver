<template>
  <div class="yourScore">
<p>{{savedName}} - DU FIKK EN SCORE PÅ: {{ numCorrect }}</p>
  <table class="table table-striped">
      <thead>
        <tr>
          <th>Score</th>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="score in scores" v-bind:key= score.score_id>
          <td>{{score.score}}</td>
          <td>{{score.name}}</td>
        </tr>
      </tbody>
    </table>
    <button @click="console()">console.log</button>
</div>

 
  
</template>

<script>
// import Firebase from 'firebase'
// import VueFire from 'vuefire'

//  let config = {
//     apiKey: "AIzaSyACUTRWR1G95ZdvJ8AJXzcc8sAbpNFI5T4",
//     authDomain: "musicquiz-3e9f4.firebaseapp.com",
//     databaseURL: "https://musicquiz-3e9f4.firebaseio.com",
//     projectId: "musicquiz-3e9f4",
//     storageBucket: "musicquiz-3e9f4.appspot.com",
//     messagingSenderId: "832892959771"
//   };
//   let fireApp = Firebase.initializeApp(config);
//   let db = fireApp.database()
//   let scoresRef = db.ref('userScores')

export default {
  props: [
    'numCorrect',
    'showScores',
    'savedName',
    'scores'
  ],
//  firebase:{
//    scores: scoresRef
//  },
 methods: {
   console(){
     console.log("dette ligger i scores" , scores)
   }
 }
}
//Method: popup etter endt spill: enter name
//Method remove hidden class when totalscore == 10..15.. etc så scorelista kommer opp etter endt spill.
//koble inn firebase etc

</script>

<style scoped>

.yourScore{
  color: red;
  font-size: 20px;
}

</style>