<template>
  <div>
   {{msg}}
  </div>
</template>


<script>
  import axios from 'axios'

export default {
  name: 'EndreVask',
  data () {
    return {
      msg: "Her kan man endre/slette vask..?",
      
    }
  }
}
</script>
