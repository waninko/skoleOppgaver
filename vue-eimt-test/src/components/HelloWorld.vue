 <template>
      <div class="hello">
        <h1 class="is-size-3">{{ msg }}</h1>
        <br>
         <div class="container" style="width: 35%;">
              <input class="input" type="text" v-model="welcomeMsg"> <br/><br/>
         <button class="button is-primary is-medium" @click="changeMsg">Click to change welcome message</button>
          <br>
          <hr>
           <p> {{data}}</p>
          <input class="input" type="text" v-model="testData"> <br/><br/>
         
          <button class="button is-primary is-medium" @click="changeData">Click to change data</button>
         
         </div>
      </div>
    </template>

    <script>
    /* eslint-disable */
    export default {
      name: "HelloWorld",
      data() {
        return {
        welcomeMsg: {"fromChild" :"yes",
        "notFromChild" : "no"},
        testData: "childName"
        }
      },
      props: {
        msg: Object,
        data: String
      },
      methods: {
        changeMsg() {
          this.$emit("changeMsg", this.welcomeMsg);
          console.log('message emit from child component')
        },
        changeData(){
          this.$emit("testData", this.testData);
          console.log("new data emitted form child")
        }
      }
    };
    </script>
    <!-- Add "scoped" attribute to limit CSS to this component only -->
    <style scoped>
    h3 {
      margin: 40px 0 0;
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