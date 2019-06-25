<template>
<div class ="wrapper">
  <div class ="header">
    <img src="../assets/hg.png">
    </div>

    <div class="content">
  <div id=login>
     
    <form @submit.prevent="submit">
      <i class="fas fa-user icon"></i>
      <input id="name" type="text" v-model="user.username" placeholder="Brukernavn">
      <br>
      <i class="fas fa-unlock icon"></i>
      <input type="password" v-model="user.password" placeholder="Passord">
      <br>
      <button @click="submit()">Log in</button>
     
    </form>
  </div>
  </div>
  <div class="footer"></div>
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

</script>
