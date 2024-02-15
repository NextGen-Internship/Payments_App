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
    SettlementCycleEnum: 0,
    SettlementCycleID: 0,
    paymentMethodEnum: 0,
    roleEnum: 0,
}
export default SignUpDTO


// interface SignUpDTO{
//     ID:number;
//     firstName:string;
//     lastName:string;
//     username:string
//     Password:string;
//     Email:string;
//     pictureURL:string;
//     phoneNumber:string;
//     country:string;
//     stripeAccountID:string;
//     address:string;
//     city:string;
//     postalCode:string;
//     IBAN:string;
//     isBanned:boolean;
//     roleID:number;
//     bankAccountID:number;
//     settlementCycleID:number;
//     settlementCycleEnum:number;
//     paymentMethodEnum:number;
// }
// export default SignUpDTO