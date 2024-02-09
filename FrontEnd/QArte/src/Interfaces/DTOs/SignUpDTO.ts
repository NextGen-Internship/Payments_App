interface SignUpDTO{
    id:number;
    firstName:string;
    lastName:string;
    username:string
    password:string;
    email:string;
    pictureURL:string;
    phoneNumber:string;
    country:string;
    stripeAccountID:string;
    address:string;
    city:string;
    postalCode:string;
    IBAN:string;
    isBanned:boolean;
    roleID:number;
    bankAccountID:number;
    settlementCycleID:number;
    settlementCycleEnum:number;
    paymentMethodEnum:number;
}
export default SignUpDTO
