<template>
  <div>
     <img src="../assets/hg.png">
    <form @submit.prevent="submit">
      <i class="fas fa-user icon"></i>
      <input id="name" type="text" v-model="user.username" placeholder="Brukernavn">
      <br>
      <i class="fas fa-unlock icon"></i>
      <input type="password" v-model="user.password" placeholder="Passord">
      <br>
      <button @click="toDepartment()">Log in</button>
      <p id="message"></p>
    </form>
  </div>
</template>

<script>
export default {
  name: "Login",
  props: ["index"],
  data() {
    return {
      user: {
          username: '',
          password: ''
      }
    };
  },
  methods: {
      submit: async function(event){
          var inputValues = {
              username: this.user.username,
              password: this.user.password
          }
         try {
                const response = await axios.post('login.php', inputValues);
                // console.log(response.data);
                var respons = response.data;
                this.user.visual = response.data.visual;

                /* Aslak var her.... Ikke kødd.
                if (response.data.login) {
                console.log(response.data);
                window.location.replace(response.data.page);
                }*/

            } catch (error) {
                message.innnerHTML = "Feil passord og brukernavn" + error;
                }
      }
  }
 
};


/* //når en trykker på login (toDepartment()) så skal en bruker med -1 få opp alle departments, 0++ bruekre skal rett inn på users på sitt eget department
   methods:{
      toDepartment: function(){
          this.$router.push({name:'Department', params: {}})
      }
  }*/
</script>
