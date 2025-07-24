using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeAtendimentoHospitalar
{
    /// <summary>
    /// Todos os metodos que vem de user pode ser chamados pelo processo especifico
    /// </summary>
    public  class Usuario
    {
       Usuario user = new Usuario();
       private string user_Login;
       private string user_Password;
       public string User_Login { get { return user_Login; } set { User_Login = value; } }
       public string User_Password { get { return User_Password; } set { User_Password = value; } }
        public virtual void test()
        {

        }
   

    }

    public class Login : Usuario
    {
        
    }

    public class Sing_in : Usuario 
    {
   
    }
    public class Admin : Usuario
    {
    }

}
