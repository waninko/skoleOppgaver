import Vue from 'vue';
import VueRouter from 'vue-router';
import App from './App.vue';
//import Message from './Message.vue';
import Users from './users.vue';
import Home from './Home.vue';

//Vue.component('app-message', Message);
Vue.use(VueRouter);

const routes = [
  { path: '/users/:teamId', component: Users },
  { path: '/', component: Home }
];

const router = new VueRouter({
  routes: routes,
  mode: 'history' //fjerne behovet for # fra URL'en
});

new Vue({
  el: '#app',
  router : router,
  render: h => h(App)
});
