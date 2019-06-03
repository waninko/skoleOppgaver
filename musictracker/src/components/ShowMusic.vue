<template>
  <div>{{msg}}
    <input type="text" v-model="searchInput"><br>
    {{searchInput}}
    <button @click="getMusicInfo()">Search!</button>
    <br>
    <ul>
      <li v-for="(result, index) in searchOutput" v-bind:key="index">
          <p>{{result.artistName}} ~ {{result.name}} </p></li>
    </ul>
<br> Country to see top artists in:
<input type="text" v-model="countryInput"><br>
<ul>
  <li v-for="(result, index) in countryOutput" v-bind:key="index">
  {{index}}.  {{result.name}} - {{result.listeners}} listeners!
  </li>
</ul>
  </div>
</template>

<script>
export default {
  name: "ShowMusic",
  data() {
    return {
      msg: "Search track names/ Artist names: ",
      searchInput: "",
      searchOutput: [],
      countryInput:"",
      countryOutput: []
    };
  },
  created(){

  },
  methods: {
    getMusicInfo() {
      const LastFM = require("last-fm");
      const lastfm = new LastFM("2966e89ae7f423c13dc2fd74303548b3", {
        userAgent: "MyApp/1.0.0 (http://example.com)"
      });
console.log("this i method: " + this.searchInput)

    if(!this.searchInput == ""){
      lastfm.trackSearch({ q: this.searchInput }, (err, data) => {
        if (!err){
          console.log(...data.result)
          this.searchOutput.push(...data.result)
          }
        else {
          console.error(err)
        }
      })
    } else { console.log("Blank, checking countryBox.")}

    if(!this.countryInput == ""){
      lastfm.geoTopArtists({country: this.countryInput}, (err, data) => {
        console.log("geo test: ", ...data.artist)
        this.countryOutput.push(...data.artist)
      })
    } else { console.log("No input in Countrybox.")}
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
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
