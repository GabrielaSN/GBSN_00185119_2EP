namespace Parcial2.modelo
{
    public class usuario
    {
         public string iduser { get; set; }
         public string fName { get; set; }
         public string user { get; set; }
         public string contrasena { get; set; }
         public bool usertype { get; set; }

         public usuario()
         {
             iduser = "";
             fName = " ";
             user = " ";
             contrasena = "";
             usertype = false;
             
         }
    }
}