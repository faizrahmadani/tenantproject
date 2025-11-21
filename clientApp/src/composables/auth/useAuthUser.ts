import Cookies from 'js-cookie';

interface User {
	id: string;
	username: string;
	email: string;
}

export const useAuthUser = (): User | null => {
	const user = Cookies.get('user');
	console.log(user);
	return user ? JSON.parse(user) as User : null;
};