import { useQuery } from '@tanstack/vue-query';
import Api from '../../services/api';
import Cookies from 'js-cookie';

export const useGetTenantTypes = () => {
	return useQuery<TenantType[], Error>({
		queryKey: ['tenants'],

		queryFn: async () => {
			const token = Cookies.get('token');
			const response = await Api.get('/api/Tenant/Types', {
				headers: {
					Authorization: `Bearer ${token}`,
				},
			});
			return response.data as TenantType[];
		},
	});
}

export interface TenantType {
	id: string
	name: string
}
