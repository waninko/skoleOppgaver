import Vue from 'vue'
import Router from 'vue-router'
import CompA from '@/components/CompA'
import CompB from '@/components/CompB'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'CompA',
      component: CompA,
      props: true
    },
    {
      path: '/b',
      name: 'CompB',
      component: CompB,
      props: true
    }
  ]
})
