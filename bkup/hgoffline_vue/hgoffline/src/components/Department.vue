<template>
  <div id="datapage">
  <div id="showData">
      <ul v-for="department in departments">
          <a v-on:click = "showform(department)"> {{department.name}}
            </a>

      </ul>
  </div>
  </div>
</template>

<script>
export default {
  name: 'datapage',
  mounted: function() {this.showData();
  },
  data () {
    return {
      departments:  {}
    }
  },
  methods: {
     async showData() {
     const response = await axios.get('main.php')
     .then(response => {
     this.departments = response.data
     console.log(showData);
         });
    },
    /* async selectApp(id) {
    this.selectedApp = this.departments.filter(a => a.id === id);
     },*/

    showform: function (department) {
        alert(department.id);
        var selected_dep = department.id; //<-- ta med denne på et vis  -axios send?
        // const dep_response = await axios.post('user.php', selected_dep);
        window.location.replace('user.html');
        },
    }
}
</script>