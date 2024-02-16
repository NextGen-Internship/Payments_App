interface SignInDTO{
    email:string;
    password: string;
    pages: [
        {
          id: 0,
          pageName: string,
          bio: string,
          qrLink: string,
          galleryID: 0,
          userID: 0
        }
      ]
}
export default SignInDTO;