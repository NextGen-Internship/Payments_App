interface ApiResponseDTO{
    succeed: boolean;
    message?: string;
    data?: any;
    id:Int16Array;
}

export default ApiResponseDTO;