import { useMutation } from '@tanstack/vue-query';
import Api from '../../services/api';
import Cookies from 'js-cookie';

export interface TenantRequest {
	tenantName: string
	tenantTypeId: string
	tenantPhone: string
	tenantAddress: string
	boothNum: string | null
	areaSm: number | null
}

export const useCreateTenant = () => {

	return useMutation({
		mutationFn: async (data: TenantRequest) => {
			const token = Cookies.get('token');

			const response = await Api.post('/api/Tenant', data, {
				headers: {
					Authorization: `Bearer ${token}`,
				},
			});

			return response.data;
		}
	});
};