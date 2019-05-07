<template>
  <div>

     <b-progress class="mt-2" :max="1" show-value>
      <b-progress-bar :value="numTotal" variant="warning">Current Success: {{ calculateScore }}</b-progress-bar>
      <b-progress-bar :value="numWrong" variant="secondary">Number of Errors: {{ errorPercent }} </b-progress-bar>
      </b-progress> 
    <b-nav tabs>
      <b-nav-item disabled><b>-=Music Quiz=- </b></b-nav-item>
      <b-nav-item disabled>Questions Answered: {{ numTotal }}/10</b-nav-item>
      <b-nav-item disabled>Current Score: {{ numCorrect }} </b-nav-item>
       <b-nav-item disabled>Current Errors: {{ numWrong }}</b-nav-item>
    </b-nav>
    
  
    
  </div>
</template>

<script>
export default {
  props: [
    'numCorrect',
    'numWrong',
    'numTotal'
  ],
  data(){
    return {
      calculatedScore: null
    }
  },
   computed: {
  	calculateScore() {
      if(this.numCorrect > 0){
        return Math.round(parseInt(this.numCorrect) / parseInt(this.numTotal)* 100) + "%"
      }
      else return 0 + "%";
    	
    },
    errorPercent(){
      if(this.numWrong > 0){
        return Math.round(parseInt(this.numWrong) / parseInt(this.numTotal)* 100) + "%"
      }
       else return 0 + "%";
    }
  }
}
</script>