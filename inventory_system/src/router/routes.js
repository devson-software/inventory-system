
const routes = [
  {
    path: '/sign-in',
    component: () => import('layouts/AuthLayout.vue'),
    children: [
      {
        path: '/sign-up',
        component: () => import('pages/Sign-up.vue')
      },
      {
        path:'/sign-in',
        component: () =>import('pages/Sign-in.vue')
      }
    ]
  },
  {
    path: '',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/IndexPage.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
