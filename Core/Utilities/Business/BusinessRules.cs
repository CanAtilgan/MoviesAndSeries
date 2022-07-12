using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules//bu bir iş motoru olduğu için interfaceden implemente etmeye gerek yok , ovierddesing yaspısından
    {//iş kuralı çalıştırma motoru
        public static IResult Run(params IResult[] logics)//params yapısı sayesinde , IResult tipinde istediğin kadar parametre yollaya biliyorsun bu metota
        {
            foreach (var logic in logics)//gelen parametre yapılarını(bütün iş kurallarını) gez 
            {
                if (!logic.Success)//durumu başarısız ise 
                {
                    return logic;//başarısız kuralı döndür
                }
            }
            return null;
        }
    }
}
