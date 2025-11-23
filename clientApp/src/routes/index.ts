import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/',
		name: 'tenant',
		component: () => import('../views/tenants/index.vue'),
	},
	{
		path: '/register',
		name: 'register',
		component: () => import('../views/tenants/create.vue'),
	},
	{
		path: '/:pathMatch(.*)*',
		name: '404',
		component: () => import('../views/404/index.vue'),
	},
]

const router = createRouter({
	history: createWebHistory(),
	routes,
})

export default router
