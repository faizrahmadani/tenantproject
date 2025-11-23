<script setup lang="ts">
import { ref, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useGetTenantTypes } from '../../composables/tenants/useGetTenantTypes'
import { useCreateTenant } from '../../composables/tenants/useCreateTenant'
import { TenantType } from '../../enum/Tenant'

const router = useRouter()

const tenantName = ref<string>('')
const tenantType = ref<{ id: string, name: string }>({ id: '', name: '' })
const tenantPhone = ref<string>('')
const tenantAddress = ref<string>('')
const boothNum = ref<string | null>(null)
const areaSm = ref<number | null>(null)

const errors = reactive<Record<string, string>>({})

const { data: tenantTypes } = useGetTenantTypes();
const { mutate, isPending } = useCreateTenant()

const addTenant = (e: Event) => {
	e.preventDefault()
	mutate(
		{
			tenantName: tenantName.value,
			tenantTypeId: tenantType.value.id,
			tenantPhone: tenantPhone.value,
			tenantAddress: tenantAddress.value,
			boothNum: boothNum.value,
			areaSm: areaSm.value,
		},
		{
			onSuccess: () => {
				router.push('/')
			},
			onError: (error: any) => {
				Object.assign(errors, error.response.data.errors)
			},
		}
	)
}
</script>

<template>
	<div class="container mt-5 mb-5">
		<div class="row justify-content-center">
			<div class="col-md-9">
				<div class="card border-0 rounded-2 shadow-sm">
					<div class="card-header">
						ADD TENANT
					</div>
					<div class="card-body">
						<form @submit="addTenant">
							<div class="form-group mb-3">
								<label class="mb-1 fw-bold">Tenant Name</label>
								<input required type="text" v-model="tenantName" class="form-control"
									placeholder="Tenant Name" />
								<div v-if="errors.tenantName" class="alert alert-danger mt-2 rounded-2">
									{{ errors.tenantName }}
								</div>
							</div>

							<div class="form-group mb-3">
								<label class="mb-1 fw-bold">Tenant type</label>
								<select required v-model="tenantType" class="form-control">
									<option disabled :value="{ id: '', name: '' }">Please select one</option>
									<option v-for="type in tenantTypes" :value="{ id: type.id, name: type.name }">
										{{ type.name }}
									</option>
								</select>
								<div v-if="errors.tenantType" class="alert alert-danger mt-2 rounded-2">
									{{ errors.tenantType }}
								</div>
							</div>

							<div class="form-group mb-3">
								<label class="mb-1 fw-bold">Tenant Address</label>
								<input required type="text" v-model="tenantAddress" class="form-control"
									placeholder="Tenant Address" />
								<div v-if="errors.tenantAddress" class="alert alert-danger mt-2 rounded-2">
									{{ errors.tenantAddress }}
								</div>
							</div>

							<div class="form-group mb-3">
								<label class="mb-1 fw-bold">Tenant Phone</label>
								<input required type="text" v-model="tenantPhone" class="form-control"
									placeholder="Tenant Phone" />
								<div v-if="errors.tenantPhone" class="alert alert-danger mt-2 rounded-2">
									{{ errors.tenantPhone }}
								</div>
							</div>

							<div class="form-group mb-3" v-if="tenantType.name == TenantType.Booth">
								<label class="mb-1 fw-bold">Booth Number</label>
								<input required type="text" v-model="boothNum" class="form-control"
									placeholder="Booth Number" />
								<div v-if="errors.boothNum" class="alert alert-danger mt-2 rounded-2">
									{{ errors.boothNum }}
								</div>
							</div>

							<div class="form-group mb-3" v-if="tenantType.name == TenantType.SpaceOnly">
								<label class="mb-1 fw-bold">Requested Area m²</label>
								<input required type="text" v-model="areaSm" class="form-control"
									placeholder="Requested Area m²" />
								<div v-if="errors.areaSm" class="alert alert-danger mt-2 rounded-2">
									{{ errors.areaSm }}
								</div>
							</div>

							<button type="submit" class="btn btn-md btn-primary rounded-2 shadow-sm border-0"
								:disabled="isPending">
								{{ isPending ? 'Saving...' : 'Save' }}
							</button>

							<router-link to="/" class="btn btn-md btn-secondary rounded-2 shadow-sm border-0 ms-2">
								Cancel
							</router-link>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>