namespace Aplicacion.Dominio;

public class Validacion
{
    public static void ValidacionCadena(string valor, string error)
    {
        if (valor.Length <= 0)
            throw new Exception("error en caracter");

    }
    public static void ValidacionValor(int Valor, string error)
    {
        if (Valor < 0)
            throw new Exception("error en caracter");
    }
    public static void ValidacionValor(double Valor, string error)
    {
        if (Valor < 0)
            throw new Exception("error en caracter");
    }
    public static void ValidarEmail(string Email, string error)
    {
        if (Email.Contains("@") || Email.Contains("."))
        {
        }
        else
            throw new Exception("Coloque un correo valido");
    }

}