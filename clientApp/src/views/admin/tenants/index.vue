<script setup lang="ts">
import SidebarMenu from '../../../components/SidebarMenu.vue'
import { useGetTenants, type Tenant } from '../../../composables/tenants/useGetTenants'
import { TenantType } from '../../../enum/Tenant';

const { data: tenants, isLoading, isError, error } = useGetTenants()

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
		<div class="row">
			<div class="col-md-3">
				<SidebarMenu />
			</div>
			<div class="col-md-9">
				<div class="card border-0 rounded-2 shadow-sm">
					<div class="card-header d-flex justify-content-between align-items-center">
						<span>TENANTS</span>
						<router-link to="/admin/tenants/create" class="btn btn-sm btn-success rounded-2 shadow-sm border-0">
							ADD TENANT
						</router-link>
					</div>
					<div class="card-body">
						<div v-if="isLoading" class="alert alert-info text-center">
							Loading...
						</div>

						<div v-if="isError" class="alert alert-danger text-center">
							Error: {{ error?.message }}
						</div>

						<table v-if="tenants" class="table table-bordered">
							<thead class="bg-dark text-white">
								<tr>
									<th>Name</th>
									<th>Email Address</th>
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
									<!-- <td class="text-center">
										<router-link :to="`/admin/users/edit/${tenant.id}`"
											class="btn btn-sm btn-primary rounded-2 shadow-sm border-0 me-2">
											EDIT
										</router-link>
										<button @click="handleDelete(tenant.id)" :disabled="isPending"
											class="btn btn-sm btn-danger rounded-2 shadow-sm border-0">
											{{ isPending ? 'DELETING...' : 'DELETE' }}
										</button>
									</td> -->
								</tr>
							</tbody>
						</table>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>