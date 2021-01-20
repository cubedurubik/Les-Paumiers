public class LittleRoom
{

private int num;//numéro de salle ou salle affilié (pour les fightRooms)
private BoardManager bordM;//agencement salle


public LittleRoom(int n)//constructeur avec plan non définit
{
    this.num = n;//numéro de la salle principale afiliée
    this.bordM = null;//à compléter avec le générateur aléatoire
}


public LittleRoom(int n, BoardManager bord)// constructeur avec plan définit
{
    this.num = n;
    this.bordM = bord;
}

}
