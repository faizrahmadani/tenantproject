import { useMutation } from '@tanstack/vue-query';
import Api from '../../services/api';

interface RegisterRequest {
	username: string;
	email: string;
	password: string;
}

export const useRegister = () => {

	return useMutation({
		mutationFn: async (data: RegisterRequest) => {
			const response = await Api.post('/api/Register', data);
			return response.data;
		}
	});;
};