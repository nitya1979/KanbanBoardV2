export class RegisterModel{
    UserName : string;
    Email : string;
    Password : string;
    ConfirmPassword : string;
};

export class ChangePasswordModel{
    CurrentPassword : string;
    NewPassword : string;
    ConfirmPassword : string;
}