using DocOpen.Core;
namespace DocOpen.Data
{
    public class User
    {
        public int Id{get; set;}
        public string FirstName{get; set;}
        public string SecondName{get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Telephone{get; set;}

        public string Country{get; set;}
        public string city {get; set;}
        public string Address {get; set;}
        public int PostCode{get; set;}
        public string WebPage {get; set;}
        public EUserState State{get; set;}
        public ERole Role{get; set;}
    }
}