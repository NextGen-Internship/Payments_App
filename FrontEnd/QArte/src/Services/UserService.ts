import ApiResponseDTO from "../Interfaces/DTOs/ApiResponseDTO";

import SignInDTO from "../Interfaces/DTOs/SignInDTO";
import SignUpDTO from "../Interfaces/DTOs/SignUpDTO";
import ApiService from "./ApiService";


class UserService{

    private SIGNIN_ENDPOINT = import.meta.env.VITE_SINGIN_ENDPOINT;
    private SIGNUP_ENDPOINT = import.meta.env.VITE_SIGNUP_ENDPOINT;
    private apiService: ApiService;

    constructor(apiService: ApiService) {
        this.apiService = apiService;
        // 
        
    }
    
    async registerUser(data: SignUpDTO) : Promise<ApiResponseDTO> {
        const response = await this.apiService.post<ApiResponseDTO>(this.SIGNUP_ENDPOINT, data) ;
        response.data;
         
        return response;
      }

      async loginUser(data: SignInDTO): Promise<ApiResponseDTO> {
        return this.apiService.post<ApiResponseDTO>(this.SIGNIN_ENDPOINT, data);
      }


}
export default UserService;