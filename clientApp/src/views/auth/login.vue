<script setup lang="ts">
import { ref, reactive } from 'vue';
import { useRouter } from 'vue-router';
import Cookies from 'js-cookie';
import { useLogin } from '../../composables/auth/useLogin';

interface ValidationErrors {
	[key: string]: string
}

const router = useRouter();

const { mutate, isPending } = useLogin();

const email = ref<string>('');
const password = ref<string>('');

const errors = reactive<ValidationErrors>({})

const handleLogin = (e: Event) => {
	e.preventDefault()
	mutate(
		{ email: email.value, password: password.value },
		{
			onSuccess: (data: any) => {
				Cookies.set('token', data.token)
				Cookies.set(
					'user',
					JSON.stringify({
						id: data.id,
						username: data.username,
						email: data.email,
					})
				)

				router.push('/admin/dashboard')
			},
			onError: (error: any) => {
				const data = error.response?.data
				Object.assign(errors, data.errors || { _global: data.message || 'Terjadi kesalahan' })
			},
		}
	)
}
</script>

<template>
	<div class="row justify-content-center mt-5">
		<div class="col-md-4">
			<div class="card border-0 rounded-2 shadow-sm">
				<div class="card-body">
					<h4 class="fw-bold text-center">LOGIN</h4>
					<hr />
					<div v-if="errors._global" class="alert alert-danger mt-2 rounded-2">
						Email or Password is incorrect
					</div>
					<form @submit="handleLogin">
						<div class="form-group mb-3">
							<label class="mb-1 fw-bold">Email</label>
							<input v-model="email" type="text" class="form-control" placeholder="Email" />
							<div v-if="errors.email" class="alert alert-danger mt-2 rounded-2">
								{{ errors.email }}
							</div>
						</div>

						<div class="form-group mb-3">
							<label class="mb-1 fw-bold">Password</label>
							<input v-model="password" type="password" class="form-control" placeholder="Password" />
							<div v-if="errors.password" class="alert alert-danger mt-2 rounded-2">
								{{ errors.password }}
							</div>
						</div>

						<button type="submit" class="btn btn-primary w-100 rounded-2" :disabled="isPending">
							{{ isPending ? 'Loading...' : 'LOGIN' }}
						</button>
					</form>
				</div>
			</div>
		</div>
	</div>
</template>