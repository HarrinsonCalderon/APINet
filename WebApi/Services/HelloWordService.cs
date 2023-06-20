namespace WebApi.Services
{
    public class HelloWordService:IHelloWordService
    {
        
        public string GetHelloWord()
        {
            return "Hola mundo";
        }
    }
    //Sirve para exponer solamente los metodos que queramos 
    public interface IHelloWordService
    {
        string GetHelloWord();
    }
}
