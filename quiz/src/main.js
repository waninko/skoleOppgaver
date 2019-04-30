import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import "firebase/app"
import "firebase/firestore"
import VueFire from 'vuefire'
import App from './App.vue'

Vue.use(BootstrapVue)
Vue.use(VueFire)
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
