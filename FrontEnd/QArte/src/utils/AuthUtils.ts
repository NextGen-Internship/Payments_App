export const setToken = (token: string): void => {
  sessionStorage.setItem('token', token);
};

export const getToken = (): string | null => {
    return sessionStorage.getItem('token');
  };
  
  export const clearToken = (): void => {
    sessionStorage.removeItem('token');
  };
  