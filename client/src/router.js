import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  },
  {
    path: '/profiles/:profileId',
    name: 'Profile',
    component: loadPage('ProfilePage'),
    // FIXME make sure the user's auth is resolved before loading the route
  },
  {
    path: '/vaults/:vaultId',
    name: 'Vault',
    component: loadPage('VaultPage'),
    beforeEnter: authGuard
    // FIXME make sure the user's auth is resolved before loading the route
  },
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
