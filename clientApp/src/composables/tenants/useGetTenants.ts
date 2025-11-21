import { useQuery } from '@tanstack/vue-query';
import Api from '../../services/api';
import Cookies from 'js-cookie';

export const useGetTenants = () => {
	return useQuery<Tenant[], Error>({
		queryKey: ['tenants'],

		queryFn: async () => {
			const token = Cookies.get('token');

			const response = await Api.get('/api/Tenant', {
				headers: {
					Authorization: `Bearer ${token}`,
				},
			});
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
