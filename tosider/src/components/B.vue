<template>
  <div class="hello">
    Dette er B
    <input type="range" min="1" max="100" step="1" v-model="b"/>
    {{ b }}
    <button @click="goToA()">Gå til A</button>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      b: 1
    }
  },
  methods: {
      goToA: function (){
          this.$router.push({ name: 'A', params: { index: this.b } })
      }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
