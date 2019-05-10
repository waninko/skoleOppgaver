<template>
  <div>
    {{msg}}
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'OpprettVask',
  data () {
    return {
      msg: "Her kan man opprette/skrive seg opp på vask om det er ledig tid..?",

    }
  }
}
</script>
