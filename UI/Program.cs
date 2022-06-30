using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace UI
{
    internal class Program
    {   
        //Expression<Func<T,bool>>filter=null = linq ile gelen filtreleme fonksiyonudur.
        //Generic Constraint = generic kısıt , generic yapımıza where ile şartlar ekleme
            // class : referans tip şartı ,  classın özelliği(örn : IEntity "entitiy olabilir yada implemente eden olabilir"),new()"newlenebilir olmali" , 
        static void Main(string[] args)
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //foreach (var user in userManager.GetAll())
            //{
            //    Console.WriteLine("{0} ------ {1}", user.UserName, user.Email);
            //}mm

            //Movie movie = new Movie() { MovieName="Karayip Korsanları",Description="AKSİYON FİLMİ SEVERLER",Direction="JONYDEEP"};

            
            //movieManager.Add(movie);
            MovieManager movieManager = MovieTest();
        }

        private static MovieManager MovieTest()
        {
            MovieManager movieManager = new MovieManager(new EfMovieDal());
            foreach (var mov in movieManager.GetAll())
            {
                Console.WriteLine("{0} ------ {1}", mov.MovieName, mov.Description);
            }

            return movieManager;
        }
    }
}
//IDisposable pattern implementation of c# => araştır