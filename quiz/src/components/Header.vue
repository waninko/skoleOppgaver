<template>
  <div>
    <b-nav tabs>
      <b-nav-item disabled><b>-=Music Quiz=- </b></b-nav-item>
      <b-nav-item disabled>Questions Answered: {{ numTotal }}/2</b-nav-item>
      <b-nav-item disabled>Current Score: {{ numCorrect }} </b-nav-item>
       <b-nav-item disabled>Current Fails: {{ numWrong }}</b-nav-item>
    </b-nav>
    
  
     <b-progress class="mt-2" :max="1" show-value>
      <b-progress-bar :value="numTotal" variant="success">Current Success: {{ calculateScore }}</b-progress-bar>
      <b-progress-bar :value="numWrong" variant="danger">Number of Errors: {{ errorPercent }} </b-progress-bar>
      </b-progress> 
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
  },
  methods: {
  
  }
}
</script>