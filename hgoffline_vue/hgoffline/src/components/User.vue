<template>
  <div id="userpage">
    <div id="showuser">
      <ul v-for="user in users">
        <p>
          {{user.name}}
          <a v-on:click="showform(user)" class="far fa-edit"></a>
        </p>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "userpage",
  mounted: function() {
    this.showuser();
  },
  data() {
    return {
      users: {}
    };
  },
  methods: {
    async showuser() {
      const response = await axios.get("user.php").then(response => {
        this.users = response.data;
        console.log(response.data);
      });
    },
    showform: function(user) {
      alert(user.id);
    }
  }
};
</script>