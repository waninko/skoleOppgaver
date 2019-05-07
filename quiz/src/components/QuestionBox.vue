<template>
    <div class="question-box-container">
  <b-jumbotron>

    <template slot="lead">
      <!-- {{ currentQuestion.question }} span to avoid ascii issues-->
      <span v-html="currentQuestion.question"></span>
    </template>

    <hr class="my-4">

    <b-list-group>
      <b-list-group-item
      v-for="(answer, index) in shuffledAnswers" 
      :key="index"
      @click="selectAnswer(index)"
      :class="answerClass(index)"
      >
        <!-- {{ answer }} span to avoid ascii issues-->
         <span v-html="answer"></span>
      </b-list-group-item>
    </b-list-group>
    

    <b-button 
    variant="primary"
    @click="submitAnswer"
    :disabled="selectedIndex === null || answered"
    >Submit Answer
    </b-button>

    <b-button @click="next" variant="success" >Next Question</b-button>
  </b-jumbotron>
</div>
</template>

<script >
import _ from 'lodash'

export default{
  props: {
    currentQuestion: Object,
    next: Function,
    incrementCheckAndGetName: Function
  },
  data() {
    return {
      selectedIndex: null,
      correctIndex: null,
      shuffledAnswers: [],
      answered: false
    }
  },
  computed: {
    answers(){
      let answers = [...this.currentQuestion.incorrect_answers]
      answers.push(this.currentQuestion.correct_answer)
      return answers
    }
  },
  watch: {
    currentQuestion: {
      immediate: true,
      handler() {
        this.selectedIndex = null
        this.answered = false
        this.shuffleAnswers()
      }
      
    }
  },
  methods: {
    selectAnswer(index){
     this.selectedIndex = index
    },
    shuffleAnswers(){
       let answers = [...this.currentQuestion.incorrect_answers, this.currentQuestion.correct_answer]
       this.shuffledAnswers = _.shuffle(answers)
       this.correctIndex = this.shuffledAnswers.indexOf(this.currentQuestion.correct_answer)
    },
    submitAnswer(){
      let isCorrect = false
      if (this.selectedIndex === this.correctIndex) {
        isCorrect = true;
      }
      this.answered = true
      this.incrementCheckAndGetName(isCorrect)
      this.next()
    },
    answerClass(index){
      let answerClass = ''

      if(!this.answered && this.selectedIndex === index ){
        answerClass = 'selected'
      } 
      else if(this.answered && this.correctIndex === index){
          answerClass = 'correct'
      }
      else if(this.answered && this.selectedIndex == index && 
              this.correctIndex !== index){
        answerClass = 'incorrect'
      }
      return answerClass
     

      
    }
  }
}
</script>

<style scoped>
.list-group {
  margin-bottom: 15px;
}

.list-group-item:hover {
  background: lightblue;
  cursor: pointer;
}

.selected {
  background-color: lightblue;
}

.correct {
   background-color: lightgreen;
}

.incorrect {
   background-color: #f9665c;
}

.btn {
  margin: 0 5px;
}

</style>