<template>
  <div id="timer">
    <span id="minutes">{{ minutes }}</span>
    <span id="middle">:</span>
    <span id="seconds">{{ seconds }}</span>
    <button id="start" @click="startTimer">START</button>
    <!--     Pause Timer -->
    <button id="stop" @click="stopTimer">PAUSE</button>
    <!--     Restart Timer -->
    <button id="reset" @click="resetTimer">RESET</button>
    <span id="seconds">TimePoints: {{ timePoints }}</span>
  </div>
</template>


<script>
export default {
  props: ["index"],
  data() {
    return {
      timer: null,
      startTime: 0,
      timePoints: 0,
      isTimeStopped: false

    };
  },
  mounted() {
    this.startTimer()
  },
  watch: {
    index: function(integer) {
      this.calculateTimePoints()
      this.resetTimer()
      this.startTimer()
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
      if(this.seconds <= 2){
        console.log("added 5 points.")
        this.timePoints +=5
      }
      else if(this.seconds <= 5){
        console.log("added 2 points.")
        this.timePoints +=2
      }
      
    
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