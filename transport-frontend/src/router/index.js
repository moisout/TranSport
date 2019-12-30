import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import UserStore from '@/store/user'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import(/* webpackChunkName: "login" */ '../views/Login.vue')
  },
  {
    path: '/anlaesse',
    name: 'anlaesse',
    component: () => import(/* webpackChunkName: "anlaesse" */ '../views/Anlaesse.vue')
  },
  {
    path: '/spieler',
    name: 'spieler',
    component: () => import(/* webpackChunkName: "spieler" */ '../views/Spieler.vue')
  },
  {
    path: '/fahrer',
    name: 'fahrer',
    component: () => import(/* webpackChunkName: "fahrer" */ '../views/Fahrer.vue')
  },
  {
    path: '/fahrzeuge',
    name: 'fahrzeuge',
    component: () => import(/* webpackChunkName: "fahrzeuge" */ '../views/Fahrzeuge.vue'),
    alias: [
      '/vereinsfahrzeuge'
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  UserStore.isLoggedIn().then(result => {
    next()
  }, err => {
    console.error(err)
    if (to.name !== 'login') {
      next('/login')
    } else {
      next()
    }
  })
})

export default router
