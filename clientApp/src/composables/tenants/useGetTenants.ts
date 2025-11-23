import { useQuery } from '@tanstack/vue-query';
import Api from '../../services/api';
import type { Ref } from 'vue';

export const useGetTenants = (search: Ref<string>) => {
	return useQuery<Tenant[], Error>({
		queryKey: ['tenants', search],

		queryFn: async () => {
			const response = await Api.get(`/api/Tenant?search=${search.value || ''}`);
			return response.data as Tenant[];
		},
	});
}

export interface Tenant {
	id: string
	tenantName: string
	tenantType: string
	tenantPhone: string
	tenantAddress: string
	tenantDetail: string
}
