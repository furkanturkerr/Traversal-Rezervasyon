using Microsoft.AspNetCore.Identity;

namespace Traversal_Rezervasyon.Models;

public class CustomIdentityValidator : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError()
        {
            Code = "PasswordTooShort",
            Description =$"Parola minumum {length} karakter olmalı."
        };
    }

    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresUpper",
            Description =$"Parola en az 1 Büyük içermelidir."
        };
    }
    
    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresLower", 
            Description =$"Parola en az 1 Küçük içermelidir."
        };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresNonAlphanumeric", 
            Description =$"Parola en az 1 sembol içermelidir."
        };
    }
    
    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError
        {
            Code = "PasswordRequiresDigit",
            Description = $"Parola en az 1 rakam içermelidir ('0'.'9')."
        };
    }
}