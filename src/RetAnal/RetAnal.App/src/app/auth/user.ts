export interface User {
  username: string;
  role: 'admin' | 'guest';
  token: string;
}
