import ApiResponseDTO from "../Interfaces/DTOs/ApiResponseDTO";
import LoginWithGoogleDTO from "../Interfaces/DTOs/LoginWithGoogleDTO";
import SignInDTO from "../Interfaces/DTOs/SignInDTO";
import SignUpDTO from "../Interfaces/DTOs/SignUpDTO";
import ApiService from "./ApiService";


class UserService{
    private LOGIN_WITH_GOOGLE_ENDPOINT = import.meta.env.VITE_LOGIN_WITH_GOOGLE_ENDPOINT;
    private SIGNIN_ENDPOINT = import.meta.env.VITE_SINGIN_ENDPOINT;
    private SIGNUP_ENDPOINT = import.meta.env.VITE_SIGNUP_ENDPOINT;
    private apiService: ApiService;

    constructor(apiService: ApiService) {
        this.apiService = apiService;
    }

    async registerUser(data: SignUpDTO) : Promise<ApiResponseDTO> {
        const formData = new FormData();
        formData.append('firstName', data.firstName);
        formData.append('lastName', data.lastName);
        formData.append('email', data.email);
        formData.append('password', data.password);
    
        return this.apiService.post<ApiResponseDTO>(this.SIGNUP_ENDPOINT, formData);
      }
    
      async loginUser(data: SignInDTO): Promise<ApiResponseDTO> {
        return this.apiService.post<ApiResponseDTO>(this.SIGNIN_ENDPOINT, data);
      }
    
      async loginUserWithGoogle(data: LoginWithGoogleDTO): Promise<ApiResponseDTO> {
        return this.apiService.post<ApiResponseDTO>(this.LOGIN_WITH_GOOGLE_ENDPOINT, data);
      }
    
    //   async logout(): Promise<ApiResponseDTO> {
    //     return this.apiService.get<ApiResponseDTO>(this.LOGOUT_ENDPOINT);
    //   }



}
export default UserService;