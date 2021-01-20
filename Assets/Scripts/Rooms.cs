using UnityEngine;
using Random = UnityEngine.Random;

public class Rooms
{
/*
Procédure :

utiliser une fois Rooms.createRooms(nbr, nBoss)
cela créer les salles qui seront fixent et mémorise certain paramètre

ensuite, à chaque début de partie / mort utiliser Rooms.runRooms()
cela créra des chemins plus ou moins longs.


*/
public static LittleRoom[] mainRooms;  //tableau des salles prédéfinis
public static LittleRoom[][] fightRooms; //tableau de tableau de salle d'ennemis
public static int[] localPlace; //coordonnée salle courante (quelle porte, quelle fightRoom)
private static int nbRooms; // nombre de salles principales, utile pour changer le nombre facilement pendant le dev du jeu

public static void createMainRooms()
{
    localPlace = new int[2];
    localPlace[0] = -1;//hub
    localPlace[1] = 0;
    nbRooms = 9;
    mainRooms = new LittleRoom[nbRooms];
    fightRooms = new LittleRoom[nbRooms][];
    /*construction des salles :
        organisation actuellle : 0 -> salle 1, ouverte ; 1:6 -> salle 2:7 -> fermées;
        8 -> salle boss -> fermée ; 9+ -> salles bonus -> ouvertes */
    //construction de toutes les salles principales :
    

    //s01  : îles  ( -> n')
    mainRooms[0] = new LittleRoom(0, null/**/);//marche pas pour le moment

    //s02  : n'    ( -> eau)
    mainRooms[1] = new LittleRoom(1, null/**/);//marche pas pour le moment

    //s03  : eau   ( -> rat)
    mainRooms[2] = new LittleRoom(2, null/**/);//marche pas pour le moment

    //s04  : rat   ( -> nid (double salle partie 1))
    mainRooms[3] = new LittleRoom(3, null/**/);//marche pas pour le moment

    //s05  : nid   ( -> or)
    mainRooms[4] = new LittleRoom(4, null/**/);//marche pas pour le moment

    //s06  : or    ( -> nid (double salle partie 2))
    mainRooms[5] = new LittleRoom(5, null/**/);//marche pas pour le moment

    //s07  : nid   ( -> argent)
    mainRooms[6] = new LittleRoom(6, null/**/);//marche pas pour le moment

    //s08 : argent ( -> Boss)
    mainRooms[7] = new LittleRoom(7, null/**/);//marche pas pour le moment

    //s09 : Boss
    mainRooms[8] = new LittleRoom(8, null/**/);//marche pas pour le moment

}

public static void createFightRooms()
{
    for(int kiki = 0; kiki<nbRooms; kiki++)
    {
        fightRooms[kiki] = new LittleRoom[randomLength(kiki)];
        for(int i = 0; i < fightRooms[kiki].Length; i++)
        {
            fightRooms[kiki][i] = new LittleRoom(kiki);
        }
    }
}

public static BoardManager redirect(bool up)//monte / descend depuis une fightRoom
{
    int[] lP = localPlace;
    BoardManager direction;
/*
Cas 1 :
il monte
 Cas 1.1 :
 vers une fightRoom (milieu de tableau)

 Cas 1.2 :
 vers une mainRoom (fin de tableau)

Cas 2 :
il descend
 Cas 2.1 :
 vers une fightRoom (milieu de tableau)

 Cas 2.2 :
 vers le hub (début de tableau)
*/

    if(up)
    {
        if(lP[1] == fightRooms[lP[0]].Length -1) //avancé du chemin = à longueur du chemin -1 || dernière salle chemin
        {
            direction = mainRooms[lP[0]].getBoardM();//donne le BoardM de la mainRoom associé à ce chemin
        }
        else
        {
            lP[1]++;
            direction =  fightRooms[lP[0]][lP[1]].getBoardM();
        }
    }
    else
    {
        if(lP[1]==0)
        {
            direction = null/**/; //mettre le BoardM du hub
        }
        else
        {
            lP[1]--;
            direction =  fightRooms[lP[0]][lP[1]].getBoardM();
        }
    }
    return direction;
}

/*
pour l


*/

private static int randomLength(int i)
{
    int k = 1;
    while(Random.Range(0,i*2)+1 >= k)
    {
        k++;
    }
    return k;
}

}