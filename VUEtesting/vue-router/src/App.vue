<template>
  <div id="app">
    <h1>Let's go somwhere!</h1>
    <hr />
    <router-link to="/">Home</router-link>
    <router-link to="/users/10">Users Team 10</router-link>
    <router-link to="/users/12">Users Team 12</router-link>
    <hr />
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  
  data () {
    return {
     
    }
  }
}
</script>

<style>

</style>
