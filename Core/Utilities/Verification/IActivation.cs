using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Verification
{
    public interface IActivation
    {
        
        ActivationOptions SenderMessage(string email,string code);
        public  bool ChechkActivation( string usecode, string codeKey);
        public  string CreateCode();
    }
}
