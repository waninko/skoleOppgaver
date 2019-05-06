<template>
    <div>
        <h2> TIMER: {{ time }}  -  timePoints: {{timePoints}}</h2>
    </div>
</template>

<script>

export default {
  props: {
      submitAnswer: Boolean,
      nextQuestion: Boolean
  },
  watch: {
      nextQuestion: function(Boolean){
          console.log("nextQ endret seg!")
          this.startTimer()
          this.nextQuestion = false
      }
  },
  data(){
    return {
      time: 0,
      isRunning: false,
      interval: null,
      timePoints: null
    }
  },
  created() {
        this.startTimer()
        
  },
  computed: {

  },
  methods: {
   startTimer() {
       console.log("er enxtQuestion true eller false? " + this.nextQuestion)
       if(this.nextQuestion == false){
          this.interval = setInterval(this.incrementTime, 1000)
          this.isRunning = !this.isRunning
        }
        else if( this.nextQuestion == true){
            this.time = 0
            this.interval = setInterval(this.incrementTime, 1000)
            this.isRunning = !this.isRunning
        }
        else { console.log("Something went wrong...")}
    },

    incrementTime() {
      this.time = parseInt(this.time) + 1;
      if(this.submitAnswer == true && this.nextQuestion == false){
           clearInterval(this.interval);
           this.timerPoints()
         }
      
    },
    timerPoints(){
        if(this.time <= 5){
            console.log("timerpoints: " + this.timePoints)
            this.timePoints = 5
        }
        else {this.timePoints = 2}
    }
  }
}

</script>