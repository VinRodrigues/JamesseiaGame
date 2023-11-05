using System.Linq;
using Unity.VisualScripting;
public static class ScoreManager{
    public static EstatisticasDeFases[] scoreFases = new EstatisticasDeFases[6].Select(x => new EstatisticasDeFases()).ToArray();
    public static void resetPontuacoes(){
        scoreFases = new EstatisticasDeFases[6].Select(x => new EstatisticasDeFases()).ToArray();
    }
}