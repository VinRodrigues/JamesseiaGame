public class EstatisticasDeFases{
    public int tirosEspeciais = 0;
    public int tirosNormais = 0;
    public int coracoesColetados = 0;
    public int vidas = 5;
    public int basesDerrotados = 0;
    public bool chefeCompleto = false;

    public int pontuacaoTotal(){
        return (tirosEspeciais * 10) 
        + (tirosNormais * 1) 
        + (coracoesColetados * 5) 
        + (basesDerrotados * 10) 
        + ((vidas - 5) * 10) 
        + (chefeCompleto ? 100 : 0);
    }
}