namespace TicketSystem.Utils
{
    public class TokenHelper
    {
        public static (int IdAleatorioUno, int IdAleatorioDos, int IdAleatorioTres) GenerarIds(int idUsuario, int idPerfil)
        {
            int idAleatorioUno = idUsuario + idPerfil;
            int idAleatorioDos = idUsuario * idPerfil;
            int idAleatorioTres = idAleatorioUno + idAleatorioDos;

            return (idAleatorioUno, idAleatorioDos, idAleatorioTres);
        }
    }

}
