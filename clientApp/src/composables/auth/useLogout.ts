import Cookies from "js-cookie";
import { useRouter } from 'vue-router';

export const useLogout = (): (() => void) => {

	// initialize router
	const router = useRouter();

	const logout = (): void => {

		Cookies.remove("token");
		Cookies.remove("user");

		router.push({ name: 'login' })
	};

	return logout;
};