<script setup lang="ts">
import { ref, reactive } from "vue";
import { useRouter } from "vue-router";
import { useRegister } from "../../composables/auth/useRegister";

interface ValidationErrors {
	[key: string]: string;
}

const router = useRouter();

const username = ref<string>('');
const email = ref<string>('');
const password = ref<string>('');

const errors = reactive<ValidationErrors>({});

const { mutate, isPending } = useRegister();

const handleRegister = (e: Event) => {
	e.preventDefault();
	mutate(
		{
			username: username.value,
			email: email.value,
			password: password.value,
		},
		{
			onSuccess: () => {
				router.push("/login");
			},
			onError: (error: any) => {
				Object.assign(errors, error.response.data.errors);
			},
		}
	);
};
</script>

<template>
	<div class="row justify-content-center">
		<div class="col-md-6">
			<div class="card border-0 rounded-2 shadow-sm">
				<div class="card-body">
					<h4 class="fw-bold text-center">REGISTER</h4>
					<hr />
					<form @submit.prevent="handleRegister">
						<div class="row">
							<div class="col-md-12 mb-3">
								<div class="form-group">
									<label class="mb-1 fw-bold">Username</label>
									<input v-model="username" type="text" class="form-control" placeholder="Username" />
									<div v-if="errors.username" class="alert alert-danger mt-2 rounded-2">
										{{ errors.username }}
									</div>
								</div>
							</div>
						</div>

						<div class="row">
							<div class="col-md-6 mb-3">
								<div class="form-group">
									<label class="mb-1 fw-bold">Email address</label>
									<input v-model="email" type="email" class="form-control" placeholder="Email Address" />
									<div v-if="errors.email" class="alert alert-danger mt-2 rounded-2">
										{{ errors.email }}
									</div>
								</div>
							</div>
							<div class="col-md-6 mb-3">
								<div class="form-group">
									<label class="mb-1 fw-bold">Password</label>
									<input v-model="password" type="password" class="form-control" placeholder="Password" />
									<div v-if="errors.password" class="alert alert-danger mt-2 rounded-2">
										{{ errors.password }}
									</div>
								</div>
							</div>
						</div>

						<button type="submit" class="btn btn-primary w-100 rounded-2" :disabled="isPending">
							{{ isPending ? 'Loading...' : 'REGISTER' }}
						</button>
					</form>
				</div>
			</div>
		</div>
	</div>
</template>