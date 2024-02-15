import axios, { AxiosRequestConfig } from 'axios';
import ApiResponseDTO from '../Interfaces/DTOs/ApiResponseDTO';

class ApiService {
    private baseUrl = import.meta.env.VITE_BASE_URL;

    private async handleResponse(response: any):Promise<ApiResponseDTO> {
        //console.groupCollapsed(response.status);
        console.log(response.status);
        const succeed = response.status == 200;
        
        let message = '';
        let data = null;

        if(succeed){
            data = response.data;
            message = response.data.message || 'Success';
        }else{
            message = response.data.errorMessage || 'An error occurred';
        }
        return { succeed, message, data };
    }

    private async request<T>(config: AxiosRequestConfig): Promise<ApiResponseDTO> {
        try {
            const response = await axios(config);
            console.log(response);
            return this.handleResponse(response);
        } catch (error: any) {
            console.error('API request error:', error);
            throw new Error(error.response?.data.errorMessage || 'An error occurred');
        }
    }

    async get<T>(endpoint: string): Promise<ApiResponseDTO> {
        return this.request<T>({
            method: 'get',
            url: `${this.baseUrl}/${endpoint}`,
        });
    }

    async post<T>(endpoint: string, data: any): Promise<ApiResponseDTO> {
        console.log(data);
        return this.request<T>({
            method: 'post',
            url: `${this.baseUrl}/${endpoint}`,
            data,
        });
    }

    async put<T>(endpoint: string, data: any): Promise<ApiResponseDTO> {
        return this.request<T>({
            method: 'put',
            url: `${this.baseUrl}/${endpoint}`,
            data,
        });
    }

    // async update<T>(endpoint: string, data: any): Promise<ApiResponseDTO> {
    //     return this.request<T>({
    //         method: 'update',
    //         url: `${this.baseUrl}/${endpoint}`,
    //         data,
    //     });
    // }

    async delete<T>(endpoint: string): Promise<ApiResponseDTO> {
        return this.request<T>({
            method: 'delete',
            url: `${this.baseUrl}/${endpoint}`,
        });
    }
}

export default ApiService;