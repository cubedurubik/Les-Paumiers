public class LittleRoom
{

private int num;//numéro de salle
private bool unlock;//dévérouillé ou pas
private BoardManager bordM;//agencement salle


public LittleRoom(int n)//constructeur avec plan non définit
{
    this.num = n;//numéro de la salle principale afiliée
    this.unlock = true;
    this.bordM = null;//à compléter avec le générateur
}


public LittleRoom(int n, bool lck, BoardManager bord)// constructeur avec plan définit
{
    this.num = n;
    this.unlock = lck;
    this.bordM = bord;
}


public void setLock(bool lck)// ouvre/ferme une salle
{
    this.unlock = lck;
}

}
