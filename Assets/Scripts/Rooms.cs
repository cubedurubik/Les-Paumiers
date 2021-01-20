using UnityEngine;
using Random = UnityEngine.Random;

public class Rooms
{

public static LittleRoom[] mainRooms;  //tableau des salles prédéfinis, première et dernière salles fixent
public static LittleRoom[] fightRooms; //tableau des salles à ennemis
public static int[] order;//ordre des salles
private static int nbRooms; // nombre de salles principales, utile pour changer le nombre facilement pendant le dev du jeu
private static int numBossRoom;//numéro salle du boss (!= rang)


public static void runRooms(int nbr, int nBoss)//paramètre : nombre salle, et numéro de la salle du boss pour créer les salles bonus
{
    nbRooms = nbr;
    numBossRoom = nBoss;
    order = new int[nbRooms];
    mainRooms = new LittleRoom[nbRooms];
    fightRooms = new LittleRoom[nbRooms];

    /*construction des salles :
        organisation : 0 -> salle 1, ouverte ; 1:6 -> salle 2:7 -> fermées;
        8 -> salle boss -> fermée ; 9+ -> salles bonus -> ouvertes */
    //construction de toutes les salles :
    for(int kiki = 0; kiki < nbRooms; kiki++)//petiteuh markeuh perso
    {
        order[kiki] = kiki;//profite de la boucle pour remplir le tableau

        mainRooms[kiki] = new LittleRoom(kiki, false, null);//marche pas pour le moment
    }

    //ouvre la salle du départ
    //(et les salles bonus si on a le temps de les faires)
    mainRooms[0].setLock(true);// ouvre la salle 1

    for(int i = numBossRoom; i < nbRooms; i ++)// ouvre salles bonus
    {
        mainRooms[0].setLock(true);
    }

    for(int i = 0; i < numBossRoom - 1; i ++)//créer 1 fightRoom par mainRoom
    {
        fightRooms[i] = new LittleRoom(i);
    }

    order = shuffleOrder();
}



private static int[] shuffleOrder()
{
    //créer un tableau contenant les rangs des salles hors salle 1 et salle du boss
    int[] tabRank = new int[nbRooms-2];
    for(int i = 1; i < numBossRoom - 1; i++)//numéro partie après salle 1 et avant boss
    {
        tabRank[i-1] = i;
    }
    for(int i = nbRooms - 1 ; i > numBossRoom - 1 ; i--)//numéro seconde partie après boss (s'il y a)
    {
        tabRank[i -2] = i;
    }

    //créer un tableau avec les rangs des salles mélangés d'une façon... *exotique*
    int[] tabRankShuff = new int[nbRooms-2];
    int k;
    for(int i = nbRooms-2 -1; i >= 0; i--)//nbRooms-2 -> 2 chambre en moins, -1 -> index donc -1
    {
        k = Random.Range(0, i+1); //de 0 inclu à i+1 exclu
        tabRankShuff[i] = tabRank[k]; //copie une valeur de rang aléatoire dans le tabShuff
        tabRank[k] = tabRank[i]; //échange la valeur aléatoire avec la "dernière" valeur
    }
    tabRankShuff[0] = tabRank[0];

    return tabRankShuff;
}

}