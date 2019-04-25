<template>
  <div>
    Dette er komponent B
    <br>
    <input type="text" v-model="persondata.name" placeholder="Navn">
    <br>
    <input type="text" v-model="persondata.birthYear" placeholder="Fødelsesår">
    <br>
    <button @click="nav">Til komponent A</button>
  </div>
</template>

<script>
export default {
  name: "CompB",
  props: ["personprop"],
  data: function() {
    return {
      persondata: {
        name: null,
        birthYear: null
      }
    };
  },
  created: function() {
    this.persondata.name = this.personprop.name;
    this.persondata.birthYear = this.personprop.birthYear;
  },
  methods: {
    nav: function() {
      this.$emit("datachanged", this.persondata);
      this.$router.push("/");
    }
  }
};
</script>
