namespace ViewCreator.TestMvc.Model
{
    using ViewCreator.Components;

    [Button]
    public class LoginViewModel
    {
        [Input]
        public string Username { get; set; }

        [Input]
        public string Password { get; set; }


        public static bool Validate(string username, string password)
        {
            /*
             * Db işleminin gerçekleştirilecektir.
             */

            return username == "admin" && password == "admin";
        }
    }
}