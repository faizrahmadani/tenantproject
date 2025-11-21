<script setup lang="ts">
import { useLogout } from '../composables/auth/useLogout';

const logout = useLogout();

</script>

<template>
	<div class="card border-0 rounded-2 shadow-sm">
		<div class="card-header">
			MAIN MENU
		</div>
		<div class="card-body">
			<div class="list-group">
				<router-link to="/admin/dashboard" class="list-group-item list-group-item-action">Dashboard</router-link>
				<router-link to="/admin/tenants" class="list-group-item list-group-item-action">Tenants</router-link>
				<a href="#" @click="logout" class="list-group-item list-group-item-action">Logout</a>
			</div>
		</div>
	</div>
</template>