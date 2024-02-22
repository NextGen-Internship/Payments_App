interface SignUpDTO{
    ID: 0,
    Email:string,
    Password: string,
    Username: string,
    FirstName: string,
    LastName: string,
    Address: string,
    Country: string,
    City: string,
    postalCode: string,
    IBAN: string,
    PhoneNumber: string,
    isBanned: boolean,
    RoleID: 0,
    BankAccountID: 0,
    stripeAccountID: "",
    PictureURL: string,
    SettlementCycleEnum: number,
    SettlementCycleID: number,
    paymentMethodEnum: 0,
    roleEnum: 0,
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
export default SignUpDTO