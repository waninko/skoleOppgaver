<template>
  <div class="timerBox" id="timer">
    <span id="minutes">{{ minutes }}</span>
    <span id="middle">:</span>
    <span id="seconds">{{ seconds }}</span><br>
    <span id="seconds">  TimePoints: {{ timePoints }}</span>
  </div>
</template>


<script>
export default {
  props: ["index", "showScores", "numCorrect"],
  data() {
    return {
      timer: null,
      startTime: 0,
      timePoints: 0

    };
  },
  mounted() {
    this.startTimer()
  },
  watch: {
    index: function(integer) {
      //this.calculateTimePoints()
      this.resetTimer()
      this.startTimer()
    },
    showScores: function(bool){
        this.emitToParent()
        this.stopTimer()
    },
    numCorrect: function(integer){
      this.calculateTimePoints()
    }
  },

  methods: {
    startTimer: function() {
      this.timer = setInterval(() => this.countUp(), 1000);
    },
    stopTimer: function() {
      clearInterval(this.timer);
      this.timer = null;
    },
    resetTimer: function() {
      this.startTime = 0;
      clearInterval(this.timer);
      this.timer = null;
    },
    padTime: function(time) {
      return (time < 10 ? "0" : "") + time;
    },
    countUp: function() {
      this.startTime++;
    },
    calculateTimePoints: function() {
      if(this.seconds == 1 || this.seconds == 2 ){
        console.log("Very good! 10 points!")
        this.timePoints +=10
      }
      else if(this.seconds <= 5){
        console.log("under 5 sec! added 2 extra points.")
        this.timePoints +=2
      }
        else if(this.seconds <= 10){
        console.log("10 sec! added 1 extra point.")
        this.timePoints +=1
      }
    },
    emitToParent(event){
      this.$emit("childToParent", this.timePoints)
    }
  },

  computed: {
    minutes: function() {
      const minutes = Math.floor(this.startTime / 60);
      return this.padTime(minutes);
    },
    seconds: function() {
      const seconds = this.startTime - this.minutes * 60;
      return this.padTime(seconds);
    }
  }
};
</script>

<style scoped>
.timerBox{
  color:navy;
  font-size: 25px;
  background: lightblue;
}


</style>