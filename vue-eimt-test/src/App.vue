 <template>
      <div id="app">
        <img alt="Vue logo" src="./assets/logo.png">
        <HelloWorld @changeMsg="setMessage" :msg="welcomeMsg" />
        <!-- <HelloWorld @changeData="getChildData" :data="testData" /> -->
        <!-- <B @testData="testData"/> -->
         {{testData}}
      </div>
    </template>

    <script>
    /* eslint-disable */
    import HelloWorld from "./components/HelloWorld.vue";
    export default {
      name: "app",
      data() {
        return {
          welcomeMsg: {"fromChild" :"no",
        "notFromChild" : "yes"},
          testData: "parentName"
        };
      },
      methods: {
        setMessage(msg) {
          this.welcomeMsg = msg; 
        },
        getChildData(data){
          this.testData = data;
        }
      },
      components: {
        HelloWorld
      }
    };
    </script>
    <style>
    #app {
      font-family: "Avenir", Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      text-align: center;
      color: #2c3e50;
      margin-top: 60px;
    }
    </style>