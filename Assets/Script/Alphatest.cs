using Koma;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Alphatest : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    GameObject Board;
    GameObject TM;
    KomaCalulator komaCalulator;
    EvaluationFunctions eF;
    EvaluationFunctionsMove eFM;
    public TurnManager turnManager;
    [Header("�]���֐�"), SerializeField] C11 c;
    public KomaIndex[] k = new KomaIndex[12];
    public Text txt;
    public bool Move;
    bool F = false;
    int De;
    int firstN;
    Area area;
    int castle = 100;
    int bluekoma_point = 10;
    int jinti_point = 30;
    int[,] EvaluateMoveStateScore;
    int[,] EvaluateBuildStateScore;
    private void Start()
    {
        Board = GameObject.Find("BoardBridge");
        TM = GameObject.Find("Board");
        turnManager = TM.GetComponent<TurnManager>();
        komaCalulator = TM.GetComponent<KomaCalulator>();
        eF = TM.GetComponent<EvaluationFunctions>();
        eFM = TM.GetComponent<EvaluationFunctionsMove>();
        EvaluateMoveStateScore = eFM.EvaluationA();
        EvaluateBuildStateScore = eF.EvaluationA();
        var CanMoves = new List<KomaIndex>();
      /*  for (int a = 0; a < turnManager.BoardXMax; a ++)
        {
            for (int b = 0;  b < turnManager.BoardXMax; b++)
            {
                if(a == 0 || b == 0)
                {
                    EvaluateMoveStateScore[a , b] = -100;
                }
                area = this.transform.GetChild(a).GetChild(b).GetComponent<Area>();
                if (area.castle && a-1 > 0)
                {
                   
                    EvaluateMoveStateScore[a - 1, b] = 5;
                
                   
                }
                else if (area.castle && b - 1 > 0 )
                {

                    EvaluateMoveStateScore[a, b - 1] = 5;
                }
                else if(area.castle && b + 1 < turnManager.BoardXMax )
                {
                    EvaluateMoveStateScore[a, b + 1] = 5;
                }
                else if(area.castle && a + 1 < turnManager.BoardYMax)
                {
                    EvaluateMoveStateScore[a + 1, b] = 5;
                }
                else
                {
                    EvaluateMoveStateScore[a, b] = 0;
                }
                Debug.Log(EvaluateMoveStateScore[a, b]);

            }
        }
      */
      
    }

    public int EvaluateBuildStates(int[,] ban)
    { 
        var myscore = 0;
        var enemyscore = 0;
        komaCalulator.AIAreaCheckBlue(ban);
        ///komaCalulator.AIAreaCheckRed(ban);
        for (int i = 0; i < turnManager.RedBridges.transform.childCount; i++)
        {
          //  Debug.Log(i);
            myscore += EvaluateMoveStateScore[komaCalulator.BlueX[i], komaCalulator.BlueY[i]];
            enemyscore += EvaluateMoveStateScore[komaCalulator.RedX[i], komaCalulator.RedY[i]];
        }
        for (int y = 0; y < turnManager.BoardYMax; y++)
        {
           
            for (int x = 0; x < turnManager.BoardXMax; x++)
            {
                //Debug.Log(myscore);
                 var Banscore = EvaluateBuildStateScore[x, y];
               // var Banscore = 0;
                if (ban[x, y] == 10)
                {
                 //   Debug.Log(ban[x, y]);
                    myscore += bluekoma_point + Banscore;
                }
                else if (ban[x, y] == 30)
                {
                    myscore += jinti_point + Banscore;
                }
                else if (ban[x, y] == -10)
                {
                    enemyscore += bluekoma_point + Banscore;
                }
                else if (ban[x, y] == -30)
                {
                    enemyscore += jinti_point + Banscore;
                }
                else if (ban[x, y] == 130)
                {
                    myscore += castle + Banscore;
                }
                else if (ban[x, y] == -130)
                {
                    enemyscore += castle + Banscore;
                }
                else if (ban[x, y] == 15)
                {
                    enemyscore += jinti_point + Banscore;
                    myscore += jinti_point + Banscore;
                }

                
            }

        }
      // Debug.Log(myscore);
       //Debug.Log(enemyscore);
        return myscore - enemyscore;
    }
    public int EvaluateMoveStates(int[,] ban , int N)
    {
        // ban = komaCalulator.AIScoreCheck(ban);
        var myscore = 0;
        var enemyscore = 0;
        komaCalulator.AIAreaCheckBlue(ban);
        ///komaCalulator.AIAreaCheckRed(ban);
        for (int i = 0; i < turnManager.transform.childCount; i++)
        {
            myscore += EvaluateMoveStateScore[komaCalulator.BlueX[i], komaCalulator.BlueY[i]];
            enemyscore += EvaluateMoveStateScore[komaCalulator.RedX[i], komaCalulator.RedY[i]];
        }
        for (int y = 0; y < turnManager.BoardYMax; y++)
        {

            for (int x = 0; x < turnManager.BoardXMax; x++)
            {
               
                var Banscore = EvaluateBuildStateScore[x, y];
                // var Banscore = 0;
                if (ban[x, y] == 10)
                {
                    //   Debug.Log(ban[x, y]);
                    myscore += bluekoma_point + Banscore;
                }
                else if (ban[x, y] == 30)
                {
                    myscore += jinti_point + Banscore;
                }
                else if (ban[x, y] == -10)
                {
                    enemyscore += bluekoma_point + Banscore;
                }
                else if (ban[x, y] == -30)
                {
                    enemyscore += jinti_point + Banscore;
                }
                else if (ban[x, y] == 130)
                {
                    myscore += castle + Banscore;
                }
                else if (ban[x, y] == -130)
                {
                    enemyscore += castle + Banscore;
                }
                else if (ban[x, y] == 15)
                {
                    enemyscore += jinti_point + Banscore;
                    myscore += jinti_point + Banscore;
                }


            }

        }
        Debug.Log(myscore);
        // Debug.Log(enemyscore);
        return myscore - enemyscore;
    }
    public void AlphaBeta(int depth, int[,] ban, int N, bool Bule)
    {
        // komaCalulator.AIBlueTurn = true;
      
        KomaIndex resultKomaIndex = null;
        KomaIndex resultPutIndex = null;
        KomaIndex resultDestoryIndex = null;
        var alpha = -100;
        var alphaB = -100;
        var beta = -1000;
        var score = 0;
        var Buildscore = 0;
        var max = 0;
        firstN = N;
        var canMovekoma = komaCalulator.GetCanMoveIndex(N, Bule);
        var canDestroy = komaCalulator.GetCanDestoroyIndex(N , Bule);
        foreach (var putkomaStateIndex in canMovekoma)
        {
            De = 0;
           
                var Ban = ban;
            if (putkomaStateIndex.Build == true)
            {
                De = komaCalulator.What(Ban, putkomaStateIndex.X, putkomaStateIndex.Y);
                Ban = komaCalulator.Build(putkomaStateIndex.X, putkomaStateIndex.Y, ban, Bule);
                Buildscore = GetAllCanMoveSearch(Ban, depth - 1, alphaB, beta, 0, !Bule);
               
                if (alphaB < Buildscore)
                    {
                        alphaB = Buildscore;
                        resultPutIndex = putkomaStateIndex;
                        max = Buildscore;
                    }
            }
            if (putkomaStateIndex.Build == false)
            {
                De = komaCalulator.What(Ban, putkomaStateIndex.X, putkomaStateIndex.Y);
                
                Ban = komaCalulator.Move(putkomaStateIndex.X, putkomaStateIndex.Y, ban, N, Bule);
                if (Bule)
                {

                    komaCalulator.BlueX[N] = putkomaStateIndex.X;
                    komaCalulator.BlueY[N] = putkomaStateIndex.Y;
                }
                else
                {
                    komaCalulator.RedX[N] = putkomaStateIndex.X;
                    komaCalulator.RedY[N] = putkomaStateIndex.Y;
                }
                // score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bule);
                score = GetAllCanMoveSearch(Ban , depth-1  , alpha , beta , 0 ,!Bule);
             //   Debug.Log(score);
                if (alpha < score)
                {
                   
                    alpha = score;
                    resultKomaIndex = putkomaStateIndex;
                    max = score;
                }

               
            }
                Ban[putkomaStateIndex.X, putkomaStateIndex.Y] = De;
            
        }
       if(resultKomaIndex == null)
        {
            foreach (var Des in canDestroy)
            {
                var Ban = ban;
                Ban = komaCalulator.Build(Des.X, Des.Y, ban, Bule);
                var Detroyscore = GetAllCanMoveSearch(Ban, depth - 1, alphaB, beta, 0, !Bule);

            
                    alphaB = Buildscore;
                    resultDestoryIndex = Des;
                

            }
        }
        if (canDestroy != null)
        {
            foreach (var Des in canDestroy)
            {
                var Ban = ban;
                Ban = komaCalulator.Build(Des.X, Des.Y, ban, Bule);
               var Detroyscore = GetAllCanMoveSearch(Ban, depth - 1, alphaB, beta, 0, !Bule);
                if (max < Detroyscore)
                {
                    alphaB = Buildscore;
                    resultDestoryIndex = Des;
                }

            }
        }
        if (resultDestoryIndex != null)
        {
            
            turnManager.BuildAndDestroyBridge(resultDestoryIndex.Y, resultDestoryIndex.X, N);
            turnManager.Dontroop[N, turnManager.NowTurn] = resultDestoryIndex;
           
            for (int n = 0; n < turnManager.RedBridges.transform.childCount; n++)
            {
                GameObject komaR = turnManager.RedBridges.transform.GetChild(n).gameObject;
                GameObject komaB = turnManager.BlueBridges.transform.GetChild(n).gameObject;
                komaCalulator.bb[n] = komaR.GetComponent<BridgeButtonManager>();
                komaCalulator.RedX[n] = komaCalulator.bb[n].BoardX;
                komaCalulator.RedY[n] = komaCalulator.bb[n].BoardY;
                komaCalulator.bb[n] = komaB.GetComponent<BridgeButtonManager>();
                komaCalulator.BlueX[n] = komaCalulator.bb[n].BoardX;
                komaCalulator.BlueY[n] = komaCalulator.bb[n].BoardY;
                
               

            }
         //   RoopCount++;
        }
      
        else
        {
           Debug.Log(alpha);
            Debug.Log(alphaB);
            if (alpha > alphaB)
            {

                if (Bule)
                {
                    for (int n = 0; n < turnManager.BlueBridges.transform.childCount; n++)
                    {
                        GameObject komaR = turnManager.RedBridges.transform.GetChild(n).gameObject;
                        GameObject komaB = turnManager.BlueBridges.transform.GetChild(n).gameObject;
                        komaCalulator.bb[n] = komaR.GetComponent<BridgeButtonManager>();
                        komaCalulator.RedX[n] = komaCalulator.bb[n].BoardX;
                        komaCalulator.RedY[n] = komaCalulator.bb[n].BoardY;
                        komaCalulator.bb[n] = komaB.GetComponent<BridgeButtonManager>();
                        komaCalulator.BlueX[n] = komaCalulator.bb[n].BoardX;
                        komaCalulator.BlueY[n] = komaCalulator.bb[n].BoardY;

                    }
             
                    area = this.transform.GetChild(komaCalulator.BlueY[N]).GetChild(komaCalulator.BlueX[N]).GetComponent<Area>();
                    area.Bridge = false;
                    GameObject koma = turnManager.BlueBridges.transform.GetChild(N).gameObject;
                    koma.transform.position = turnManager.MoveBridge(resultKomaIndex.Y, resultKomaIndex.X,N);
                  
                    komaCalulator.BlueX[N] = resultKomaIndex.X;
                    komaCalulator.BlueY[N] = resultKomaIndex.Y;
                    komaCalulator.bb[N].BoardX = resultKomaIndex.X;
                    komaCalulator.bb[N].BoardY = resultKomaIndex.Y;
                    turnManager.Dontroop[N,turnManager.RoopCount] = resultKomaIndex;
                   
                    area = this.transform.GetChild(resultKomaIndex.Y).GetChild(resultKomaIndex.X).GetComponent<Area>();
                    area.Bridge = true;
                }
                if (!Bule)
                {
                    for (int n = 0; n < turnManager.RedBridges.transform.childCount; n++)
                    {
                        GameObject komaR = turnManager.RedBridges.transform.GetChild(n).gameObject;
                        GameObject komaB = turnManager.BlueBridges.transform.GetChild(n).gameObject;
                        komaCalulator.bb[n] = komaR.GetComponent<BridgeButtonManager>();
                        komaCalulator.RedX[n] = komaCalulator.bb[n].BoardX;
                        komaCalulator.RedY[n] = komaCalulator.bb[n].BoardY;
                        komaCalulator.bb[n] = komaB.GetComponent<BridgeButtonManager>();
                        komaCalulator.BlueX[n] = komaCalulator.bb[n].BoardX;
                        komaCalulator.BlueY[n] = komaCalulator.bb[n].BoardY;

                    }

                    GameObject koma = turnManager.RedBridges.transform.GetChild(N).gameObject;
                    komaCalulator.bbb[N] = koma.GetComponent<BridgeButtonManager>();
                    koma.transform.position = turnManager.MoveBridge(resultKomaIndex.Y, resultKomaIndex.X, N);
                    komaCalulator.RedX[N] = resultKomaIndex.X;
                    komaCalulator.RedY[N] = resultKomaIndex.Y;
                    komaCalulator.bbb[N].BoardX = resultKomaIndex.X;
                    komaCalulator.bbb[N].BoardY = resultKomaIndex.Y;
                }


            }
            else
            {
                turnManager.BuildAndDestroyBridge(resultPutIndex.Y, resultPutIndex.X, N);
                   turnManager.Dontroop[N, turnManager.NowTurn] = resultKomaIndex;
                for (int n = 0; n < turnManager.RedBridges.transform.childCount; n++)
                {
                    GameObject komaR = turnManager.RedBridges.transform.GetChild(n).gameObject;
                    GameObject komaB = turnManager.BlueBridges.transform.GetChild(n).gameObject;
                    komaCalulator.bb[n] = komaR.GetComponent<BridgeButtonManager>();
                    komaCalulator.RedX[n] = komaCalulator.bb[n].BoardX;
                    komaCalulator.RedY[n] = komaCalulator.bb[n].BoardY;
                    komaCalulator.bb[n] = komaB.GetComponent<BridgeButtonManager>();
                    komaCalulator.BlueX[n] = komaCalulator.bb[n].BoardX;
                    komaCalulator.BlueY[n] = komaCalulator.bb[n].BoardY;

                }
               // RoopCount++;
            }
        }

    }
    public int GetAllCanMoveSearch(int[,] ban, int depth, int alpha, int beta, int N, bool Bl )
    {
     
        if (depth == 0 ) return EvaluateBuildStates(ban);
        var MaxScore = 0;
        var FirstMaxScore = 10000000;
        int[] XSR = new int[turnManager.BoardXMax];
        int[] YSR = new int[turnManager.BoardYMax];
        int[] XSB = new int[turnManager.BoardXMax];
        int[] YSB = new int[turnManager.BoardYMax];
        XSR[N] = komaCalulator.RedX[N];
        YSR[N ] = komaCalulator.RedY[N];
        XSB[N ] = komaCalulator.BlueX[N];
        YSB[N ] = komaCalulator.BlueY[N];
        var canMovekoma = komaCalulator.BanCanMove(ban, N, komaCalulator.AIBlueTurn); 
        foreach (var putkomaStateIndex in canMovekoma)
        {
           
            int A = 0;
            var Ban = ban;
            if (putkomaStateIndex.Build == true)
            {
                A = komaCalulator.What(ban, putkomaStateIndex.X, putkomaStateIndex.Y);
                Ban = komaCalulator.Build(putkomaStateIndex.X, putkomaStateIndex.Y, ban, Bl);
                
            }
            else
            {
                A = komaCalulator.What(ban, putkomaStateIndex.X, putkomaStateIndex.Y);
                Ban = komaCalulator.Move(putkomaStateIndex.X, putkomaStateIndex.Y, ban, N, Bl);
                if (Bl)
                {
                    komaCalulator.BlueX[N] = putkomaStateIndex.X;
                    komaCalulator.BlueY[N] = putkomaStateIndex.Y;
                }
                else
                {
                    komaCalulator.RedX[N] = putkomaStateIndex.X;
                    komaCalulator.RedY[N] = putkomaStateIndex.Y;
                }

            }
            ban = Ban;
            int[] XSR1 = new int[turnManager.BoardXMax];
            int[] YSR1 = new int[turnManager.BoardYMax];
            int[] XSB1 = new int[turnManager.BoardXMax];
            int[] YSB1 = new int[turnManager.BoardYMax];
           
            XSR1[N + 1] = komaCalulator.RedX[N + 1];
            YSR1[N + 1] = komaCalulator.RedY[N + 1];
            XSB1[N + 1] = komaCalulator.BlueX[N + 1];
            YSB1[N + 1] = komaCalulator.BlueY[N + 1];
            var childMovekoma = komaCalulator.BanCanMove(ban, N + 1, Bl);
            foreach (var child in childMovekoma)
            {
               
                int B = 0;
                if (child.Build == true)
                {
                    B = komaCalulator.What(ban, child.X, child.Y);
                    Ban = komaCalulator.Build(child.X, child.Y, ban, Bl);
                   
                }
                else
                {
                    B = komaCalulator.What(ban, child.X, child.Y);
                    Ban = komaCalulator.Move(child.X, child.Y, ban, N + 1, Bl);
                    if (Bl)
                    {
                        komaCalulator.BlueX[N + 1] = child.X;
                        komaCalulator.BlueY[N + 1] = child.Y;
                    }
                    else
                    {
                        komaCalulator.RedX[N + 1] = child.X;
                        komaCalulator.RedY[N + 1] = child.Y;
                    }
                }
                ban = Ban;
             
                if (N + 1 != turnManager.RedBridges.transform.childCount - 1)
                {
                    int[] XSR2 = new int[turnManager.BoardXMax];
                    int[] YSR2 = new int[turnManager.BoardYMax];
                    int[] XSB2 = new int[turnManager.BoardXMax];
                    int[] YSB2 = new int[turnManager.BoardYMax];
              
                    XSR2[N +2] = komaCalulator.RedX[N +2];
                    YSR2[N +2 ] = komaCalulator.RedY[N +2];
                    XSB2[N +2] = komaCalulator.BlueX[N +2];
                    YSB2[N +2 ] = komaCalulator.BlueY[N +2];
                    var ChildKoma1 = komaCalulator.BanCanMove(ban, N + 2, Bl);
                    foreach (var childKoma1 in ChildKoma1)
                    {
                       
                        int C = 0;
                        if (childKoma1.Build == true)
                        {
                            C = komaCalulator.What(ban, childKoma1.X, childKoma1.Y);
                            Ban = komaCalulator.Build(childKoma1.X, childKoma1.Y, ban, Bl);

                        }
                        else
                        {
                           
                            C = komaCalulator.What(ban, childKoma1.X, childKoma1.Y);
                            Ban = komaCalulator.Move(childKoma1.X, childKoma1.Y, ban, N + 2, Bl);
                            if (Bl)
                            {

                                komaCalulator.BlueX[N + 2] = childKoma1.X;
                                komaCalulator.BlueY[N + 2] = childKoma1.Y;
                            }
                            else
                            {
                                komaCalulator.RedX[N + 2] = childKoma1.X;
                                komaCalulator.RedY[N + 2] = childKoma1.Y;
                            }
                        }
                        ban = Ban;
                        if (N + 2 != turnManager.RedBridges.transform.childCount - 1)
                        {
                            int[] XSR3 = new int[turnManager.BoardXMax];
                            int[] YSR3 = new int[turnManager.BoardYMax];
                            int[] XSB3 = new int[turnManager.BoardXMax];
                            int[] YSB3 = new int[turnManager.BoardYMax];
                            XSR3[N + 3] = komaCalulator.RedX[N + 3];
                            YSR3[N + 3] = komaCalulator.RedY[N + 3];
                            XSB3[N + 3] = komaCalulator.BlueX[N + 3];
                            YSB3[N + 3] = komaCalulator.BlueY[N + 3];
                            var ChildKoma3 = komaCalulator.BanCanMove(ban, N + 3, Bl);
                            foreach (var childKoma3 in ChildKoma3)
                            {
                                int D = 0;
                                if (childKoma3.Build == true)
                                {
                                    D = komaCalulator.What(ban, childKoma3.X, childKoma3.Y);
                                    Ban = komaCalulator.Build(childKoma3.X, childKoma3.Y, ban, Bl);
                                }
                                else
                                {
                                    D = komaCalulator.What(ban, childKoma3.X, childKoma3.Y);
                                    Ban = komaCalulator.Move(childKoma3.X, childKoma3.Y, ban, N + 3, Bl);
                                    if (Bl)
                                    {
                                        komaCalulator.BlueX[N + 3] = childKoma3.X;
                                        komaCalulator.BlueY[N + 3] = childKoma3.Y;
                                    }
                                    else
                                    {
                                        komaCalulator.RedX[N + 3] = childKoma3.X;
                                        komaCalulator.RedY[N + 3] = childKoma3.Y;
                                    }
                                }
                                ban = Ban;
                                if (N + 3 != turnManager.RedBridges.transform.childCount - 1)
                                {
                                    int[] XSR4 = new int[turnManager.BoardXMax];
                                    int[] YSR4 = new int[turnManager.BoardYMax];
                                    int[] XSB4 = new int[turnManager.BoardXMax];
                                    int[] YSB4 = new int[turnManager.BoardYMax];
                                    XSR4[N + 4] = komaCalulator.RedX[N + 4];
                                    YSR4[N + 4] = komaCalulator.RedY[N + 4];
                                    XSB4[N + 4] = komaCalulator.BlueX[N + 4];
                                    YSB4[N + 4] = komaCalulator.BlueY[N + 4];
                                    var ChildKoma4 = komaCalulator.BanCanMove(ban, N + 4, Bl);
                                    foreach (var childKoma4 in ChildKoma4)
                                    {
                                        int E = 0;
                                        if (childKoma4.Build == true)
                                        {
                                            E = komaCalulator.What(ban, childKoma4.X, childKoma4.Y);
                                            Ban = komaCalulator.Build(childKoma4.X, childKoma4.Y, ban, Bl);
                                        }
                                        else
                                        {
                                            E = komaCalulator.What(ban, childKoma4.X, childKoma4.Y);
                                            Ban = komaCalulator.Move(childKoma4.X, childKoma4.Y, ban, N + 4, Bl);
                                            if (Bl)
                                            {
                                                komaCalulator.BlueX[N + 4] = childKoma4.X;
                                                komaCalulator.BlueY[N + 4] = childKoma4.Y;
                                            }
                                            else
                                            {
                                                komaCalulator.RedX[N + 4] = childKoma4.X;
                                                komaCalulator.RedY[N + 4] = childKoma4.Y;
                                            }
                                        }
                                        ban = Ban;
                                        if (N + 4 != turnManager.RedBridges.transform.childCount - 1)
                                        {
                                            int[] XSR5 = new int[turnManager.BoardXMax];
                                            int[] YSR5 = new int[turnManager.BoardYMax];
                                            int[] XSB5 = new int[turnManager.BoardXMax];
                                            int[] YSB5 = new int[turnManager.BoardYMax];
                                            XSR3[N + 5] = komaCalulator.RedX[N + 5];
                                            YSR3[N + 5] = komaCalulator.RedY[N + 5];
                                            XSB3[N + 5] = komaCalulator.BlueX[N + 5];
                                            YSB3[N + 5] = komaCalulator.BlueY[N + 5];
                                            var ChildKoma5 = komaCalulator.BanCanMove(ban, N + 5, Bl);
                                            foreach (var childKoma5 in ChildKoma5)
                                            {
                                                int F = 0;
                                                if (childKoma5.Build == true)
                                                {
                                                    F = komaCalulator.What(ban, childKoma5.X, childKoma5.Y);
                                                    Ban = komaCalulator.Build(childKoma5.X, childKoma5.Y, ban, Bl);
                                                }
                                                else
                                                {
                                                    F = komaCalulator.What(ban, childKoma5.X, childKoma5.Y);
                                                    Ban = komaCalulator.Move(childKoma5.X, childKoma5.Y, ban, N + 5, Bl);
                                                    if (komaCalulator.AIBlueTurn)
                                                    {
                                                        komaCalulator.BlueX[N + 5] = childKoma5.X;
                                                        komaCalulator.BlueY[N + 5] = childKoma5.Y;
                                                    }
                                                    else
                                                    {
                                                        komaCalulator.RedX[N + 5] = childKoma5.X;
                                                        komaCalulator.RedY[N + 5] = childKoma5.Y;
                                                    }
                                                }
                                                ban = Ban;
                                                var score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bl );
                                                if (score > MaxScore)
                                                {
                                                    MaxScore = score;
                                                }
                                                
                                                    Ban[childKoma5.X, childKoma5.Y] = F;
                                                komaCalulator.RedX[N + 5] = XSR5[N + 5];
                                                komaCalulator.RedY[N + 5] = YSR5[N + 5];
                                                komaCalulator.BlueX[N + 5] = XSB5[N + 5];
                                                komaCalulator.BlueY[N + 5] = YSB5[N + 5];

                                            }
                                        }

                                        else
                                        {
                                            var score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bl);
                                           
                                            if (score > FirstMaxScore ) return score;
                                            if (score > MaxScore)
                                            {
                                                beta = score;
                                                score = MaxScore;
                                            }
                                          
                                        }
                                       
                                        Ban[childKoma4.X, childKoma4.Y] = E;
                                        komaCalulator.RedX[N + 4] = XSR4[N + 4];
                                        komaCalulator.RedY[N + 4] = YSR4[N +4];
                                        komaCalulator.BlueX[N + 4] = XSB4[N + 4];
                                        komaCalulator.BlueY[N + 4] = YSB4[N + 4];

                                    }
                                    FirstMaxScore = beta;
                                }
                                else
                                {
                                    var score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bl);
                                 //   Debug.Log(score);
                                    if (score > MaxScore)
                                    {
                                    
                                       
                                       
                                        MaxScore = score;
                                       
                                    }

                                }
                               
                                Ban[childKoma3.X, childKoma3.Y] = D;
                                komaCalulator.RedX[N + 3] = XSR3[N + 3];
                                komaCalulator.RedY[N + 3] = YSR3[N + 3];
                                komaCalulator.BlueX[N + 3] = XSB3[N + 3];
                                komaCalulator.BlueY[N + 3] = YSB3[N + 3];
                            }

                        }
                        else
                        {
                            var score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bl);
                           
                            if (FirstMaxScore >score || alpha > score) return score;
                            if (score > MaxScore)
                            {
                               
                                beta = score;
                                score = MaxScore;
                            }
                        }
                        Ban[childKoma1.X, childKoma1.Y] = C;
                        komaCalulator.RedX[N + 2] = XSR2[N + 2];
                        komaCalulator.RedY[N + 2] = YSR2[N + 2];
                        komaCalulator.BlueX[N + 2] = XSB2[N + 2];
                        komaCalulator.BlueY[N + 2] = YSB2[N + 2];
                    }
                    FirstMaxScore = beta;
                }
                else
                {
                    
                    var score = GetAllCanMoveSearch(Ban, depth - 1, alpha, beta, 0, !Bl);
                  
                    if (score > MaxScore ) return score;

                        if (score > MaxScore)
                        {
                        
                        beta = score;
                            score = MaxScore;
                        }
                }
                 //   Debug.Log(B);
                    Ban[child.X, child.Y] = B;
                komaCalulator.RedX[N + 1] = XSR1[N + 1];
                komaCalulator.RedY[N + 1] = YSR1[N + 1];
                komaCalulator.BlueX[N + 1] = XSB1[N + 1];
                komaCalulator.BlueY[N + 1] = YSB1[N + 1];
            }
            Ban[putkomaStateIndex.X, putkomaStateIndex.Y] = A;
           komaCalulator.RedX[N ] = XSR[N];
            komaCalulator.RedY[N] = YSR[N];
            komaCalulator.BlueX[N ] = XSB[N];
            komaCalulator.BlueY[N ] = YSB[N ];
          
        }
        return MaxScore;
    }

}

/*
 
 
 */
