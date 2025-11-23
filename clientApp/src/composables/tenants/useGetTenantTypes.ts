import { useQuery } from '@tanstack/vue-query';
import Api from '../../services/api';

export const useGetTenantTypes = () => {
	return useQuery<TenantType[], Error>({
		queryKey: ['tenants'],

		queryFn: async () => {
			const response = await Api.get('/api/Tenant/Types');
			return response.data as TenantType[];
		},
	});
}

export interface TenantType {
	id: string
	name: string
}
