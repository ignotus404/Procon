using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A25 {

    int[,] EvaluateMoveStateScore = new[,] {
           { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 2, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 0, 0, 0 },
{ 0, 0, 2, 0, 0, 1, 0, 1, 0, 2, 0, 0, 2, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 2, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
{ 0, 0, 1, 0, 0, 2, 0, 1, 0, 2, 0, 1, 1, 1, 0, 2, 0, 1, 0, 2, 0, 0, 1, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
{ 0, 0, 2, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0 },
{ 0, 2, 0, 0, 0, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 0, 0, 0, 2, 0 },
{ 0, 0, 2, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
{ 0, 0, 1, 0, 0, 2, 0, 1, 0, 2, 0, 1, 1, 1, 0, 2, 0, 1, 0, 2, 0, 0, 1, 0, 0 },
{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 2, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 2, 0, 0, 1, 0, 1, 0, 2, 0, 0, 2, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0 },
{ 0, 0, 0, 2, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },

                };

    int[,] EvaluateBuildStateScore = new[,] {

        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 2, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 0, 0, 0 },
{ 0, 0, 2, 0, 0, 1, 0, 1, 0, 2, 0, 0, 2, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 2, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
{ 0, 0, 1, 0, 0, 2, 0, 1, 0, 2, 0, 1, 1, 1, 0, 2, 0, 1, 0, 2, 0, 0, 1, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
{ 0, 0, 2, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0 },
{ 0, 2, 0, 0, 0, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 0, 0, 0, 2, 0 },
{ 0, 0, 2, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
{ 0, 0, 1, 0, 0, 2, 0, 1, 0, 2, 0, 1, 1, 1, 0, 2, 0, 1, 0, 2, 0, 0, 1, 0, 0 },
{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 2, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 2, 0, 0, 1, 0, 1, 0, 2, 0, 0, 2, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0 },
{ 0, 0, 0, 2, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },

                };
};
