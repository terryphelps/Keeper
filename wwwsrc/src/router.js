import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/keeps/:keepId',
      name: 'keeps',
      props: true,
      component: Keep
    },
    {
      path: '/vault/:vaultId',
      name: 'vault',
      props: true,
      component: Vault
    }
  ]
})
