import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login'
import Department from '@/components/Department'
import User from '@/components/User'

Vue.use(Router)

export default new Router({

  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    },
    {
      path: '/Department',
      name: 'Department',
      component: Department,
      props: true
    },
    {
      path: '/User',
      name: 'User',
      component: User,
      props: true
    }
  ]
})
