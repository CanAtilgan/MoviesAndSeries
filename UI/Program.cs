using Business.Concrete;
using Core.Utilities.FilePath;
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


            FilePath fp = new FilePath();
            FilePath.Dco();




            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Message)
            {
                Console.WriteLine(user);
            }
            
            
             
            //MovieManager movieManager = MovieTest();

            //Category();

        }

        private static void Category()
        {
            Category cate = new Category();
            cate.CategoryName = "AKSİYON";
            Category cate2 = new Category();
            cate.CategoryName = "KORKU";
            CategoryManager category = new CategoryManager(new EfCategoryDal());
            category.Add(cate);

            //foreach (var catego in category.GetAll())
            //{
            //    Console.WriteLine("{0} ---{1}", catego.CategoryName, catego.Id);
            //}
        }

       // private static MovieManager MovieTest()
        //{
            Movie movie3 = new Movie() { MovieName = "Yürüyen Ölüler", Description = "KORKU FİLMİ SEVERLER", CategoryId = 2,Direction="jONY" };
           // MovieManager movieManager = new MovieManager(new EfMovieDal());
            //movieManager.Add(movie3);
            //foreach (var mov in movieManager.GetMovieDetails())
            //{
            //    Console.WriteLine("{0} ------ {1}", mov.MovieName, mov.CategoryName);
            //}

            //return movieManager;
        //}
    }
}
//IDisposable pattern implementation of c# => araştır