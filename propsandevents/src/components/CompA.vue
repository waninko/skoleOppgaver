<template>
  <div>
    Dette er komponent A
    <br>
    <input type="text" v-model="persondata.name" placeholder="Navn">
    <br>
    <input type="text" v-model="persondata.birthYear" placeholder="Fødelsesår">
    <br>
    <button @click="nav">Til komponent B</button>
  </div>
</template>

<script>
export default {
  name: "CompA",
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
      this.$router.push("/b");
    }
  }
};
</script>
