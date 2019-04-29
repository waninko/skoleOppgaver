<template>
  <div class="yourScore">
    
     DU FIKK EN SCORE PÅ: {{ numCorrect }}
     
  </div>
</template>

<script>

export default {
  props: [
    'numCorrect',
    'showScores'
  ],
 
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