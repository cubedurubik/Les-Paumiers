public class LittleRoom
{

private int num;//numéro de salle ou salle affilié (pour les fightRooms)
private BoardManager boardM;//agencement salle


public LittleRoom(int n)//constructeur avec plan non définit
{
    this.num = n;//numéro de la salle principale afiliée
    this.boardM = null;//à compléter avec le générateur aléatoire
}


public LittleRoom(int n, BoardManager board)// constructeur avec plan définit
{
    this.num = n;
    this.boardM = board;
}

public BoardManager getBoardM(){
    return boardM;
}

}
