<script setup lang="ts">
import { ref, watch } from 'vue'
import { useGetTenants, type Tenant } from '../../composables/tenants/useGetTenants'
import { TenantType } from '../../enum/Tenant'


const search = ref<string>('')
const debounced = ref<string>('')

let timer: any = null;
watch(search, (val) => {
	clearTimeout(timer)
	timer = setTimeout(() => {
		debounced.value = val
	}, 500);
})

const { data: tenants, isLoading, isError, error } = useGetTenants(debounced)

const getTenantDetail = (tenant: Tenant): string => {
	switch (tenant.tenantType) {
		case TenantType.Booth:
			return `Booth number: ${tenant.tenantDetail}`
		case TenantType.SpaceOnly:
			return `Area: ${tenant.tenantDetail}m²`
		default:
			return '-'
	}
}

</script>

<template>
	<div class="container mt-5 mb-5">
		<div class="row justify-content-center">
			<div class="col-md-9">
				<div class="card border-0 rounded-2 shadow-sm">
					<div class="card-header d-flex justify-content-between align-items-center">
						<span>TENANTS</span>
						<div class="d-flex gap-2">
							<input required type="text" v-model="search" class="form-control" placeholder="Search Tenant name"
								autofocus />
							<router-link to="/register" class="btn btn-sm btn-success rounded-2 shadow-sm border-0">
								ADD TENANT
							</router-link>
						</div>

					</div>
					<div class="card-body">
						<div v-if="isLoading" class="alert alert-info text-center">
							Loading...
						</div>

						<div v-if="isError" class="alert alert-danger text-center">
							Error: {{ JSON.stringify(error) }}
						</div>
						<div class="table-responsive">
							<table v-if="tenants" class="table table-bordered">
								<thead class="bg-dark text-white">
									<tr>
										<th>Name</th>
										<th>Address</th>
										<th>Phone</th>
										<th>Type</th>
										<th>Detail</th>
									</tr>
								</thead>
								<tbody>
									<tr v-for="tenant in tenants" :key="tenant.id">
										<td>{{ tenant.tenantName }}</td>
										<td>{{ tenant.tenantAddress }}</td>
										<td>{{ tenant.tenantPhone }}</td>
										<td>{{ tenant.tenantType }}</td>
										<td>{{ getTenantDetail(tenant) }}</td>
									</tr>
								</tbody>
							</table>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>