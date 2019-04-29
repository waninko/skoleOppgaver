<template>
  <div>
    <b-nav tabs>
      <b-nav-item disabled><b>-=Music Quiz=- </b></b-nav-item>
      <b-nav-item disabled>Questions Answered: {{ numTotal }}/15</b-nav-item>
      <b-nav-item disabled>Current Score: {{ numCorrect }} </b-nav-item>
      <b-nav-item disabled>Current Success: {{ calculateScore }}</b-nav-item>
    </b-nav>
  </div>
</template>

<script>
export default {
  props: [
    'numCorrect',
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
        return (parseInt(this.numCorrect) / parseInt(this.numTotal)* 100) + "%";
      }
      else return 0 + "%";
    	
    }
  },
  methods: {
    numberOfQuestions(){
      //when numTotal hits 15 stop
      
    }
  }
}
</script>