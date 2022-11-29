using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Perfil
    {
        public string? Nombre { get; set; } 

        public string? Correo { get; set; }  

        public string? Contraseña { get; set; } 

        public string? Username { get; set; }

        public static Perfil ValidarPerfil(string user,string password)
        {
            try
            {
                using (var db = new AplicacionCCContext())
                {
                    var Usuario = db.Users.FirstOrDefault(x => x.Username == user && x.Contraseña == password);
                    if (Usuario != null)
                    {
                        
                        return new Perfil
                        {
                            Nombre = Usuario.Nombre,
                            Correo = Usuario.Correo,
                            Username = Usuario.Username,
                            Contraseña = Usuario.Contraseña
                        };
                    }
                    else { throw new Exception("No existe usuario"); }
                }
            }
            catch (Exception e) 
            {
                return null;
            } 
        }

        //Este método se encarga de crear un nuevo usuario
        public static int Crearperfil(Perfil usuario)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    db.Add(new User()
                    {
                        Username = usuario.Username,
                        Nombre = usuario.Nombre,
                        Correo = usuario.Correo,
                        Contraseña = usuario.Contraseña
                    });   
                    db.SaveChanges();
                }
                return 1;
            }
            catch(Exception){ return 0; }
        }
        public static string ActualizarPerfil(string usuario, string nombre, string correo)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.Username == usuario);
                    if(user != null)
                    {
                        if(nombre != null)
                        {
                            user.Nombre = nombre;
                        }
                        if(correo != null)
                        {
                            user.Correo = correo;
                        }
                        db.SaveChanges();
                        return "1"; 
                    }
                    else throw new Exception("No se encontro el perfil"); 
                }
            }
            catch (Exception e)
            {
                if (e.ToString() != "No se encontro el perfil") return e.ToString();
                else return e.ToString();
            }
        }
    }
}
