import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import Cookies from 'js-cookie'

const getToken = (): string | undefined => Cookies.get('token')

const routes: RouteRecordRaw[] = [
	{
		path: '/',
		name: 'home',
		component: () => import('../views/home/index.vue'),
	},
	{
		path: '/register',
		name: 'register',
		component: () => import('../views/auth/register.vue'),
		meta: { guestOnly: true },
	},
	{
		path: '/login',
		name: 'login',
		component: () => import('../views/auth/login.vue'),
		meta: { guestOnly: true },
	},
	{
		path: '/admin/dashboard',
		name: 'dashboard',
		component: () => import('../views/admin/dashboard/index.vue'),
		meta: { requiresAuth: true },
	},
	{
		path: '/admin/tenants',
		name: 'tenants',
		component: () => import('../views/admin/tenants/index.vue'),
		meta: { requiresAuth: true },
	},
	{
		path: '/admin/tenants/create',
		name: 'admin.tenants.create',
		component: () => import('../views/admin/tenants/create.vue'),
		meta: { requiresAuth: true }
	},
	// {
	// 	path: '/admin/users',
	// 	name: 'admin.users.index',
	// 	component: () => import('../views/admin/users/index.vue'),
	// 	meta: { requiresAuth: true }
	// },
	// {
	// 	path: '/admin/users/create',
	// 	name: 'admin.users.create',
	// 	component: () => import('../views/admin/users/create.vue'),
	// 	meta: { requiresAuth: true }
	// },
]

const router = createRouter({
	history: createWebHistory(),
	routes,
})

router.beforeEach((to, from, next) => {
	const token = getToken()
	const isAuthenticated = !!token

	if (to.meta.requiresAuth && !isAuthenticated) {
		return next({ name: 'login', query: { redirect: to.fullPath } })
	}
	if (to.meta.guestOnly && isAuthenticated) {
		return next({ name: 'dashboard' })
	}
	next()
})

export default router
